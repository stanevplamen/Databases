using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseStructure.Enums;

namespace DatabaseStructure.Interfaces
{
    public interface IMusician
    {
        MusicStyle musicStyle
        {
            get;
            set;
        }
    }
}
