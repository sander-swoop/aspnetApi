using System;
using System.Collections.Generic;

namespace hotsApi
{
    public class Hero
    {
        public string Name { get; set; }
        public string Short_name { get; set; }
        public string Attribute_id { get; set; }
        public string C_hero_id { get; set; }
        public string C_unit_id { get; set; }
        public List<string> Translations { get; set; }
        public Dictionary<string, string> Icon_url { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public DateTime Release_date { get; set; }
        public string Release_patch { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Talent> Talents { get; set; }
        
    }
}
