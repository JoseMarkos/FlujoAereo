using FlujoAereo.Enums;
using System;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatTextBox : TextBox
    {
        public FlatTextBox(string name, int x, int y)
        {
            BackColor = System.Drawing.Color.White;
            ForeColor = new Colors().LightGray1;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Location = new System.Drawing.Point(x, y);
            Margin = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(0, 21);
            Name = name;
            Size = new System.Drawing.Size(214, 21);
            Text = name;
            GotFocus += new EventHandler(NoSelect);
            GotFocus += new EventHandler(RemovePlaceHolder);
            Leave += new System.EventHandler(AddPlaceHolder);
            KeyUp += new KeyEventHandler(PasswordCharToggle);
            //TextChanged += new System.EventHandler(this.txtPlateNumber_TextChanged);
        }


        private void NoSelect(object sender, EventArgs e)
        {
            Select(0, 0);
        }

        private void AddPlaceHolder(object sender, System.EventArgs e)
        {
            if (Text == String.Empty)
            {
                Text = Name;
                ForeColor = new Colors().LightGray1;
            }
        }

        private void RemovePlaceHolder(object sender, EventArgs e)
        {
            if (Name == Text)
            {
                Text = "";
                ForeColor = new Colors().Black1;
            }
        }

        private void PasswordCharToggle(object sender, KeyEventArgs e)
        {
            if (Name == "Password")
            {
                UseSystemPasswordChar = true;
            }
        }
    }
}
