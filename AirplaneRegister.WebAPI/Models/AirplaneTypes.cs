using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneRegister.WebAPI.Models
{
    public class AirplaneTypes
    {
        [Key]
        public int AirplaneTypeId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string AirplaneTypeName { get; set; }
       
    }
}
