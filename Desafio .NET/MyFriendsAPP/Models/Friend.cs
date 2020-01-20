using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFriendsAPP.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [Display(Name = "País")]
        public string Pais { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Display(Name = "Distancia (M - Em Metros)")]
        public int Distancia { get; set; }
        
    }
}
