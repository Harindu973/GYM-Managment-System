namespace Home
{
    partial class Attendance_Mark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance_Mark));
            this.dgvMark = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMark)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMark
            // 
            this.dgvMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMark.Location = new System.Drawing.Point(106, 196);
            this.dgvMark.Name = "dgvMark";
            this.dgvMark.RowTemplate.Height = 24;
            this.dgvMark.Size = new System.Drawing.Size(882, 671);
            this.dgvMark.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Firebrick;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(475, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 51);
            this.button3.TabIndex = 131;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Firebrick;
            this.panel13.Location = new System.Drawing.Point(106, 148);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(346, 3);
            this.panel13.TabIndex = 130;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.Firebrick;
            this.textBox8.Location = new System.Drawing.Point(106, 108);
            this.textBox8.MaxLength = 10;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(339, 30);
            this.textBox8.TabIndex = 129;
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(101, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 28);
            this.label11.TabIndex = 128;
            this.label11.Text = "Member ID";
            // 
            // Attendance_Mark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvMark);
            this.Name = "Attendance_Mark";
            this.Size = new System.Drawing.Size(1102, 958);
            this.Load += new System.EventHandler(this.Attendance_Mark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DataGridView dgvMark;
    }
}
