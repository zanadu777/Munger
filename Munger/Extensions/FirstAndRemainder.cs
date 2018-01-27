using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munger.Extensions
{
  public  class FirstAndRemainder<T>
  {

      public FirstAndRemainder(IEnumerable<T> items)
      {
          var itemList = items.ToList();
          First = itemList[0];
          itemList.RemoveAt(0);
          Remainder = itemList;
      }
      public T First { get; private set; }
      public List<T> Remainder { get; private set; }
  }
}
