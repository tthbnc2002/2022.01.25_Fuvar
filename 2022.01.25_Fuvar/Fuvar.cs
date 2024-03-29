﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_01_24_Fuvar
{
    class Fuvar
    {
        public int taxiAzonosito { get; set; }
        public string utazasIdopontja { get; set; }
        public int utazasIdotartama { get; set; }
        public double megtettTavolsag { get; set; }
        public double viteldij { get; set; }
        public double borravalo { get; set; }
        public string fizetesMod { get; set; }
        public Fuvar(string s)
        {
            string[] db = s.Split(';');
            taxiAzonosito = int.Parse(db[0]);
            utazasIdopontja = db[1];
            utazasIdotartama = int.Parse(db[2]);
            megtettTavolsag = double.Parse(db[3]);
            viteldij = double.Parse(db[4]);
            borravalo = double.Parse(db[5]);
            fizetesMod = db[6];
        }
    }
}