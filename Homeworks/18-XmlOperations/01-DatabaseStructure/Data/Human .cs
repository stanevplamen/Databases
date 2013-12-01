using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseStructure.Enums;
using DatabaseStructure.Interfaces;

namespace DatabaseStructure.Data
{
    public abstract class Human : IHuman
    {
        public Human(string realName, string nickName)
        {
            this.RealName = realName;
            this.NickName = nickName;
        }

        public Human()
        {
        }

        private string realName;
        public string RealName
        {
            get
            {
                return this.realName;
            }
            set
            {
                this.realName = value;
            }
        }

        private string nickName;
        public string NickName
        {
            get
            {
                return this.nickName;
            }
            set
            {
                this.nickName = value;
            }
        }
    }
}
