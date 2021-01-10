using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Models
{
    public class DogForCreationDto
    {
        [Required(ErrorMessage = "Name Cannot be blank.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(25)]
        public string ShortName { get; set; }
        public string Birth { get; set; }
        public string Breed { get; set; }
    }
}
