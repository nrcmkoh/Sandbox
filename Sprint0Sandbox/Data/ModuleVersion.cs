using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint0Sandbox.Data
{
    public class ModuleVersion
    {
        public int ModuleVersionId { get; set; }
        public int VersionNumber { get; set; }
        public int CustomerId { get; set; }
        public string ModuleName { get; set; }
        public bool Activated { get; set; }
        public string Document { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
