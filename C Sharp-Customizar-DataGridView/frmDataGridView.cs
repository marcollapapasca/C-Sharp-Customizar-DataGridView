using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace C_Sharp_Customizar_DataGridView
{
    public partial class frmDataGridView : Form
    {
        public frmDataGridView()
        {
            InitializeComponent();
        }

        private void frmDataGridView_Load(object sender, EventArgs e)
        {
            /* Habilitar el cambio de tamaño en los encabezados de columna */
            dtgNorthwind.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            /* Ajustamos el alto para la columna cabecera */
            dtgNorthwind.ColumnHeadersHeight = dtgNorthwind.ColumnHeadersHeight * 4;

            /* Ajuste la alineación del texto en los encabezados de las  
               columnas para que la visualización de texto en el centro de la parte inferior */
            dtgNorthwind.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;


            conectar_sql();
        }


        private void dtgNorthwind_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                String rows = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(rows, this.Font);

                if (dtgNorthwind.RowHeadersWidth < (size.Width + 20))
                {
                    dtgNorthwind.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                }
                Brush brush = SystemBrushes.ControlText;
                e.Graphics.DrawString(rows, this.Font, brush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "C# - Customizar DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void conectar_sql()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connetionString = "Data Source=DESKTOP-06LHNBE\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            sql = "  " +
                "   select cust.CustomerID, cust.ContactName,cust.ContactTitle, cust.Phone, " +
                "    ord.OrderID, ord.OrderDate, ord.RequiredDate, ord.ShippedDate, " +
                "    prod.ProductName, ord_d.UnitPrice, ord_d.Quantity, ord_d.Discount  " +
                "    from dbo.Customers cust inner join dbo.Orders ord  " +
                "    on cust.CustomerID = ord.CustomerID inner join dbo.[Order Details] ord_d  " +
                "    on ord.OrderID = ord_d.OrderID inner join dbo.Products prod  " +
                "    on prod.ProductID = ord_d.ProductID  " +
                " ";

            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                dtgNorthwind.DataSource = dt;


                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void dtgNorthwind_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                /* Datos para las celdas de cabezera */
                String[] groupBy = { "Customers", "Orders", "Order Details" };

                SolidBrush br;
                Pen p;

                for (int i = 0; i < dtgNorthwind.ColumnCount - 1; i += 4)
                {
                    /* Obtener los límites de encabezado de columna  */
                    Rectangle r1 = dtgNorthwind.GetCellDisplayRectangle(i, -1, true);
                    r1.X += 1;
                    r1.Y += 1;
                    r1.Width = r1.Width * 4 - 4;
                    r1.Height = r1.Height / 2 - 2;

                    br = new SolidBrush(dtgNorthwind.ColumnHeadersDefaultCellStyle.BackColor);
                    e.Graphics.FillRectangle(br, r1);

                    p = new Pen(SystemColors.InactiveBorder);
                    e.Graphics.DrawLine(p, r1.X, r1.Bottom, r1.Right, r1.Bottom);

                    StringFormat format = new StringFormat();

                    br = new SolidBrush(dtgNorthwind.ColumnHeadersDefaultCellStyle.ForeColor);
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(groupBy[i / 4], dtgNorthwind.ColumnHeadersDefaultCellStyle.Font, br, r1, format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "C# - Customizar DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 


        private void dtgNorthwind_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                String ContactTitle = "";
                String TextBackcolor = "";

                /* Indica de cual columna deseo dar formato de celda*/
                if (dtgNorthwind.Columns[e.ColumnIndex].Name.Equals("ContactTitle"))
                {
                    if (e.RowIndex < dtgNorthwind.RowCount - 1)
                    {
                        /* Captura el valor de la celda */
                        ContactTitle = dtgNorthwind.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                        e.CellStyle.BackColor = Color.WhiteSmoke;

                        if (ContactTitle.Equals("Owner"))
                        {
                            e.CellStyle.ForeColor = Color.Green;
                        }
                        else if (ContactTitle.Equals("Accounting Manager"))
                        {
                            e.CellStyle.ForeColor = Color.Tomato;
                        }
                        else if (ContactTitle.Equals("Marketing Manager"))
                        {
                            e.CellStyle.ForeColor = Color.DarkCyan;
                        }
                        else if (ContactTitle.Equals("Sales Agent"))
                        {
                            e.CellStyle.ForeColor = Color.Blue;
                        }
                    }
                }

                if (dtgNorthwind.Columns[e.ColumnIndex].Name.Equals("UnitPrice") ||
                    dtgNorthwind.Columns[e.ColumnIndex].Name.Equals("Quantity") ||
                    dtgNorthwind.Columns[e.ColumnIndex].Name.Equals("Discount")
                    )
                {
                    if (e.RowIndex < dtgNorthwind.RowCount - 1)
                    {

                        // Captura el valor de la celda 
                        TextBackcolor = dtgNorthwind.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                        if (TextBackcolor.Equals("0"))
                        {
                            e.CellStyle.BackColor = Color.MistyRose;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.LemonChiffon;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "C# - Customizar DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
