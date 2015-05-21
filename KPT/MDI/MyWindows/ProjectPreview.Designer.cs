namespace PSI_Forms.Windows
{
    partial class ProjectPreview
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
            this.ProjectName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.taskGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Closebutton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.newTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSize = true;
            this.ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(13, 27);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(70, 25);
            this.ProjectName.TabIndex = 0;
            this.ProjectName.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(18, 55);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(746, 70);
            this.textBox1.TabIndex = 1;
            // 
            // taskGrid
            // 
            this.taskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskGrid.Location = new System.Drawing.Point(12, 160);
            this.taskGrid.Name = "taskGrid";
            this.taskGrid.Size = new System.Drawing.Size(751, 312);
            this.taskGrid.TabIndex = 2;
            this.taskGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Užduotys";
            // 
            // Closebutton
            // 
            this.Closebutton.Location = new System.Drawing.Point(689, 478);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(75, 23);
            this.Closebutton.TabIndex = 5;
            this.Closebutton.Text = "Išeiti";
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(599, 478);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 6;
            this.EditButton.Text = "Redaguoti";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // newTask
            // 
            this.newTask.Location = new System.Drawing.Point(12, 478);
            this.newTask.Name = "newTask";
            this.newTask.Size = new System.Drawing.Size(75, 23);
            this.newTask.TabIndex = 7;
            this.newTask.Text = "Nauja";
            this.newTask.UseVisualStyleBackColor = true;
            this.newTask.Click += new System.EventHandler(this.newTask_Click);
            // 
            // ProjectPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 507);
            this.Controls.Add(this.newTask);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.Closebutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taskGrid);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ProjectName);
            this.Name = "ProjectPreview";
            this.Text = "ProjectPreview";
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProjectName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView taskGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button newTask;
    }
}