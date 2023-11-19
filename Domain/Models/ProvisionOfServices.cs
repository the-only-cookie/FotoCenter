using Domain.Models.Base;

namespace Domain.Models
{
    public partial class ProvisionOfServices : BaseModel
    {
        public string DateOfProvisionOfServices { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
    }
}
