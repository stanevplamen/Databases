using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionsDemo.Model
{
    public class TransactionInfo
    {
        //(Id, CardNumber, TransactionDate, Ammount)

        public TransactionInfo()         
        {
            TransactionDate = DateTime.Now;
        }

        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("CardAccount")]
        public int CardAccountId { get; set; }
        public virtual CardAccount CardAccount { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Ammount { get; set; }
    }
}
