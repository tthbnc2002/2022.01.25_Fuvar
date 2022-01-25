using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022._01._25_Fuvar
{
    class Fuvar
    {
        public int TaxiID { get; set; }
        public string Indulas { get; set; }
        public int Idotartam { get; set; }
        public double Távolság { get; set; }
        public double Viteldíj { get; set; }
        public double Borravaló { get; set; }
        public string FizetésMód { get; set; }

        public Fuvar(string sor)
        {
            string[] t = sor.Split(';');
            TaxiID = int.Parse(t[0]);
            Indulas = t[1];
            Idotartam = int.Parse(t[2]);
            Távolság = double.Parse(t[3]);
            Viteldíj = double.Parse(t[4]);
            Borravaló = double.Parse(t[5]);
            FizetésMód = t[6];
        }
    }
}
