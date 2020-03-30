using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Requests
{
    public class EnrollStudentRequest
    {

        public string IndexNumber { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthTime { get; set; }
        public String Studies { get; set; }


    }

}
