using System;
using System.Drawing;
using System.Windows.Forms;

namespace Product_Assignment
{
    public partial class POS : Form
    {
        private string userlogged;

        public POS() : this("Default User") { }
        public POS(string username)
        {
            InitializeComponent();
            InitializeDataGridView();
            DynamicUC();

            if (DgvCheckout == null)
            {
                MessageBox.Show("DgvCheckout is not initialized!");
            }
            DgvCheckout.CellClick += DgvCheckout_CellClick; // Register the event handler

            this.userlogged = username;
            // Set the label or textbox text to the username
            lblUserPOS.Text = username; // Assuming lblUsername is the name of your label
        }

        private void POS_Load(object sender, EventArgs e)
        {
            // Enable scrolling if more items are added
            FlowLayout.AutoScroll = true;

            DynamicUC();

        }

        private void DynamicUC(string searchKeyword = "")
        {
            FlowLayout.Controls.Clear();

            DynamicProduct[] listitem = new DynamicProduct[6];

            string[] names = new string[] {
    "SOFT FINISH SUN MILK",
    "REVIVE EYE SERUM",
    "BUBBLE LIP SCRUB",
    "HYALURONIC ACID \nCLEANSING FOAM",
    "DAYS MIRACLE SERUM",
    "MUGWORT PORE \nCLARIFYING WASH",
    "MOISTURIZER",
    "CENTELLA TONING\n TONER",
    "ROSEMARY MINT SCALP\n HAIR STRENGTHEN OIL"
};

            string[] prices = new string[] { "$14.00", "$14.99", "$6.00", "$9.99", "$10.00", "$2.5", "$13.50", "$17.00", "$19.00" };

            Image[] photo = {
                Properties.Resources.Sun_Screen,
                Properties.Resources.Eye_Serum,
                Properties.Resources.Lip_Scrub,
                Properties.Resources.Cleanser,
                Properties.Resources.Serum,
                Properties.Resources.Mask,
                Properties.Resources.Moistorizer,
                Properties.Resources.Toner,
                Properties.Resources.Rosemary_Mint_scalp
            };

            //FlowLayout.Controls.Add(listitem[i]);
            for (int i = 0; i < names.Length; i++)
            {
                // Apply the search filter here
                if (string.IsNullOrEmpty(searchKeyword) || names[i].IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    DynamicProduct item = new DynamicProduct
                    {
                        Name = names[i],
                        Price = prices[i],
                        Photo = photo[i]
                    };

                    item.AddToCartClicked += (s, e) =>
                    {
                        AddProductToCart(item.Name, item.Price);
                    };

                    FlowLayout.Controls.Add(item);
                }
            }
        }



        private void AddProductToCart(string productName, string productPrice)
        {
            // Ensure the product name and price are not null or empty
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productPrice))
            {
                MessageBox.Show("Product name or price is missing.");
                return;
            }

            // Remove any non-numeric characters for price, e.g., the dollar sign and trim spaces
            productPrice = productPrice.Replace("$", "").Trim();

            // Try parsing the cleaned price string to a decimal
            if (!decimal.TryParse(productPrice, out decimal price))
            {
                MessageBox.Show("Invalid price format. Please ensure the price is a numeric value.");
                return;
            }

            // Check each row to see if the product is already listed
            foreach (DataGridViewRow row in DgvCheckout.Rows)
            {
                if (row.Cells["Item"].Value != null && row.Cells["Item"].Value.ToString() == productName)
                {
                    if (int.TryParse(row.Cells["Qty"].Value?.ToString(), out int qty))
                    {
                        row.Cells["Qty"].Value = qty + 1; // Increment the quantity for existing product
                        UpdateRowTotal(row); // Update the total price for this row
                        UpdateGrandTotal(); // Update the grand total price
                        return;
                    }
                }
            }

            // Add new row if product not found in the DataGridView
            int index = DgvCheckout.Rows.Add();
            DgvCheckout.Rows[index].Cells["Item"].Value = productName;
            DgvCheckout.Rows[index].Cells["Qty"].Value = 1; // Start quantity at 1
            DgvCheckout.Rows[index].Cells["Price"].Value = price; // Use the parsed decimal value
            UpdateRowTotal(DgvCheckout.Rows[index]); // Update the total for this new row
            UpdateGrandTotal(); // Update the grand total price
        }

        private void UpdateRowTotal(DataGridViewRow row)
        {
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int quantity = Convert.ToInt32(row.Cells["Qty"].Value);
            row.Cells["Total"].Value = price * quantity;
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in DgvCheckout.Rows)
            {
                grandTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }
            // Update your grand total
            lblGrandTotal.Text = $"Grand Total :               ${grandTotal}";
        }

        private void InitializeDataGridView()
        {
            DgvCheckout.Columns.Add("Item", "Item");
            DgvCheckout.Columns.Add("Qty", "Qty");
            DgvCheckout.Columns.Add("Price", "Price");
            DgvCheckout.Columns.Add("Total", "Total");


            // Adding button columns
            var decreaseQtyButton = new DataGridViewButtonColumn();
            decreaseQtyButton.Name = "DecreaseQty";
            decreaseQtyButton.HeaderText = "";
            decreaseQtyButton.Text = "-";
            decreaseQtyButton.UseColumnTextForButtonValue = true; // apply the text to all rows
            DgvCheckout.Columns.Add(decreaseQtyButton);

            var removeButton = new DataGridViewButtonColumn();
            removeButton.Name = "Remove";
            removeButton.HeaderText = "";
            removeButton.Text = "X";
            removeButton.UseColumnTextForButtonValue = true;
            DgvCheckout.Columns.Add(removeButton);

            // Currency format
            DgvCheckout.Columns["Price"].DefaultCellStyle.Format = "c"; 
            DgvCheckout.Columns["Total"].DefaultCellStyle.Format = "c";

            // Optionally set column widths, etc.
        }

        private void DgvCheckout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid and within the bounds of the row count
            if (e.RowIndex >= 0 && e.RowIndex < DgvCheckout.Rows.Count)
            {
                // Handle Decrease Quantity Button Click
                if (e.ColumnIndex == DgvCheckout.Columns["DecreaseQty"].Index)
                {
                    int qty = Convert.ToInt32(DgvCheckout.Rows[e.RowIndex].Cells["Qty"].Value);
                    if (qty > 1)
                    {
                        DgvCheckout.Rows[e.RowIndex].Cells["Qty"].Value = qty - 1;
                        UpdateRowTotal(DgvCheckout.Rows[e.RowIndex]);
                    }
                    else
                    {
                        // Optionally remove the row if quantity reaches 1 and decrease button is clicked
                        DgvCheckout.Rows.RemoveAt(e.RowIndex);
                    }
                    UpdateGrandTotal();
                }
                // Handle Remove Button Click
                else if (e.ColumnIndex == DgvCheckout.Columns["Remove"].Index)
                {
                    DgvCheckout.Rows.RemoveAt(e.RowIndex);
                    UpdateGrandTotal();
                }
            }
        }
        private void CheckCartStatus()
        {
            bool hasItems = DgvCheckout.Rows.Count > 0;
            lblGrandTotal.Visible = hasItems;
             // Disable or hide other cart controls
        }

        #region SidebarAnimate

        bool Expand;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Expand)
            {
                Sidebar.Width -= 10;
                if (Sidebar.Width == Sidebar.MinimumSize.Width)
                {
                    Expand = false;
                    timer.Stop();
                    txtSearch.Visible = false;
                    SearchIcon.Visible = true;
                    lblWelcome.Visible = false;

                }
            }
            else
            {
                Sidebar.Width += 10;
                if (Sidebar.Width == Sidebar.MaximumSize.Width)
                {
                    txtSearch.Visible = true;
                    SearchIcon.Visible = false;
                    Expand = true;
                    timer.Stop();
                    lblWelcome.Visible = true;
                }
            }
        }


        private void MenuBtn_Click(object sender, EventArgs e)
        {
            timer.Start();
        }
        #endregion


        //Blur background while dialog product form
        private void BtnProduct_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            Product Model = new Product();
            using (Model)
            {
                background.StartPosition = FormStartPosition.Manual;
                background.FormBorderStyle = FormBorderStyle.None;
                background.Opacity = 0.7d;
                background.BackColor = Color.Black;
                background.Size = this.Size;
                background.Location = this.Location;
                background.ShowInTaskbar = false;
                background.Show(this);
                Model.Owner = background;
                Model.ShowDialog(background);
                background.Dispose();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // Assuming txtSearch is your TextBox where the search term is entered.
            string searchKeyword = txtSearch.Text.Trim();
            DynamicUC(searchKeyword);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchKeyword = txtSearch.Text.Trim();
                DynamicUC(searchKeyword);
            }
        }
    }
}
