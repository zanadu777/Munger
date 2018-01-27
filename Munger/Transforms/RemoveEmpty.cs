using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munger.Transforms
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
