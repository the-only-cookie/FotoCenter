namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Client : BaseModel
    {
        public Client()
        {
            ProvisionOfServices = new HashSet<ProvisionOfServices>();
        }

        [ForeignKey("User")]
        public override int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Adres { get; set; }
        public string PhoneNumber { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProvisionOfServices> ProvisionOfServices { get; set; }
    }
}
