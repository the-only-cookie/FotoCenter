namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    
    public partial class Category : BaseModel
    {
        public Category()
        {
            Service = new HashSet<Service>();
        }
    
        public string Title { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
