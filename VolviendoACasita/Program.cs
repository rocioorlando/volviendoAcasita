using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Windows.Forms;
using VolviendoACasita.DataAccess.Repository;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using VolviendoACasita.DataAccess.DbInitializer;
using AutoMapper;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.UI;
using VolviendoACasita.Domain.Util;
using VolviendoACasita.Domain.Dto;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace VolviendoACasita
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<HomeForm>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var connectionString = configuration.GetConnectionString("DefaultConnection");

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new InvalidOperationException("The ConnectionString property has not been initialized.");
                    }

                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                        options.EnableSensitiveDataLogging();
                    });

                    MapperConfiguration config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<AutoMapperProfiles>();
                    });

                    IMapper mapper = config.CreateMapper();
                    services.AddSingleton(mapper);

                    services.AddHttpClient<GeoCodeService>((provider, client) =>
                    {
                        client.BaseAddress = new Uri("https://nominatim.openstreetmap.org");
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        client.DefaultRequestHeaders.UserAgent.ParseAdd("VolviendoACasita/1.0 (volviendoacasita2024@gmail.com)");
                    });

                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IEmailService, EmailService>();
                    services.AddScoped<ILostFoundFormService, LostFoundFormService>();
                    services.AddScoped<IAddressService, AddressService>();
                    services.AddScoped<IPetService, PetService>();
                    services.AddScoped<IArchivesService, ArchivesService>();
                    services.AddScoped<IRequestService, RequestService>();
                    services.AddScoped<IProvinceService, ProvinceService>();
                    services.AddScoped<ILocationService, LocationService>();
                    services.AddScoped<IAuthenticationService, AuthenticationService>();
                    services.AddScoped<ISpeciesService, SpeciesService>();
                    services.AddScoped<IBreedService, BreedService>();
                    services.AddScoped<IGeoCodeService, GeoCodeService>();

                    services.AddSingleton(provider =>
                    {
                        GMapControl gMapControl = new GMapControl();
                        gMapControl.MapProvider = GMapProviders.GoogleMap;
                        gMapControl.Dock = DockStyle.Fill;
                        gMapControl.Position = new GMap.NET.PointLatLng(-34.6037, -58.3816); // Buenos Aires, Argentina
                        gMapControl.MinZoom = 2;
                        gMapControl.MaxZoom = 18;
                        gMapControl.Zoom = 10;
                        return gMapControl;
                    });

                    services.AddScoped<UserDto>();
                    services.AddScoped<HomeForm>();
                    services.AddScoped<RegisterForm>();
                    services.AddScoped<LoginForm>();
                    services.AddSingleton<MapForm>();

                });
        }
    }
}
