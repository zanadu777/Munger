using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Munger.Extensions;
using Munger.ViewModels;
using TextProcessing;
using TextProcessing.Extensions;
using TextProcessing.Transforms;

namespace Munger
{
    /// <summary>
    /// Interaction logic for Compare.xaml
    /// </summary>
    public partial class Compare : UserControl
    {
        public Compare()
        {
            InitializeComponent();
            this.DataContext = new CompareVm();
        }

        private void btCompare_Click(object sender, RoutedEventArgs e)
        {
          var txtA=   txtSetA.Text;
            var transA = new List<StringTransform>();
            transA.Add(new LineExtractor());
            transA.Add(new RemoveEmpty());
            var lstA = transA.Transform(txtA);

            var txtB = txtSetB.Text;

            var transB = new List<StringTransform>();
            transB.Add(new LineExtractor());
            transB.Add(new RemoveEmpty());
            transB.Add(new Split {Seperator = ';'});
            var lstB = transB.Transform(txtB);
        }
    }
}
