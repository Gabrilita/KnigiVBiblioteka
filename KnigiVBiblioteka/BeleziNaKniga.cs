using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnigiVBiblioteka
{
    public class BeleziNaKniga:Kniga, IPrint
    {
        private string izdatelstvo;
        private int godina;
        private int nomer;

        public string Izdatelstvo
        {
            get { return izdatelstvo; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                this.izdatelstvo = value; 
            }
        }
        public int Godina
        { 
            get { return godina; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.godina = value; 
            }
        }
        public int Nomer
        {
            get { return nomer; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.nomer = value;
            }
        }

        public BeleziNaKniga(string zaglavie, string avtor, string izdatelstvo, int godina, int nomer)
            :base(zaglavie,avtor)
        {
            this.Izdatelstvo = izdatelstvo;
            this.Godina = godina;
            this.Nomer = nomer;
        }

        public override void AverageAge(List<BeleziNaKniga> list)
        {
            double averageAge = list.Average(x => x.Godina);
            Console.WriteLine($"Srednata vuzrast na knigite v bibliotekata e {averageAge} godini.");
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Izdatelstvo: {this.izdatelstvo}; Godina: {this.godina}; Nomer v kataloga:{this.nomer}");
        }
    }
}
