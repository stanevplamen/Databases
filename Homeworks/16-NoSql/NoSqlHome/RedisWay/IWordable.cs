using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisWay
{
    interface IWordable
    {
        string ActualWord { get; set; }
        string Explanation { get; set; }
    }
}
