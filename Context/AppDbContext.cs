using Microsoft.EntityFrameworkCore;
using netcore_api_example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_api_example.Context
{
    public class AppDbContext :DbContext
    {
        //Contructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
        }

        /**
         *Representacion de la tabla: Importamos el  modelo
         *Se tiene que llamar igual que la base de datos
         */
        public DbSet<Gestores_Bd> gestores_bd { get; set; }
    }
}
