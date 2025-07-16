using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivacyAssessment
{
    public class Confirmation
    {
        public static DialogResult ShowCustomYesNo(string message, string title, string yesText = "Yes", string noText = "No")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = message, Width = 340 };
            Button yesButton = new Button() { Text = yesText, Left = 80, Width = 100, Height=35, Top = 60, DialogResult = DialogResult.Yes };
            Button noButton = new Button() { Text = noText, Left = 200, Width = 100, Height = 35, Top = 60, DialogResult = DialogResult.No };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(yesButton);
            prompt.Controls.Add(noButton);
            prompt.AcceptButton = yesButton;
            prompt.CancelButton = noButton;

            return prompt.ShowDialog();
        }

    }
}
