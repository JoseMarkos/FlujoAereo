using FlujoAereo.Enums;
using FlujoAereo.Logic.UI;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System.Drawing;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class Login : Controller
    {
        private FlatButton button;

        public Login()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            SquareForm square = new SquareForm("Login");
            form = (Form)square;
            form.Height = 599;
            form.Width = 750;

            Panel panel = new Panel
            {
                Name = "logo",
                BackgroundImageLayout = ImageLayout.Center,
                BackgroundImage = Image.FromFile("logo.jpg"),
                Width = 400,
                Height = 400
            };

            form.Controls.Add(panel);

            FlatPanel panelMain = new FlatPanel("main")
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.LightGray1,
                Padding = new Padding(1),
                Left = panel.Width,
            };

            form.Controls.Add(panelMain);


            FlatPanel panelLogin = new FlatPanel("main")
            {
                AutoSize = true,
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.LighterGray1,
                Padding = new Padding(20),
                Location = new Point(1, 1)
            };

            panelMain.Controls.Add(panelLogin);


            // Don't touch in order to don't mess the center alignment

            FlatLabelTitle title = new FlatLabelTitle("Sign in", 0, 20);
            panelLogin.Controls.Add(title);


            FlatPanel panelTxtName = new FlatPanel("Name")
            {
                AutoSize = true,
                AutoSizeMode = new AutoSizeMode(),
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.White1,
                Padding = new Padding(4)
            };

            panelTxtName.Location = new Point(20, 70);

            FlatTextBox txtName = new FlatTextBox("Name", 4, 4);

            panelTxtName.Controls.Add(txtName);
            panelLogin.Controls.Add(panelTxtName);


            FlatPanel panelTxtPassword = new FlatPanel("Password")
            {
                AutoSize = true,
                AutoSizeMode = new AutoSizeMode(),
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.White1,
                Padding = new Padding(4),
            };

            panelTxtPassword.Location = new Point(20, 110);

            FlatTextBox txtPassword = new FlatTextBox("Password", 4, 4);

            panelTxtPassword.Controls.Add(txtPassword);


            panelLogin.Controls.Add(panelTxtPassword);

            button = new FlatButton("Log in");
            panelLogin.Controls.Add(button);


            button.Width = panelTxtName.Width;
            button.Location = new Point(20, button.Parent.Height + 20);
            button.Click += new System.EventHandler(TryLogin);

            panelLogin.Height += button.Height + 30;

            int positionX = centerElement.Horizontal(title.Size.Width, panelLogin.ClientSize.Width);
            title.Location = new System.Drawing.Point(positionX, title.Location.Y);

            panelMain.Top = centerElement.Vertical(panelMain.Height, form.ClientSize.Height);

            panelLogin.Controls.Add(
                   new FlatLabelError("Oops! It looks like you may have forgotten your password.", 0, button.Height + 30)
                   {
                       Dock = DockStyle.Bottom,
                       MaximumSize = new Size(panelLogin.Width - 40, 0),
                       Visible = false
                   }
              );
        }

        private void TryLogin(object sender, System.EventArgs e)
        {
            FlatPanel panelName = (FlatPanel)form.Controls[1].Controls[0].Controls[1];
            FlatPanel panelPass = (FlatPanel)form.Controls[1].Controls[0].Controls[2];

            int index = panelName.Controls.IndexOfKey("Name");
            int indexPass = panelPass.Controls.IndexOfKey("Password");

            Usuario user = new Usuario
            {
                ID = 0,
                Name = panelName.Controls[index].Text,
                Password = form.Controls[1].Controls[0].Controls[2].Controls[indexPass].Text
            };

            UserDAO userDAO = new UserDAO(Server.MariaDB);

            if (userDAO.GetPassword(user.Name) == user.Password)
            {

                Views views = new Views();

                views.dictionary[userDAO.GetRole(user.Name)].Show();
                form.Hide();
            }

            else
            {
                panelName.Parent.Controls[panelName.Parent.Controls.Count - 1].Visible = true;
            }
        }
    }
}
