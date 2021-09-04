using Recording.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Database.Models
{
    public class recording_info:EntityBase
    {

        [Key]
        public Guid id { get; set; }

        [Required]
        [MaxLength(50)]
        public string title { get; set; }
        public string note { get; set; }

        public Recording_Type type { get; set; }

        public Guid user_id { get; set; }

    }
}
