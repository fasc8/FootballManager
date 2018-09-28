using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballManager
{
    class GoalInputPrompt
    {
        /// <summary>
        /// Clear Code is 878987
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text">Only for short messages up to 150 letters</param>
        /// <param name="preset1">Preset for the inputbox</param>
        /// <param name="preset2">Preset for the inputbox</param>
        /// <returns></returns>
        public static Tuple<int,int> ShowDialog(IWin32Window win, string caption, string text, int preset1 = 0, int preset2 = 0)
        {
            int value1 = 878987;
            int value2 = 878987;
            Form prompt = new Form();
            prompt.Width = 200 + 200 * text.Length / 75;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text ,TabIndex = 4, AutoSize = true };
            NumericUpDown inputBox1 = new NumericUpDown() { Left = 10, Top = 50, Width = 50, TabIndex = 0, Value = preset1};
            NumericUpDown inputBox2 = new NumericUpDown() { Left = 70, Top = 50, Width = 50, TabIndex = 1, Value = preset2};

            inputBox1.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    value1 = (int)inputBox1.Value;
                    value2 = (int)inputBox2.Value;
                    prompt.Close();
                }
            };
            inputBox2.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    value1 = (int)inputBox1.Value;
                    value2 = (int)inputBox2.Value;
                    prompt.Close();
                }
            };

            Button confirmation = new Button() { Text = "Ok", Left = 10, Top = 80 , TabIndex = 2};
            confirmation.Click += (sender, e) => {
                value1 = (int)inputBox1.Value;
                value2 = (int)inputBox2.Value;
                prompt.Close();
            };
            Button clear = new Button() { Text = "Clear", Left = 90, Top = 80, TabIndex = 3 };
            clear.Click += (sender, e) => {
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(clear);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox1);
            prompt.Controls.Add(inputBox2);
            prompt.ShowDialog(win);
            return new Tuple<int, int>(value1, value2);
        }
    }

    class TimeInputPrompt
    {
        /// <summary>
        /// For cancel the box item1 is <see cref="DateTime.MaxValue"/>
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text">Only for short messages up to 150 letters</param>
        /// <returns></returns>
        public static Tuple<DateTime, int> ShowDialog(IWin32Window win, string caption, string text)
        {
            DateTime value1 = DateTime.MaxValue;
            int value2 = 878987;
            Form prompt = new Form();
            prompt.Width = 200 + 200 * text.Length / 75;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text, TabIndex = 4, AutoSize = true };
            DateTimePicker timePicker = new DateTimePicker() { Left = 10, Top = 50, Width = 75, TabIndex = 0 };
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm";
            timePicker.ShowUpDown = true;
            NumericUpDown inputBox2 = new NumericUpDown() { Left = 95, Top = 50, Width = 50, TabIndex = 1, Value = 00 };
            timePicker.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    value1 = timePicker.Value;
                    value2 = (int)inputBox2.Value;
                    prompt.Close();
                }
            };
            inputBox2.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    value1 = timePicker.Value;
                    value2 = (int)inputBox2.Value;
                    prompt.Close();
                }
            };
            Button confirmation = new Button() { Text = "Ok", Left = 10, Top = 80, TabIndex = 2 };
            confirmation.Click += (sender, e) => {
                value1 = timePicker.Value;
                value2 = (int)inputBox2.Value;
                prompt.Close();
            };
            Button cancel = new Button() { Text = "Cancel", Left = 90, Top = 80, TabIndex = 3 };
            cancel.Click += (sender, e) => {
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(timePicker);
            prompt.Controls.Add(inputBox2);
            prompt.ShowDialog(win);
            return new Tuple<DateTime, int>(value1, value2);
        }
    }

    class TextInputPrompt
    {
        /// <summary>
        /// Clear Code is "-1"
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text">Only for short messages up to 150 letters</param>
        /// <param name="preset1">Preset for the inputbox</param>
        /// <returns></returns>
        public static string ShowDialog(IWin32Window win, string caption, string text, string preset1 = "")
        {
            string value1 = "-1";
            Form prompt = new Form();
            prompt.Width = 200 + 200 * text.Length / 75;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text, TabIndex = 4, AutoSize = true };
            TextBox inputBox1 = new TextBox() { Left = 10, Top = 50, Width = 180, TabIndex = 0, Text = preset1 };
            inputBox1.KeyUp += (sender, e) =>
            {
                if(e.KeyCode == Keys.Enter)
                {
                    value1 = inputBox1.Text;
                    prompt.Close();
                }
            };
            Button confirmation = new Button() { Text = "Ok", Left = 10, Top = 80, TabIndex = 2 };
            confirmation.Click += (sender, e) => {
                value1 = inputBox1.Text;
                prompt.Close();
            };
            Button cancel = new Button() { Text = "Cancel", Left = 90, Top = 80, TabIndex = 3 };
            cancel.Click += (sender, e) => {
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox1);
            prompt.ShowDialog(win);
            return value1;
        }
    }
}





