using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationDocLab.Models
{
    public class Medicine_List
    {
        [Key]
        [Required(ErrorMessage = "ID is required.")]
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
        public DateTime Created_at { get; set; }
        public virtual Prescription Prescription { get; set; }

        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }

    }
}
