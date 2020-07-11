using System.Collections.Generic;

namespace TextProcessing.Transforms
{
   public   class Unique : StringTransform
    {
        public override List<string> Transform(IEnumerable<string> texts)
        {
            var uniqueStrings = new HashSet<string>();
            var items = new List<string>();

            foreach (var text in texts)
            {
               if(! uniqueStrings.Contains(text))
               {
                    items.Add(text);
                    uniqueStrings.Add(text);
               }
            }
            return items;
        }
    }
}
