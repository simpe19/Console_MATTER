using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MATTER.Models.Entities
{
    internal class ClosedMatterEntity
    {

        [Column(TypeName = "nvarchar(50)")]
        public string Department { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string MatterType { get; set; } = string.Empty;

        public MatterStatus Status { get; set; } = MatterStatus.Closed;

        public ICollection<MatterEntity> Matter = new HashSet<MatterEntity>();
    }
}
