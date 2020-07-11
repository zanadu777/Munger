using System.Collections.Generic;

namespace TextProcessing.Transforms
{
 public   class RemoveEmpty : StringTransform
    {
        public override List<string> Transform(string text)
        {
            var items = new List<string>();
            if (!string.IsNullOrWhiteSpace(text))
                items.Add(text);

            return items;
        }
    }
}
