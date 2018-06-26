using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonDiffPatchDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sprint0Sandbox.Data;

namespace Sprint0Sandbox.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiffsController : Controller
    {
        private readonly OdsdbContext _db;

        public DiffsController(OdsdbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var doc1 = _db.Set<ModuleVersion>().Find(1).Document;   // one facility
            var doc2 = _db.Set<ModuleVersion>().Find(2).Document;   // two facilities
            var doc3 = _db.Set<ModuleVersion>().Find(3).Document;   // change timezone and facilitygroup of first facility

            // case 1: add facility
            // case 2: add 2 facilities
            // case 3: remove facility
            // case 4: edit facility

            // need to nest at least one more level

            // wrap this in jsondiffer type
            var jdp = new JsonDiffPatch();
            var diffStr = jdp.Diff(doc1, doc3);                   
            var jDiffs = JsonConvert.DeserializeObject<JObject>(diffStr); // diffStr contains an array where each delta set has a number key starting from 0

            var diffs = new List<Diff>();
            //var diffCount = 0;
            foreach (var jDiff in jDiffs.Children().Skip(1))
            {
                foreach (var jDiff2 in jDiff.Children<JObject>())
                {
                    diffs.AddRange(jDiff2.Properties().Select(p => new Diff
                    {
                        Field = p.Name,
                        Before = JsonConvert.SerializeObject(jDiff2[p.Name][0], Formatting.Indented),
                        After = JsonConvert.SerializeObject(jDiff2[p.Name][1], Formatting.Indented)
                    }));
                }
            }

            //while (jDiffs.(diffCount.ToString(), out JToken jDiff))
            //{
            //    var n = jDiff.Children<JObject>().SelectMany(jd => jd.Properties());
            //    var a = jDiff["FacilityGroup"][0];
            //    var b = jDiff["FacilityGroup"][1];


            //    diffCount++;
            //}

            //return Json(jDiffs);

            //var diffs = new List<dynamic>()
            //{
            //    JsonConvert.DeserializeObject(jdp.Diff(doc1, doc2)),
            //    JsonConvert.DeserializeObject(jdp.Diff(doc2, doc3)),
            //    JsonConvert.DeserializeObject(jdp.Diff(doc1, doc3))
            //};
            return Json(diffs);
        }
    }
}