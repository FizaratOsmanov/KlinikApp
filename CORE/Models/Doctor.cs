using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public  class Doctor:BaseEntity
    {
        public string  ImagePath { get; set; }

        public string Name { get; set; }

        public Department Department { get; set; }

        public int DepartmentId {  get; set; }
    }
}
