using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Review : Document
    {
        [Required]
        [MaxLength(500)]
        public string content { get; set; }

        [Required]
        [MaxLength(50)]
        public string title { get; set; }

        [Required]
        [MaxLength(1)]
        public int star { get; set; }

        [Required]
        public ReviewStatus status { get; set; }
        public string rejectReason { get; set; }
        public Guid operatedBy { get; set; }

        [ForeignKey(nameof(user))]
        [Required]
        public Guid userId { get; set; }
        public User user { get; set; }

    }
}
