using FlujoAereo.Logic.UI;
using System.Drawing;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class Login : Controller
    {
        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SquareForm square = new SquareForm("Login");
            form = (Form)square;

            FlatPanel panelMain = new FlatPanel("main")
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.LightGray1,
                Padding = new Padding(1)
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

            FlatLabelTitle title = new FlatLabelTitle("Aeorpuerto XYZ", 0, 20);
            panelLogin.Controls.Add(title);

            FlatLabel user = new FlatLabel("User", 20, 70);
            panelLogin.Controls.Add(user);

            FlatLabel password = new FlatLabel("Password", 20, user.Location.Y + 40);
            panelLogin.Controls.Add(password);

            FlatPanel panelTxtName = new FlatPanel("Name")
            {
                AutoSize = true,
                AutoSizeMode = new AutoSizeMode(),
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.White1,
                Padding = new Padding(4)
            };

            panelTxtName.Location = new Point(password.Size.Width + 40, user.Location.Y);

            FlatTextBox txtName = new FlatTextBox("Name", 4, 4);
            panelTxtName.Controls.Add(txtName);

            panelLogin.Controls.Add(panelTxtName);
            

            FlatPanel panelTxtPassword = new FlatPanel("Password")
            {
                AutoSize = true,
                AutoSizeMode = new AutoSizeMode(),
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.White1,
                Padding = new Padding(4)
            };

            panelTxtPassword.Location = new Point(password.Size.Width + 40, password.Location.Y);

            FlatTextBox txtPassword = new FlatTextBox("Password", 4, 4);
            panelTxtPassword.Controls.Add(txtPassword);


            panelLogin.Controls.Add(panelTxtPassword);



            int positionX = centerElement.Horizontal(title.Size.Width, panelLogin.ClientSize.Width);
            title.Location = new System.Drawing.Point(positionX, title.Location.Y);


            // ...

            int panelMainPosiionY = centerElement.Vertical(panelMain.Size.Height, form.ClientSize.Height);
            int panelMainPosiionX = centerElement.Horizontal(panelMain.Size.Width, form.ClientSize.Width);

            panelMain.Location = new Point(panelMainPosiionX, panelMainPosiionY);
        }

        public Form GetForm()
        {
            return form;
        }
    }
}
