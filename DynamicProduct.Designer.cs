namespace Product_Assignment
{
    partial class DynamicProduct
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicProduct));
            this.ImageProduct = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.NamePro = new System.Windows.Forms.Label();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.BtnCart = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.PricePro = new Bunifu.UI.WinForms.BunifuLabel();
            this.PanelPro = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCart)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageProduct
            // 
            this.ImageProduct.ActiveImage = null;
            this.ImageProduct.AllowAnimations = true;
            this.ImageProduct.AllowBuffering = false;
            this.ImageProduct.AllowToggling = false;
            this.ImageProduct.AllowZooming = true;
            this.ImageProduct.AllowZoomingOnFocus = false;
            this.ImageProduct.BackColor = System.Drawing.Color.Transparent;
            this.ImageProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageProduct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ImageProduct.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ImageProduct.ErrorImage")));
            this.ImageProduct.FadeWhenInactive = false;
            this.ImageProduct.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.ImageProduct.Image = ((System.Drawing.Image)(resources.GetObject("ImageProduct.Image")));
            this.ImageProduct.ImageActive = null;
            this.ImageProduct.ImageLocation = null;
            this.ImageProduct.ImageMargin = 20;
            this.ImageProduct.ImageSize = new System.Drawing.Size(219, 233);
            this.ImageProduct.ImageZoomSize = new System.Drawing.Size(239, 253);
            this.ImageProduct.InitialImage = ((System.Drawing.Image)(resources.GetObject("ImageProduct.InitialImage")));
            this.ImageProduct.Location = new System.Drawing.Point(3, 3);
            this.ImageProduct.Name = "ImageProduct";
            this.ImageProduct.Rotation = 0;
            this.ImageProduct.ShowActiveImage = true;
            this.ImageProduct.ShowCursorChanges = true;
            this.ImageProduct.ShowImageBorders = true;
            this.ImageProduct.ShowSizeMarkers = false;
            this.ImageProduct.Size = new System.Drawing.Size(239, 253);
            this.ImageProduct.TabIndex = 0;
            this.ImageProduct.ToolTipText = "";
            this.ImageProduct.WaitOnLoad = false;
            this.ImageProduct.Zoom = 20;
            this.ImageProduct.ZoomSpeed = 10;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 20;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.NamePro);
            this.bunifuPanel1.Controls.Add(this.bunifuPictureBox1);
            this.bunifuPanel1.Controls.Add(this.BtnCart);
            this.bunifuPanel1.Controls.Add(this.PricePro);
            this.bunifuPanel1.Controls.Add(this.ImageProduct);
            this.bunifuPanel1.Location = new System.Drawing.Point(6, 3);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(245, 351);
            this.bunifuPanel1.TabIndex = 2;
            // 
            // NamePro
            // 
            this.NamePro.AutoSize = true;
            this.NamePro.BackColor = System.Drawing.Color.Transparent;
            this.NamePro.Font = new System.Drawing.Font("PoetsenOne", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePro.Location = new System.Drawing.Point(30, 259);
            this.NamePro.Name = "NamePro";
            this.NamePro.Size = new System.Drawing.Size(55, 20);
            this.NamePro.TabIndex = 5;
            this.NamePro.Text = "label1";
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuPictureBox1.BorderRadius = 35;
            this.bunifuPictureBox1.Image = global::Product_Assignment.Properties.Resources.Rate;
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(5, 294);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(70, 70);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 4;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // BtnCart
            // 
            this.BtnCart.AllowFocused = false;
            this.BtnCart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCart.AutoSizeHeight = true;
            this.BtnCart.BackColor = System.Drawing.Color.Transparent;
            this.BtnCart.BorderRadius = 22;
            this.BtnCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCart.Image = global::Product_Assignment.Properties.Resources.Cart;
            this.BtnCart.IsCircle = true;
            this.BtnCart.Location = new System.Drawing.Point(184, 294);
            this.BtnCart.Name = "BtnCart";
            this.BtnCart.Size = new System.Drawing.Size(45, 45);
            this.BtnCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnCart.TabIndex = 3;
            this.BtnCart.TabStop = false;
            this.BtnCart.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            this.BtnCart.Click += new System.EventHandler(this.BtnCart_Click);
            // 
            // PricePro
            // 
            this.PricePro.AllowParentOverrides = false;
            this.PricePro.AutoEllipsis = false;
            this.PricePro.CursorType = null;
            this.PricePro.Font = new System.Drawing.Font("PoetsenOne", 10.8F);
            this.PricePro.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.PricePro.Location = new System.Drawing.Point(81, 297);
            this.PricePro.Name = "PricePro";
            this.PricePro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PricePro.Size = new System.Drawing.Size(63, 22);
            this.PricePro.TabIndex = 2;
            this.PricePro.Text = "$00.00";
            this.PricePro.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.PricePro.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // PanelPro
            // 
            this.PanelPro.BackColor = System.Drawing.Color.Transparent;
            this.PanelPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelPro.BackgroundImage")));
            this.PanelPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPro.BorderRadius = 10;
            this.PanelPro.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(209)))));
            this.PanelPro.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(75)))), ((int)(((byte)(233)))));
            this.PanelPro.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(233)))), ((int)(((byte)(4)))));
            this.PanelPro.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(56)))), ((int)(((byte)(109)))));
            this.PanelPro.Location = new System.Drawing.Point(3, 3);
            this.PanelPro.Name = "PanelPro";
            this.PanelPro.Quality = 10;
            this.PanelPro.Size = new System.Drawing.Size(262, 351);
            this.PanelPro.TabIndex = 1;
            this.PanelPro.Visible = false;
            // 
            // TestDynamic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.PanelPro);
            this.Name = "TestDynamic";
            this.Size = new System.Drawing.Size(258, 366);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton ImageProduct;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuGradientPanel PanelPro;
        private Bunifu.UI.WinForms.BunifuLabel PricePro;
        private Bunifu.UI.WinForms.BunifuPictureBox BtnCart;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Label NamePro;
    }
}
