using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Models.Model
{
    public class Student
    {
        public int Student_ID { get; set; }
        public string Broj_Indeksa {get; set;}
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godina { get; set; }
        public int Status_Studenta { get; set; }
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<Kurs> Kursevi { get; set; }
    }
}
