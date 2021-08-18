using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorAPI.Connection
{
    [ApiController]
    public class DbConnector :ControllerBase
    {

        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        

        public static MySqlConnection GetConnection()
        {

            MySqlConnection conn = new MySqlConnection();

            return conn;

        }


    }
}
