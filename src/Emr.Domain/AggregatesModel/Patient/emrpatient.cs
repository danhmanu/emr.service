using Emr.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Domain.AggregatesModel.Patient
{
    public class emrpatient : IAggregateRoot
    {
        [Key()]
        [Column(Order = 0)]
        public int siterf { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid patid { get; set; }

        public decimal patcode { get; set; }

        public string hospcode { get; set; }

        public string medicalcode { get; set; }

        public string lastname { get; set; }
        public string firstname { get; set; }

        public string fullname { get; set; }

        public int sex { get; set; }

        public int? ismarr { get; set; }

        public int yearbr { get; set; }

        public int? monthbr { get; set; }

        public int? daybr { get; set; }

        public string paport { get; set; }

        public int? idnation { get; set; }

        public int? idjob { get; set; }

        public int? idethnic { get; set; }
        public string email { get; set; }

        public string phone { get; set; }

        public string faname { get; set; }

        public string facard { get; set; }

        public int active { get; set; }

        public string usercr { get; set; }
        public DateTime timecr { get; set; }
        public string userup { get; set; }

        public DateTime timeup { get; set; }
        public string computer { get; set; }

        public string attributes { get; set; }
    }
}
