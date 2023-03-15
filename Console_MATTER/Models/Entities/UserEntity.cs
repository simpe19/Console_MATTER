using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Console_MATTER.Models.Entities
{

    internal class UserEntity
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;


        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;


        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }


        public ICollection<MatterEntity> Matter = new HashSet<MatterEntity>();
    }
}
