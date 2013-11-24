using EntityFrameModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo07
{
    class Inherit
    {
        public class ExtendedEmployee : Employee
        {
            public EntitySet<Territory> Territory { get; set; }
        }

        static void Main(string[] args)
        {
        }
    }
}
