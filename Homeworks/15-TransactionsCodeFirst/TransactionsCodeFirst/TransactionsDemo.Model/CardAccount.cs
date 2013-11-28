using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionsDemo.Model
{
    public class CardAccount
    {
        public CardAccount()         
        {
        }

        [Key]
        public int CardAccountID { get; set; }

        public string CardNumber{ get; set; }

        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
