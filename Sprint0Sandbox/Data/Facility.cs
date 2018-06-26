using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint0Sandbox.Data
{
    public class OrgHierarchy
    {
        public IEnumerable<Facility> Facilities { get; set; }
    }

    public class Facility
    {
        public int CustomerId { get; set; }
        public int FacilityId { get; set; }
        public FacilityGroup FacilityGroup { get; set; }
        public string FacilityName { get; set; }
        public int? ConnectClientId { get; set; }
        public string CCN { get; set; }
        public string TimeZoneId { get; set; }

    }
    public class FacilityGroup {
        public int FacilityGroupId { get; set; }
        public string FacilityGroupName { get; set; }
        public int MyProperty { get; set; }
    }
}
