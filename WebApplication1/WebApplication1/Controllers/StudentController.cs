using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.NewFolder;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IDbService _dbService;

        public StudentController(IDbService dbService)
        {
            _dbService = dbService;

        }
        [HttpGet]
        public IActionResult getStudents(String orderBy)
        {
            var list = new List<Student>();
            string querry = "select * from student";
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19092;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = querry;

                connection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    var st = new Student();
                    st.IdEnrollment = Int32.Parse(dataReader["idenrollment"].ToString());
                    st.IndexNumber = (dataReader["indexnumber"].ToString());
                    st.FirstName = dataReader["FirstName"].ToString();
                    st.BirbDate = dataReader["BirthDate"].ToString();
                    st.LastName = dataReader["LastName"].ToString();
                    
                    list.Add(st);
                }

            }
            return Ok(list);

        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

            student.IndexNumber = $"s{new Random().Next(1,2000)}";
            return Ok(student);

        }
        
        [HttpPut("{id}")]
        public IActionResult putStudent(int id)
        {
            return Ok("Update succeed " + id);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        {
            return Ok("Delete succeed " + id);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult getStudent(string indexNumber)
        {
            var list = new List<Enrollment>();

            string querry = "select * from enrollment e inner join student s on e.idenrollment = s.idenrollment where s.IndexNumber = @index;";
          
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19092;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = querry;

                command.Parameters.AddWithValue("index", indexNumber);

                connection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    var en = new Enrollment();
                    en.IdEnrollment = Int32.Parse(dataReader["idenrollment"].ToString());
                    en.StartDate = dataReader["Semester"].ToString();
                    en.IdStudy = Int32.Parse(dataReader["IdStudy"].ToString());
                    en.StartDate = dataReader["startDate"].ToString();
                    
                    list.Add(en);
                }

            }
            return Ok(list);
      
        }

       
    }

}