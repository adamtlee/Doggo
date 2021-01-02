using doggo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace doggo.Controllers
{
    [ApiController]
    [Route("api/assignments")]
    public class AssignmentController : ControllerBase
    {
      [HttpGet]
      public IActionResult GetAssignments()
        {
            return Ok(true);
        }
    }
}
