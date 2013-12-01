using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStructure.Interfaces
{
    public interface ISong
    {
        string Title
        {
            get;
            set;
        }

        int Seconds
        {
            get;
            set;
        }
    }
}
