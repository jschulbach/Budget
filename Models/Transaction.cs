using System;
using System.ComponentModel.DataAnnotations;

namespace Budget.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float Amount { get; set; }   
        public int AccountID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PayeeID { get; set; }

        public Account Account { get; set; }
        public Payee Payee { get; set; }
    }
}