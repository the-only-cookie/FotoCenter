using Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public partial class User : BaseModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
