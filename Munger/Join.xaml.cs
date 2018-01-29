using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Munger.Extensions;
using Munger.Transforms;

namespace Munger
{
    /// <summary>
    /// Interaction logic for Join.xaml
    /// </summary>
    public partial class Join : UserControl
    {
        public Join()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var transforms = new List<StringTransform>();
            transforms.Add(new LineExtractor());
            transforms.Add(new RemoveEmpty());
            if (!string.IsNullOrWhiteSpace(txtRegex.Text))
            {
                var rxMatch = new RegexMatch();
                rxMatch.RegexString = txtRegex.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtRegexGroup.Text))
                {
                    var group = txtRegexGroup.Text.Trim();
                    int groupPosition;
                    var iSgroupNum = int.TryParse(group, out groupPosition);
                    if (iSgroupNum)
                        rxMatch.GroupPosition = groupPosition;
                    else
                        rxMatch.GroupName = group;
                }
                transforms.Add(rxMatch);
            }





            transforms.Add(new Trim());

            var items = transforms.Transform(txtSource.Text);



            var perLine = ToInt(txtPerline.Text);
            if (perLine.HasValue && perLine.Value > 0)
            {
                var bins = items.ToBins(perLine.Value);
                var  sb = new StringBuilder();
                foreach (var bin in bins)
                {
                    var text = StringJoin(bin, txtPrefix.Text, txtItemDelimiter.Text, txtSuffix.Text);
                    sb.AppendLine(text);
                }

                txtResults.Text = sb.ToString();
            }
            else
            {
                var text = StringJoin(items, txtPrefix.Text, txtItemDelimiter.Text, txtSuffix.Text);
                txtResults.Text = text;
            }




        }

        private string StringJoin(IEnumerable<string> enumerable, string itemprefix, string itemdelimiter, string itemSuffix)
        {
            var items = enumerable.ToList();
            if (!items.Any())
                return "";


            StringBuilder sb = new StringBuilder();
            var fAndR = new FirstAndRemainder<string>(items);
            sb.Append($"{itemprefix}{fAndR.First}{itemSuffix}");
            foreach (var item in fAndR.Remainder)
                sb.Append($"{itemdelimiter}{itemprefix}{item}{itemSuffix}");

            return sb.ToString();
        }

        private int? ToInt(string text)
        {
            int? intVal = null;

            if (int.TryParse(text, out var value))
                intVal = value;

            return intVal;
        }


    }
}
