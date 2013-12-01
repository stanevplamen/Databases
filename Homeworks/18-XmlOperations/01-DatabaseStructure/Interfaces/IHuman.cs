using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStructure.Interfaces
{
    interface IHuman
    {
        string RealName
        {
            get;
            set;
        }

        string NickName
        {
            get;
            set;
        }
    }
}
