using DatabaseStructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseStructure.Enums;
using DatabaseStructure.Interfaces;

namespace DatabaseStructure.Data
{
    public class Artist : Human, IMusician
    {
        public Artist() 
            : base()
        {
        }

        private MusicStyle musicstyle;
        public MusicStyle musicStyle
        {
            get
            {
                return this.musicstyle;
            }
            set
            {
                this.musicstyle = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.RealName, this.NickName);
        }
    }
}
