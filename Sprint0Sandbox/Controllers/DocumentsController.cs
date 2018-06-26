using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonDiffPatchDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sprint0Sandbox.Data;

namespace Sprint0Sandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : Controller
    {
        private readonly OdsdbContext _db;

        public DocumentsController(OdsdbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var docs = _db.Set<ModuleVersion>()
                          .Select(mv => JsonConvert.DeserializeObject<OrgHierarchy>(mv.Document));
            return Json(docs);
        }
    }
}