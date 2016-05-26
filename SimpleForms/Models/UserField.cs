using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForms.Models
{
    public class UserField
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FieldId { get; set; }
        public virtual FormField Field { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<UserFieldValue> FieldValues { get; set; }
    }
}
