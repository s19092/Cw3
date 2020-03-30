using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;
using WebApplication1.NewFolder;
using WebApplication1.Requests;

namespace WebApplication1.Services
{


    
    interface IStudentsDbService
    {
        
        IActionResult EnrollStudent(EnrollStudentRequest req);



    }
}
