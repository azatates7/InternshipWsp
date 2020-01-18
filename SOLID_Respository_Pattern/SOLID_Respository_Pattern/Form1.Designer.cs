namespace SOLID_Respository_Pattern
{
    partial class Form1
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
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupd = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.cnnlbl = new System.Windows.Forms.Label();
            this.cntlbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.userbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(6, 205);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnupd
            // 
            this.btnupd.Location = new System.Drawing.Point(100, 205);
            this.btnupd.Name = "btnupd";
            this.btnupd.Size = new System.Drawing.Size(75, 23);
            this.btnupd.TabIndex = 1;
            this.btnupd.Text = "Update";
            this.btnupd.UseVisualStyleBackColor = true;
            this.btnupd.Click += new System.EventHandler(this.btnupd_Click);
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point(193, 205);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 23);
            this.btndel.TabIndex = 2;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // cnnlbl
            // 
            this.cnnlbl.AutoSize = true;
            this.cnnlbl.Location = new System.Drawing.Point(157, 349);
            this.cnnlbl.Name = "cnnlbl";
            this.cnnlbl.Size = new System.Drawing.Size(35, 13);
            this.cnnlbl.TabIndex = 3;
            this.cnnlbl.Text = "label1";
            // 
            // cntlbl
            // 
            this.cntlbl.AutoSize = true;
            this.cntlbl.Location = new System.Drawing.Point(551, 304);
            this.cntlbl.Name = "cntlbl";
            this.cntlbl.Size = new System.Drawing.Size(35, 13);
            this.cntlbl.TabIndex = 4;
            this.cntlbl.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(397, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(356, 240);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectrow);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userbox);
            this.groupBox1.Controls.Add(this.searchlbl);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnadd);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnupd);
            this.groupBox1.Controls.Add(this.btndel);
            this.groupBox1.Location = new System.Drawing.Point(44, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 305);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Operations";
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Location = new System.Drawing.Point(27, 51);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(41, 13);
            this.searchlbl.TabIndex = 7;
            this.searchlbl.Text = "Search";
            // 
            // userbox
            // 
            this.userbox.Location = new System.Drawing.Point(87, 44);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(100, 20);
            this.userbox.TabIndex = 8;
            this.userbox.TextChanged += new System.EventHandler(this.userbox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cntlbl);
            this.Controls.Add(this.cnnlbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupd;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Label cnnlbl;
        private System.Windows.Forms.Label cntlbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox userbox;
        private System.Windows.Forms.Label searchlbl;
    }
}

