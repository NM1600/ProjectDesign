namespace ProjectDesign
{
    partial class SalesUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.deletebtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.EditBtn = new System.Windows.Forms.Button();
            this.btnSalesTransaction = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1883, 639);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1883, 577);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(226)))), ((int)(((byte)(237)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1883, 62);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSalesTransaction);
            this.panel4.Location = new System.Drawing.Point(8, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 52);
            this.panel4.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(51)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1883, 577);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::ProjectDesign.Properties.Resources.Add_icon;
            this.panel5.Controls.Add(this.deletebtn);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(1754, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(91, 39);
            this.panel5.TabIndex = 6;
            // 
            // deletebtn
            // 
            this.deletebtn.BackColor = System.Drawing.Color.Transparent;
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(51)))));
            this.deletebtn.Image = global::ProjectDesign.Properties.Resources.Add_icon1;
            this.deletebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deletebtn.Location = new System.Drawing.Point(-13, -2);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(118, 46);
            this.deletebtn.TabIndex = 1;
            this.deletebtn.Text = "   Delete";
            this.deletebtn.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::ProjectDesign.Properties.Resources.Add_icon;
            this.panel6.Controls.Add(this.EditBtn);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(1673, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 39);
            this.panel6.TabIndex = 4;
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.Color.Transparent;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(51)))));
            this.EditBtn.Image = global::ProjectDesign.Properties.Resources.Add_icon1;
            this.EditBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditBtn.Location = new System.Drawing.Point(-15, -5);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(119, 46);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // btnSalesTransaction
            // 
            this.btnSalesTransaction.BackColor = System.Drawing.Color.Transparent;
            this.btnSalesTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesTransaction.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesTransaction.Image = global::ProjectDesign.Properties.Resources.Add_icon1;
            this.btnSalesTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesTransaction.Location = new System.Drawing.Point(-74, -15);
            this.btnSalesTransaction.Name = "btnSalesTransaction";
            this.btnSalesTransaction.Size = new System.Drawing.Size(338, 71);
            this.btnSalesTransaction.TabIndex = 1;
            this.btnSalesTransaction.Text = "          Sales Transaction";
            this.btnSalesTransaction.UseVisualStyleBackColor = false;
            this.btnSalesTransaction.Click += new System.EventHandler(this.ButtonTransaction_Click);
            // 
            // SalesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1883, 639);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SalesUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SalesUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSalesTransaction;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}