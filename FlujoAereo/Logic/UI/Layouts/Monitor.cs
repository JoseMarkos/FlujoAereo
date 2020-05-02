using FlujoAereo.Logic.Tasks;
using FlujoAereo.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class Monitor : ControlParent
    {
        public void InitializeComponentAsync()
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

            AddElement(new DataGridView
            {
                Name = "dgvAirports",
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

            FlatButton btnWatch = new FlatButton("Watch");
            btnWatch.Click += RefreshDGVEvent;

            AddElement(btnWatch);
        }

        public void RefreshDGVTwo()
        {
            DataGridView dta = (DataGridView)panelChild.Controls[0];
            RefreshDGV(ref dta);
        }

        public void RefreshDGV(ref DataGridView data)
        {
            data.Refresh();
        }

        public async void RefreshDGVEvent(object sender, EventArgs e)
        {
            Watcher test = new Watcher();

            await Task.WhenAll(test.WaitFlightTimeAsync());
        }

        public void RefreshD()
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000)
            {
                AutoReset = true
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshDGVEvent);
            timer.Start();
        }
    }
}
