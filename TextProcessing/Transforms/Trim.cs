using System.Collections.Generic;

namespace TextProcessing.Transforms
{
 public   class Trim:StringTransform
    {
        public override List<string> Transform(string text)
        {
            var items = new List<string>();
            items.Add(text.Trim());
            return items;
        }
       
    }
}
