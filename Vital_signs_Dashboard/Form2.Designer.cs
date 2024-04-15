namespace Vital_signs_Dashboard
{
    partial class Form2
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
            bt_insert = new TextBox();
            hr_insert = new TextBox();
            bp_sbp_insert = new TextBox();
            bp_dbp_insert = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            insert = new Button();
            SuspendLayout();
            // 
            // bt_insert
            // 
            bt_insert.Location = new Point(79, 17);
            bt_insert.Name = "bt_insert";
            bt_insert.Size = new Size(148, 23);
            bt_insert.TabIndex = 3;
            // 
            // hr_insert
            // 
            hr_insert.Location = new Point(300, 17);
            hr_insert.Name = "hr_insert";
            hr_insert.Size = new Size(148, 23);
            hr_insert.TabIndex = 4;
            // 
            // bp_sbp_insert
            // 
            bp_sbp_insert.Location = new Point(79, 75);
            bp_sbp_insert.Name = "bp_sbp_insert";
            bp_sbp_insert.Size = new Size(148, 23);
            bp_sbp_insert.TabIndex = 5;
            // 
            // bp_dbp_insert
            // 
            bp_dbp_insert.Location = new Point(300, 75);
            bp_dbp_insert.Name = "bp_dbp_insert";
            bp_dbp_insert.Size = new Size(148, 23);
            bp_dbp_insert.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 20);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 7;
            label1.Text = "體溫";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 20);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 8;
            label2.Text = "心率";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 78);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 9;
            label3.Text = "舒張壓";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(251, 78);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 10;
            label4.Text = "收縮壓";
            // 
            // insert
            // 
            insert.Location = new Point(207, 142);
            insert.Name = "insert";
            insert.Size = new Size(75, 23);
            insert.TabIndex = 11;
            insert.Text = "新增";
            insert.UseVisualStyleBackColor = true;
            insert.Click += insert_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 180);
            Controls.Add(insert);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bp_dbp_insert);
            Controls.Add(bp_sbp_insert);
            Controls.Add(hr_insert);
            Controls.Add(bt_insert);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox bt_insert;
        private TextBox hr_insert;
        private TextBox bp_sbp_insert;
        private TextBox bp_dbp_insert;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button insert;
    }
}