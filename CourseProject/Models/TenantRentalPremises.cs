using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models.Users;

namespace CourseProject.Models
{
    public class TenantRentalPremises
    {

        public int TenantRentalPremisesId { get; set; }

        public int TenantId { get; set; }

        public int RentalPremisesId { get; set; }

        public string FullName { get; set; }

        public int RentalNumber { get; set; }

        public string Adress { get; set; }
    }
}
