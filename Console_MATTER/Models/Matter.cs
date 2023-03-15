using Console_MATTER.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MATTER.Models
{
    internal class Matter
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Department { get; set; } = string.Empty;
        public string MatterType { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public CaseStatus Status { get; set; } = CaseStatus.Open;
        public DateTime CreatedAt { get; set; }
    }
}
