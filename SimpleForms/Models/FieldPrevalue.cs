using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForms.Models
{
    public class FieldPrevalue
    {
        public int Id { get; set; }
        public string String { get; set; }
        public int Int { get; set; }
        public int FieldTypeId { get; set; }
        public virtual FormField FieldType { get; set; }
    }
}
