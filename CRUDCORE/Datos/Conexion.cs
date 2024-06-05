﻿using System.Data.SqlClient;

namespace CRUDCORE.Datos
{
    public class Conexion
    {

        private String cadenaSQL = String.Empty;

        public Conexion() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;

        }

        public string getCadenaSQL()
        {

            return cadenaSQL;
            
        }

    }
}