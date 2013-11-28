using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionsDemo.Model
{
    public class TransactionHistory
    {
        private ICollection<TransactionInfo> transactionsList;

        public TransactionHistory()
        {
            this.transactionsList = new HashSet<TransactionInfo>();
        }

        [Key]
        public int THistoryId { get; set; }

        public string THistoryName { get; set; }

        public virtual ICollection<TransactionInfo> TransactionsList
        {
            get { return this.transactionsList; }
            set { this.transactionsList = value; }
        }
    }
}
