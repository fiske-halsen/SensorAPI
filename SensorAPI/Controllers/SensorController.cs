using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using SensorAPI.models;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SensorController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // GET: api/<SensorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"))) {

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(models.SampleData.Query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var model = new models.SampleData().Deserialize(rdr);
                        Console.WriteLine(model.SampleId);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();
                Console.WriteLine("Done.");


                return null;



            } ;
           

        }

        // GET api/<SensorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SensorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SensorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SensorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
