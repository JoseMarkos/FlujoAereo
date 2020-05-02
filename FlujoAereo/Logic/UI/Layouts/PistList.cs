using FlujoAereo.Services;
using System;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class PistList : ControlParent
    {
        public PistList()
        {
            InitializeComponent();
        }


        private new void InitializeComponent()
        {
            panel.Controls.Add(panelChild);

            panel.Dock = DockStyle.Right;
            panel.Padding = new Padding(40, 0, 0, 20);
            panel.BackColor = colors.White1;

            // DAO

            PistDAO pistDAO = new PistDAO(Enums.Server.MariaDB);

            BindingSource bindingSource = new BindingSource
            {
                DataSource = pistDAO.GetAllPists()
            };

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = colors.White1,
                Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                SelectionBackColor = System.Drawing.Color.WhiteSmoke,
                SelectionForeColor = System.Drawing.Color.Black,
                WrapMode = System.Windows.Forms.DataGridViewTriState.False
            };

            // main controls
            AddElement(new FlatLabelTitle("Pists", 0, 0));
            AddElement(new FlatButton("Create Pist"));
            panelChild.Controls[1].Click += new EventHandler(GoToCreate);
            panelChild.Controls[1].Width = 200;

            AddElement(new DataGridView
            {
                Name = "dgvPists",
                DataSource = bindingSource,
                Width = 975,
                ForeColor = colors.Black1,

                DefaultCellStyle = dataGridViewCellStyle2,
                ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2,
                RowsDefaultCellStyle = dataGridViewCellStyle2,
                RowHeadersDefaultCellStyle = dataGridViewCellStyle2,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader,
                AutoSize = true,
                BackgroundColor = colors.White1,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                GridColor = System.Drawing.SystemColors.Control,
                RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None,
                MultiSelect = false,
                RowHeadersVisible = false,
                ReadOnly = true,
            });
        }

        private void GoToCreate(object sender, System.EventArgs e)
        {
            try
            {
                FlatPanel parentPanel = (FlatPanel)panel.Parent;
                Control toolbar = parentPanel.Controls[0];

                MenuSection menuController = new MenuSection(0);
                menuController.ShowPanel(Enums.ItemMenuType.CreatePist);

                PanelAdjustment();

                void PanelAdjustment()
                {
                    parentPanel.Controls[1].Dock = DockStyle.None;
                    toolbar.Controls[0].Width = parentPanel.Width;
                    parentPanel.Controls[1].Top = toolbar.Top + toolbar.Height;
                    parentPanel.Controls[1].Width = parentPanel.Width;
                    parentPanel.Controls[1].Height = parentPanel.Height - toolbar.Height;
                }
            }
            catch (Exception)
            {
                throw new OperationCanceledException("Wrong view.");
            }
        }
    }
}
