using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Models
 {    
     

    public partial class ProvisionOfServices : BaseModel
{
    public override int Id { get; set; }
    public DateTime DateOfProvisionOfServices { get; set; }
    public int ClientId { get; set; }
    public int EmployeeId { get; set; }
    public int ServiceId { get; set; }
    public virtual Client Client { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Service Service { get; set; }
}
}
