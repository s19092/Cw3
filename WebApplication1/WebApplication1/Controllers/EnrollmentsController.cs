using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;
using WebApplication1.NewFolder;
using WebApplication1.Requests;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase, IStudentsDbService
    {


        private string ConnectionString = "Data Source=db-mssql;Initial Catalog=s19092;Integrated Security=True";

       
        [HttpGet]
        public IActionResult getEnrollments()
        {
            EnrollStudentRequest e;

           
            return NotFound();

        }
      
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest req)
        {
            
            return Ok();
        }
    }
}