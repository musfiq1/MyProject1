using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Models
{
    public class Setting
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile Logofile { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Imagefile { get; set; }

        [Required, MaxLength(30)]
        public string Address { get; set; }
        [Required, MaxLength(30)]
        public string Email { get; set; }
        [Required, MaxLength(30)]
        public string Phone { get; set; }
        [Required, MaxLength(200)]
        public string Information { get; set; }
    }
}
