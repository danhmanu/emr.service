using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Domain.AggregatesModel.Patient
{
    public class emrpatient
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int siterf { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid patid { get; set; }

        public decimal patcode { get; set; }

        [Required]
        [StringLength(50)]
        public string hospcode { get; set; }

        [StringLength(50)]
        public string medicalcode { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(255)]
        public string fullname { get; set; }

        public int sex { get; set; }

        public int? ismarr { get; set; }

        public int yearbr { get; set; }

        public int? monthbr { get; set; }

        public int? daybr { get; set; }

        [StringLength(20)]
        public string paport { get; set; }

        public int? idnation { get; set; }

        public int? idjob { get; set; }

        public int? idethnic { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(100)]
        public string faname { get; set; }

        [StringLength(20)]
        public string facard { get; set; }

        public int active { get; set; }

        [StringLength(20)]
        public string usercr { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime timecr { get; set; }

        [StringLength(20)]
        public string userup { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }

        public string attributes { get; set; }
        public DateTime? hourminutebr { get; set; }
    }
}
