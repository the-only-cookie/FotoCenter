using Domain.Notify;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Base
{
    public class BaseModel : NotifyPropertyChangedObject
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
