using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Console_MATTER.Models.Entities
{
    public enum MatterStatus
    {
        Open,
        InProgress,
        Closed
    }
    [Index(nameof(Email), IsUnique = true)]
    internal class MatterEntity
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string Department { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string MatterType { get; set; } = string.Empty;

        [Required]
        public string Comment { get; set; } = string.Empty;

        public MatterStatus Status { get; set; } = MatterStatus.Open;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "DateTime")]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int UserID { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
