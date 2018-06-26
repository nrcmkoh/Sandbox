using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sprint0Sandbox.Data;

namespace Sprint0Sandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleVersionsController : Controller
    {
        private readonly OdsdbContext _db;

        public ModuleVersionsController(OdsdbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_db.Set<ModuleVersion>());
        }
    }
}