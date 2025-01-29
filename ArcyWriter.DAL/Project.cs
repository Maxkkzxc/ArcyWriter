using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcyWriter.DAL
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "Untitled Novel"; 

        public string Author { get; set; } = "Unknown Author"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
