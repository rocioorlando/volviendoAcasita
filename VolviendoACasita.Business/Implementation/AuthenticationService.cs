using AutoMapper;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService userService;
    private readonly IMapper mapper;
    private readonly Dictionary<string, int> failedLoginAttempts = new Dictionary<string, int>();
    private const int maxFailedAttempts = 5;

    public AuthenticationService(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }

    public ResultDto AuthenticateUser(string userName, string password)
    {
        var result = new ResultDto();

        if (IsAccountLocked(userName, out string errorMessage))
        {
            result.Errors.Add(errorMessage);
            return result;
        }

        return AuthenticateFromDatabase(userName, password);
    }
    private bool IsAccountLocked(string userName, out string errorMessage)
    {
        if (IsUserLockedInDatabase(userName, out errorMessage))
        {
            return true;
        }

        if (IsAccountBlockedDueToFailedAttempts(userName, out errorMessage))
        {
            return true;
        }

        errorMessage = string.Empty;
        return false;
    }

    // Método para verificar si el usuario está bloqueado en la base de datos
    private bool IsUserLockedInDatabase(string userName, out string errorMessage)
    {
        UserDto userDto = userService.GetUserByUserName(userName);
        if (userDto != null && userDto.IsLocked)
        {
            errorMessage = "La cuenta está bloqueada. Contacte con soporte.";
            return true;
        }
        errorMessage = string.Empty;
        return false;
    }

    // Método para verificar si la cuenta está bloqueada debido a múltiples intentos fallidos
    private bool IsAccountBlockedDueToFailedAttempts(string userName, out string errorMessage)
    {
        if (ValidateFailedLoginAttempts(userName))
        {
            errorMessage = "La cuenta está bloqueada debido a múltiples intentos fallidos. Contacte con soporte.";
            return true;
        }
        errorMessage = string.Empty;
        return false;
    }


    private bool ValidateFailedLoginAttempts(string userName)
    {
        if (failedLoginAttempts.TryGetValue(userName, out int attempts))
        {
            if (attempts >= maxFailedAttempts)
            {
                // La cuenta está bloqueada
                return true;
            }
        }
        return false;
    }

    private ResultDto AuthenticateFromDatabase(string userName, string password)
    {
        var result = new ResultDto();
        UserDto userDto = userService.GetUserByUserName(userName);

        if (CheckCredentialsUser(password, userDto))
        {
            ResetFailedLoginAttempts(userName);
            result.UserDto = userDto;
            return result;
        }

        IncrementFailedLoginAttempts(userName);
        result.Errors.Add("Nombre de usuario o contraseña incorrectos.");
        return result;
    }

    private static bool CheckCredentialsUser(string password, UserDto user)
    {
        return user != null && user.Password == password;
    }

    private async void IncrementFailedLoginAttempts(string userName)
    {
        if (failedLoginAttempts.ContainsKey(userName))
        {
            failedLoginAttempts[userName]++;
            if (failedLoginAttempts[userName] >= maxFailedAttempts)
            {
                UserDto userDto = userService.GetUserByUserName(userName);
                if (userDto != null)
                {
                    userDto.IsLocked = true;
                   await userService.UpdateUser(userDto);
                }
            }
        }
        else
        {
            failedLoginAttempts[userName] = 1; 
        }
    }


    private UserDto ConvertEntityToDto(User user)
    {
        return mapper.Map<UserDto>(user);
    }

    private void ResetFailedLoginAttempts(string userName)
    {
        failedLoginAttempts.Remove(userName);
    }



}
