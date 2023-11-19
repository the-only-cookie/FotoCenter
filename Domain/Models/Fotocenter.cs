namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    
    public partial class Fotocenter : BaseModel
    {
        public Fotocenter()
        {
            Employee = new HashSet<Employee>();
        }
    
        public string Address { get; set; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
