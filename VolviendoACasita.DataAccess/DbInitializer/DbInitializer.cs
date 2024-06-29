using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;

namespace VolviendoACasita.DataAccess.DbInitializer
{
    //se usa para asegurarse de que la base de datos esté
    //configurada correctamente al aplicar migraciones
    //pendientes y pueda manejar la configuración
    //inicial de roles y usuarios para la aplicación
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            return;
        }
    }
}
