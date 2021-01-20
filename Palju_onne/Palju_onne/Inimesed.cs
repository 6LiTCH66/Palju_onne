using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Palju_onne
{
    public class Inimesed
    {
        public List<Nimed> NimedList { get; set; }

        public Inimesed()
        {
            NimedList = GetNimed().OrderBy(t => t.Names).ToList();
        }
        public List<Nimed> GetNimed()
        {
            var names = new List<Nimed>()
            {
                new Nimed() {Email = "ilja200303@gmail.com", Names = "Ilja"},
                new Nimed() {Email = "andrej@gmail.com", Names = "Andrej"},
                new Nimed() {Email = "mark@gmail.com", Names = "Mark"},
                new Nimed() {Email = "eric@gmail.com", Names = "Eric"},

            };

            return names;
        }
    }

    public class Nimed
    {
        public string Email { get; set; }
        public string Names { get; set; }
    }
}