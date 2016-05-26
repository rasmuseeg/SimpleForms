using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForms.Models
{
    public class UserFieldValue
    {
        public int Id { get; set; }
        public string String { get; set; }
        public Nullable<int> Numeric { get; set; }
        public int UserFieldId { get; set; }
        public virtual UserField UserField { get; set; }
    }
}
