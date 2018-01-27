using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Munger.Extensions
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
