namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    
    public partial class Post : BaseModel
    {
        public Post()
        {
            Employee = new HashSet<Employee>();
        }

        public string Title { get; set; }
        public long Salary { get; set; }
        public string WorkSchedule { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
