using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    /// <summary>
    /// Class ComboboxItem
    /// Model of an item from a combobox
    /// </summary>
    public class ComboBoxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }

        // Define how the information of the combobox must be displayed
        public override string ToString()
        {
            return Text;
        }
    }
}
