using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Munger.ViewModels;

namespace Munger.DesignTime
{
  public static  class DesignTimeData
    {
        public static CompareVm CompareVm
        {
            get
            {
                var vm = new CompareVm();

                return vm;
            }
        }
    }
}
