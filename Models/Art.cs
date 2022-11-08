using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Dev_Project.Models
{
    public class Art
    {
        [Required]
        public string PieceName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Id { get; set; }

    }
}
