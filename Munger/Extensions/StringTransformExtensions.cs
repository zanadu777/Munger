using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Munger.Extensions
{
    public static class StringTransformExtensions
    {
        public static  List<string> Transform( this IEnumerable<StringTransform> transforms, string text)
        {
            var trans = transforms.ToList();
            var items = trans[0].Transform(text);
            trans.RemoveAt(0);
            foreach (var transform in trans)
                items = transform.Transform(items);

            return items;
        }
    }
}
