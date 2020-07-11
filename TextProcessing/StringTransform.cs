using System.Collections.Generic;

namespace TextProcessing
{
   public  class StringTransform
    {
        public virtual List<string> Transform(string text)
        {
            var items = new List<string> { text};
            return items;
        }


        public virtual List<string> Transform(IEnumerable<string> texts)
        {
            var items = new List<string>();
            foreach (var item in texts)
                items.AddRange(Transform(item));

            return items;
        }
    }
}
