using System;
using System.Collections.Generic;
using System.Text;

namespace caseStudieWebScraper.Models
{
    class InD : IEquatable<InD>, IComparable<InD>
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Href { get; set; }

        public InD()
        {
        }

        public InD(string jobTitle, string company, string location, string href)
        {
            JobTitle = jobTitle;
            Company = company;
            Location = location;
            Href = href;
        }

        public override int GetHashCode()
        {
            return JobTitle.GetHashCode();
        }

        public bool Equals(InD other)
        {
            return JobTitle == other.JobTitle;
        }

        public int CompareTo(InD other)
        {
            return JobTitle.CompareTo(other.JobTitle);
        }
    }
}
