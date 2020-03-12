using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public abstract class Controller
    {
        protected CenterElement centerElement = new CenterElement();
        protected Form form = new Form();
        protected Colors colors = new Colors();

        protected abstract void InitializeComponent();

        public Form GetForm()
        {
            return form;
        }

        protected void Exit(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        protected void AddElement(Control element)
        {
            form.Controls.Add(element);

            if (form.Controls.Count == 1 & element.GetType().ToString() != "FlujoAereo.Logic.UI.FlatTextBoxAutoFocus")
            {
                element.Top = 40;
            }

            else if (form.Controls.Count == 2 & form.Controls[0].GetType().ToString() == "FlujoAereo.Logic.UI.FlatTextBoxAutoFocus")
            {
                element.Top = 40;
            }

            if (form.Controls.Count > 2)
            {
                int index = form.Controls.IndexOf(element);

                form.Controls[index].Top = form.Controls[index - 1].Top + form.Controls[index - 1].Height + 20;
            }
        }
    }
}
