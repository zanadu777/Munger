using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munger
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
