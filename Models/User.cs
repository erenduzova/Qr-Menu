using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QrMenu.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";

        [StringLength(100, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";
        public byte StateId { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
    }
}
