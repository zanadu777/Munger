using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munger
{
  public  class Comparer
    {
       public Comparer(IEnumerable<string> itemsA, IEnumerable<string> itemsB)
        {

            var HashA = new HashSet<String>(itemsA);
            var HashB = new HashSet<String>(itemsB);

            foreach (var item in HashB)
            {
                if (HashA.Contains(item))
                {
                    BothAandB.Add(item);
                }
                else
                {
                    OnlyB.Add(item);
                }
            }

            foreach (var item in HashA)
            {
                if (!HashB.Contains(item)) 
                   OnlyA.Add(item);

            }

            OnlyAorB.AddRange(OnlyA);
            OnlyAorB.AddRange(OnlyB);


            OnlyA.Sort();
            OnlyB.Sort();
            OnlyAorB.Sort();
            BothAandB.Sort();
        }

        public List<string> OnlyA { get;  } = new List<string>();
        public List<string> OnlyB { get;   } = new List<string>();
        public List<string> OnlyAorB { get;  } = new List<string>();
        public List<string> BothAandB { get; } = new List<string>();
    }
}
