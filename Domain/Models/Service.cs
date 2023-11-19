namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    
    public partial class Service : BaseModel
    {
        public Service()
        {
            ProvisionOfServices = new HashSet<ProvisionOfServices>();
        }
    
        public string Title { get; set; }
        public long Cost { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<ProvisionOfServices> ProvisionOfServices { get; set; }
    }
}
