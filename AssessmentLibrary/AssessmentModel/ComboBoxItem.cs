using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    public class ComboBoxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }
        public string Alias { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
