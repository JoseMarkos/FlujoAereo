using FlujoAereo.Logic.Tasks;
using FlujoAereo.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class Monitor : ControlParent
    {
        public async Task InitializeComponentAsync()
        {
            panel.Controls.Add(panelChild);

            panel.Dock = DockStyle.Right;
            panel.Padding = new Padding(40, 0, 0, 20);
            panel.BackColor = colors.White1;


            // DAO
            AirportDAO airportDAO = new AirportDAO(Enums.Server.MariaDB);

            BindingSource bindingSource = new BindingSource
            {
                DataSource = airportDAO.GetAllAirports()
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

            Test test = new Test();


            await test.CountHour(new TimeSpan(0, 0, 2));

            MessageBox.Show("wth");
        }

    }
}
