using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneRegister.WebAPI.Models
{
    public class AirplaneRegister
    {
        private AirplaneRegisterContext _ctx { get; set; }
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("AirplaneRegisterTypeId")]
        public int AirplaneTypeId { get; set; }
        
        [Required]
        [Column(TypeName = "int")]
        public int Capacity { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Created { get; set; }

        //TODO: Implementar ViewModel futuramente para preencher SelectLists
        public string AirplaneTypeName {
            get {
                if (_ctx != null)
                    return _ctx.AirplaneTypes.Where(x => x.AirplaneTypeId == this.AirplaneTypeId).FirstOrDefault().AirplaneTypeName;
                else
                    return "";
            }
        }

    }
}
