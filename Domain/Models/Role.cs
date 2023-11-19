namespace Domain.Models
{
    using Domain.Models.Base;
    using System.Collections.Generic;
    
    public partial class Role : BaseModel
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
    
        public string Title { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
