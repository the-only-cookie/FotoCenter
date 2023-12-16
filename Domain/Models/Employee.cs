namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee : BaseModel
    {
        public Employee()
        {
            ProvisionOfServices = new HashSet<ProvisionOfServices>();
        }


        [ForeignKey("User")]
        public override int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public long Experience { get; set; }
        public int PostId { get; set; }
        public int FotocenterId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProvisionOfServices> ProvisionOfServices { get; set; }
        public virtual Fotocenter Fotocenter { get; set; }
        public virtual Post Post { get; set; }
    }
}
