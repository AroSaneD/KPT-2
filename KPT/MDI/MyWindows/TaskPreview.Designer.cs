namespace PSI_Forms.MyWindows
{
    partial class TaskPreview
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
            this.TaskName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.milestoneGrid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.doUntil = new System.Windows.Forms.Label();
            this.resPersons = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.milestoneGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskName
            // 
            this.TaskName.AutoSize = true;
            this.TaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskName.Location = new System.Drawing.Point(13, 13);
            this.TaskName.Name = "TaskName";
            this.TaskName.Size = new System.Drawing.Size(70, 25);
            this.TaskName.TabIndex = 0;
            this.TaskName.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(402, 47);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Išeiti";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // milestoneGrid
            // 
            this.milestoneGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.milestoneGrid.Location = new System.Drawing.Point(18, 167);
            this.milestoneGrid.Name = "milestoneGrid";
            this.milestoneGrid.Size = new System.Drawing.Size(396, 170);
            this.milestoneGrid.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Redaguoti";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Atnaujinti";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Atlikti iki: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Atsakingi asmenys: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Etapai";
            // 
            // doUntil
            // 
            this.doUntil.AutoSize = true;
            this.doUntil.Location = new System.Drawing.Point(125, 91);
            this.doUntil.Name = "doUntil";
            this.doUntil.Size = new System.Drawing.Size(41, 13);
            this.doUntil.TabIndex = 10;
            this.doUntil.Text = "untitled";
            // 
            // resPersons
            // 
            this.resPersons.AutoSize = true;
            this.resPersons.Location = new System.Drawing.Point(125, 113);
            this.resPersons.Name = "resPersons";
            this.resPersons.Size = new System.Drawing.Size(41, 13);
            this.resPersons.TabIndex = 11;
            this.resPersons.Text = "untitled";
            // 
            // TaskPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 378);
            this.Controls.Add(this.resPersons);
            this.Controls.Add(this.doUntil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.milestoneGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TaskName);
            this.Name = "TaskPreview";
            this.Text = "TaskPreview";
            ((System.ComponentModel.ISupportInitialize)(this.milestoneGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView milestoneGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label doUntil;
        private System.Windows.Forms.Label resPersons;
    }
}