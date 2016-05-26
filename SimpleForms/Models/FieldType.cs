using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForms.Models
{
    public class FormField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormId { get; set; }
        public FieldDataType DataType { get; set; }
        public bool Mandatory { get; set; }
        public virtual Form Form { get; set; }
        public virtual IEnumerable<FieldPrevalue> Prevalues { get; set; }
    }
}
