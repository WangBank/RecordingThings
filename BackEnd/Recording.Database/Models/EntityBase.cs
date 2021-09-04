using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Database.Models
{
    public abstract class EntityBase
    {
        [Required]
        public virtual bool Is_Deleted { get; set; } = false;

        [Required]
        public virtual DateTime Created_Time { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public virtual string Created_By { get; set; }


        public virtual DateTime? Updated_Time { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public virtual string Updated_By { get; set; }
    }
}
