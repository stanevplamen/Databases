using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseStructure.Interfaces;

namespace DatabaseStructure.Data
{
    public class Song : ISong
    {
        public Song()
        {
        }

        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private int seconds;
        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                this.seconds = value;
            }
        }
    }
}
