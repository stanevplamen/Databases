using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClass.Models
{
    public class Material
    {
        public Material()
        {

        }

        [Key]
        public int MaterialId { get; set; }

        public string MaterialName { get; set; }

        public string Description { get; set; }
    }
}
