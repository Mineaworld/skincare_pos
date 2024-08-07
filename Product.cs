using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Product_Assignment
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        POS_dbDataContext DB_POS = new POS_dbDataContext();

        private void BindData()
        {
            DgvProduct.DataSource = null;
            DgvProduct.DataSource = DB_POS.tblProducts.ToList();
            DgvProduct.Columns["id"].Visible = false;
            DgvProduct.Columns["created_at"].Visible = false;
            this.DgvProduct.DefaultCellStyle.Font = new Font("PoetsenOne", 10);
        }

        private void DgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var data = DgvProduct.Rows[e.RowIndex];

                id = long.Parse(data.Cells["id"].Value.ToString());
                txtProduct.Text = data.Cells["Product"].Value.ToString();
                txtQty.Text = data.Cells["Qty"].Value.ToString();
                txtPrice.Text = data.Cells["Price"].Value.ToString();



                imgName = data.Cells["Photo"].Value?.ToString();
                LoadProductImage(imgName);



                btnAdd.Text = "Update";
                btnDelete.Visible = true;
                btnAdd.TextPadding = new Padding(10, 0, 0, 0);
                btnDelete.TextPadding = new Padding(7, 0, 0, 0);
            }
        }

        long id = 0;
        Image img;
        string imgName;

        private void AddPhoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.gif)|*.png; *.jpg; *.jpeg; *.gif";
            string appPath = "C:\\Users\\Admin\\Pictures\\POS Skincare Test";
            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                imgName = Path.GetFileName(opnfd.FileName);
                string filepath = opnfd.FileName;
                img = new Bitmap(filepath);

                string destFile = Path.Combine(appPath, imgName);
                if (!File.Exists(destFile))
                {
                    File.Copy(filepath, destFile);
                }
                AddPhoto.Image = img;
            }
            else
            {
                // Reset imgName if no photo is chosen
                imgName = null;
                AddPhoto.Image = Properties.Resources.Upload_Photo; // Display default photo or clear the existing photo
            }
        }

        private void LoadProductImage(string imageName)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                string fullPath = Path.Combine("C:\\Users\\Admin\\Pictures\\POS Skincare Test", imageName);
                if (File.Exists(fullPath))
                {
                    AddPhoto.Image?.Dispose();
                    AddPhoto.Image = Image.FromFile(fullPath);
                }
                else
                {
                    AddPhoto.Image = Properties.Resources.Upload_Photo;
                }
            }
            else
            {
                AddPhoto.Image = Properties.Resources.Upload_Photo;
            }
        }

        private long ProID()
        {
            return DB_POS.tblProducts.Any() ? DB_POS.tblProducts.Max(m => m.id) + 1 : 1;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
            ResetForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Add")
                {
                    var newProduct = new tblProduct
                    {
                        id = ProID(),
                        Product = txtProduct.Text,
                        Qty = int.TryParse(txtQty.Text, out int qty) ? qty : 0,
                        Price = double.Parse(txtPrice.Text),
                        Photo = imgName
                    };

                    DB_POS.tblProducts.InsertOnSubmit(newProduct);
                    DB_POS.SubmitChanges();
                    MessageBox.Show("Product added successfully!");
                    ResetForm();
                    BindData();
                }
                else if (btnAdd.Text == "Update")
                {
                    var product = DB_POS.tblProducts.FirstOrDefault(x => x.id == id);
                    if (product != null)
                    {
                        product.Product = txtProduct.Text;
                        product.Qty = int.TryParse(txtQty.Text, out int qty) ? qty : 0;
                        product.Price = double.Parse(txtPrice.Text);  // Ensure price input is valid

                        // Update only if there is a new image and the old image was different
                        if (!string.IsNullOrEmpty(imgName) && (string.IsNullOrEmpty(product.Photo) || product.Photo != imgName))
                        {
                            // Delete the old image file if it exists
                            if (!string.IsNullOrEmpty(product.Photo))
                            {
                                string oldImagePath = Path.Combine("C:\\Users\\Admin\\Pictures\\POS Skincare Test", product.Photo);
                                TryDeleteFile(oldImagePath);
                            }
                            product.Photo = imgName;  // Update the photo path regardless of old photo presence
                        }

                        DB_POS.SubmitChanges();
                        MessageBox.Show("Product updated successfully!✅");
                        ResetForm();
                        BindData();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during product update: " + ex.Message);
            }
        }






        private void ResetForm()
        {
            btnAdd.Text = "Add";
            txtProduct.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            AddPhoto.Image = Properties.Resources.Upload_Photo;
            imgName = null; // Ensure imgName is reset
        }

        //private bool TryDeleteFile(string filePath)
        //{
        //    if (!File.Exists(filePath)) return true;

        //    try
        //    {
        //        File.Delete(filePath);
        //        return true;
        //    }
        //    catch (IOException)
        //    {
        //        MessageBox.Show("Unable to delete file as it is being used by another process.");
        //        return false;
        //    }
        //}
        private bool TryDeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return false;

            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Failed to delete the file: " + ex.Message);
                return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //var product = DB_POS.tblProducts.FirstOrDefault(x => x.id == id);
            //if (product != null)
            //{
            //    AddPhoto.Image?.Dispose();
            //    AddPhoto.Image = null;

            //    TryDeleteFile(Path.Combine("C:\\Users\\Admin\\Pictures\\POS Cosmetic Asset", product.Photo));
            //    DB_POS.tblProducts.DeleteOnSubmit(product);
            //    DB_POS.SubmitChanges();
            //    MessageBox.Show("Deleted successfully!");
            //    ResetForm();
            //    BindData();
            //}
            var product = DB_POS.tblProducts.FirstOrDefault(x => x.id == id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.Photo))
                {
                    string imagePath = Path.Combine("C:\\Users\\Admin\\Pictures\\POS Cosmetic Asset", product.Photo);
                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            File.Delete(imagePath);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("An error occurred while trying to delete the image file: " + ex.Message);
                        }
                    }
                }

                AddPhoto.Image?.Dispose();
                AddPhoto.Image = null;

                DB_POS.tblProducts.DeleteOnSubmit(product);
                DB_POS.SubmitChanges();
                MessageBox.Show("Deleted successfully!");
                ResetForm();
                BindData();
            }
        }
    }
}
