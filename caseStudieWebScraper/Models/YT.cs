using System;

namespace caseStudieWebScraper.Models
{
    class YT : IEquatable<YT>, IComparable<YT>
    {
        public string Title { get; set; }
        public string Uploader { get; set; }
        public string View { get; set; }
        public string Link { get; set; }

        public YT()
        {
        }

        public YT(string title, string uploader, string view, string link)
        {
            Title = title;
            Uploader = uploader;
            View = view;
            Link = link;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }

        public bool Equals(YT other)
        {
            return Title == other.Title;
        }

        public int CompareTo(YT other)
        {
            return Title.CompareTo(other.Title);
        }
    }
}
