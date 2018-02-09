namespace WindowsFormsApplication1
{
    partial class frmStockIn
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtProducCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPriceSell = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProductInStock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAfterAdd = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Khmer OS Battambang", 14F);
            this.lblTitle.Location = new System.Drawing.Point(31, 37);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(156, 34);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "ថែមទំនិញចូលស្តុក";
            // 
            // txtProducCode
            // 
            this.txtProducCode.Location = new System.Drawing.Point(153, 129);
            this.txtProducCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProducCode.Name = "txtProducCode";
            this.txtProducCode.Size = new System.Drawing.Size(507, 27);
            this.txtProducCode.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(72, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "កូដទំនិញ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(57, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "ឈ្មោះទំនិញ :";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(153, 168);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(507, 27);
            this.txtProductName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(73, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "តំលៃលក់ :";
            // 
            // txtPriceSell
            // 
            this.txtPriceSell.Location = new System.Drawing.Point(153, 203);
            this.txtPriceSell.Margin = new System.Windows.Forms.Padding(4);
            this.txtPriceSell.Name = "txtPriceSell";
            this.txtPriceSell.Size = new System.Drawing.Size(202, 27);
            this.txtPriceSell.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(363, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "ទំនិញក្នុងស្តុកពេលនេះ :";
            // 
            // txtProductInStock
            // 
            this.txtProductInStock.Location = new System.Drawing.Point(519, 203);
            this.txtProductInStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductInStock.Name = "txtProductInStock";
            this.txtProductInStock.Size = new System.Drawing.Size(141, 27);
            this.txtProductInStock.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(366, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 25);
            this.label9.TabIndex = 30;
            this.label9.Text = "ទំនិញក្រោយពេលថែម :";
            // 
            // txtAfterAdd
            // 
            this.txtAfterAdd.Location = new System.Drawing.Point(519, 238);
            this.txtAfterAdd.Margin = new System.Windows.Forms.Padding(4);
            this.txtAfterAdd.Name = "txtAfterAdd";
            this.txtAfterAdd.Size = new System.Drawing.Size(141, 27);
            this.txtAfterAdd.TabIndex = 29;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(538, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 35);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(636, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 35);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(53, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "ថែមចូលស្តុក :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(153, 236);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(202, 27);
            this.txtQuantity.TabIndex = 36;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtAddInStock_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(0, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 67);
            this.panel1.TabIndex = 38;
            // 
            // frmStockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAfterAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProductInStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPriceSell);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProducCode);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockIn";
            this.Padding = new System.Windows.Forms.Padding(27, 88, 27, 29);
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtProducCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPriceSell;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProductInStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAfterAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Panel panel1;
    }
}