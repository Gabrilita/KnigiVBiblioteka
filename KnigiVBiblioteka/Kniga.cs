using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnigiVBiblioteka
{
    public abstract class Kniga:IPrint
    {
        private string zaglavie;
        private string avtor;

        public string Zaglavie
        {
            get { return zaglavie; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                this.zaglavie = value;
            }
        }
        public string Avtor
        {
            get { return avtor; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                this.avtor = value;
            }
        }

        public Kniga(string zaglavie, string avtor) 
        {
            this.Zaglavie = zaglavie;
            this.Avtor = avtor;
        }
        public abstract void AverageAge(List<BeleziNaKniga> list);
        public virtual void Print()
        {
            Console.Write($"Kniga: {this.Zaglavie}; Avtor: {this.Avtor}; ");
        }
    }
}
