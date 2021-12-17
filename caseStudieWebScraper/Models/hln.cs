using System;

namespace caseStudieWebScraper.Models
{
    class hln : IEquatable<hln>, IComparable<hln>
    {
        public string Naam { get; set; }
        public string Plaats { get; set; }
        public string Beschrijving { get; set; }
        public string ALink { get; set; }

        public hln()
        {
        }

        public hln(string naam, string plaats, string beschrijving, string aLink)
        {
            Naam = naam;
            Plaats = plaats;
            Beschrijving = beschrijving;
            ALink = aLink;
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }

        public bool Equals(hln other)
        {
            return Naam == other.Naam;
        }

        public int CompareTo(hln other)
        {
            return Naam.CompareTo(other.Naam);
        }
    }
}
