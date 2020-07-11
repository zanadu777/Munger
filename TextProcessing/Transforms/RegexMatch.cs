using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextProcessing.Transforms
{
    public class RegexMatch : StringTransform
    {
        private string groupName;
        private int? groupPosition;
        private Regex regex;
        private string regexString;

        public Regex Regex
        {
            get { return regex; }
            set
            {
                regex = value;
                regexString = null;
            }
        }

        public string RegexString
        {
            get { return regexString; }
            set
            {
                regexString = value;
                regex = new Regex(regexString);
            }
        }

        public bool GetAllMatches { get; set; } = true;

        public int? GroupPosition
        {
            get { return groupPosition; }
            set
            {
                groupPosition = value;
                groupName = null;
            }
        }

        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                groupPosition = null;
            }
        }

        public override List<string> Transform(string text)
        {
            List<string> items = new List<string>();

            if (GetAllMatches)
            {
                MatchCollection matches = regex.Matches(text);
                foreach (Match match in matches)
                    items.Add(MatchValue(match));
            }
            else
            {
                if (regex.IsMatch(text))
                {
                    Match match = regex.Match(text);
                    items.Add(MatchValue(match));
                }
            }

            return items;
        }


        private string MatchValue(Match match)
        {
            if (GroupPosition.HasValue)
                return match.Groups[GroupPosition.Value].Value;

            if (groupName != null)
                return match.Groups[groupName].Value;

            return match.Value;
        }
    }
}
