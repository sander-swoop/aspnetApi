using System;
using System.Collections.Generic;

namespace dotaApi
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Localized_Name { get; set; }
        public string Primary_Attr { get; set; }
        public string Attack_Type { get; set; }
        public List<string> Roles { get; set; }
        public int Legs { get; set; }
    }
}
