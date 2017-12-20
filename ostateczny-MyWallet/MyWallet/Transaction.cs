using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet
{
    class Transaction
    {
        private DateTime data;
        private string kategoria;
        private int kwota;
        
        public DateTime Data { get => data; set => data = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public int Kwota { get => kwota; set => kwota = value; }
    }
}
