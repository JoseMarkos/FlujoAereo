using FlujoAereo.Services;
using System;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class FlightList : ControlParent
    {
        public FlightList()
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

            FlightDAO airlineDAO = new FlightDAO(Enums.Server.MariaDB);

            BindingSource bindingSource = new BindingSource
            {
                DataSource = airlineDAO.GetAllFlights()
            };

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = colors.White1;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;


            // main controls
            AddElement(new FlatLabelTitle("Flights", 0, 0));
            AddElement(new FlatButton("Create Flight plan"));
            panelChild.Controls[1].Click += new EventHandler(GoToCreateAsync);
            panelChild.Controls[1].Width = 200;

            AddElement(new DataGridView
            {
                Name = "dgvFlights",
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

        private async void GoToCreateAsync(object sender, System.EventArgs e)
        {
            try
            {
                FlatPanel parentPanel = (FlatPanel)panel.Parent;
                Control toolbar = parentPanel.Controls[0];

                MenuSection menuController = new MenuSection(0);
                await menuController.ShowPanelAsync(Enums.ItemMenuType.CreateFlightPlan);

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
