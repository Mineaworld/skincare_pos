using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Product_Assignment
{
    public partial class DynamicProduct : UserControl
    {
        public event EventHandler ItemClicked; // Existing event
        public event EventHandler AddToCartClicked; // Event for cart button click

        public DynamicProduct()
        {
            InitializeComponent();
            this.Click += UserControl_Click;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += UserControl_Click;
                if (ctrl.Name == "BtnCart")  // Assuming the button's name is "BtnCart"
                {
                    ctrl.Click += BtnCart_Click;  // Subscribe to the click event of BtnCart
                }
            }
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            // Trigger the ItemClicked event
            ItemClicked?.Invoke(this, e);
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            // Trigger the AddToCartClicked event
            AddToCartClicked?.Invoke(this, e);
        }

        private Image ImageP;
        private string NameP;
        private string PriceP;

        [Category("Custom Props")]
        public Image Photo
        {
            get { return ImageP; }
            set { ImageP = value; ImageProduct.Image = value; } // Assuming ImageProduct is a PictureBox
        }

        [Category("Custom Props")]
        public string Name
        {
            get { return NameP; }
            set { NameP = value; NamePro.Text = value; } // Assuming NamePro is a Label
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return PriceP; }
            set { PriceP = value; PricePro.Text = value; } // Assuming PricePro is a Label
        }

        private void UpdateNameLabel()
        {
            // Make sure the label is set up to wrap text
            NamePro.AutoSize = false; // Allows the label to be manually sized
            NamePro.Height = 60; // Set the preferred height or calculate dynamically
            NamePro.Width = this.Width - 10; // Adjust width according to the parent control width
            NamePro.TextAlign = ContentAlignment.TopCenter; // Center-align the text
            //NamePro.WordWrap = true; // Enable word wrapping
        }

    }

}
