using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForms.Models
{
    public class Form
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<FormField> Fields{ get; set; }
    }
}
