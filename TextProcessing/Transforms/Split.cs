using System.Collections.Generic;
using System.Linq;

namespace TextProcessing.Transforms
{
    public class Split : StringTransform
    {
        public char Seperator { get; set; }

        public override List<string> Transform(string text)
        {
            List<string> items = new List<string>();
            if (text.Contains(Seperator))
            {
                items.AddRange(text.Split(Seperator));
            }
            else
                items.Add(text);

            return items;
        }
    }
}
