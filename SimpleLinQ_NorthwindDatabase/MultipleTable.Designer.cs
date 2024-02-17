namespace SimpleLinQ_NorthwindDatabase
{
    partial class MultipleTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleTable));
            this.label3 = new System.Windows.Forms.Label();
            this.dgwTable = new System.Windows.Forms.DataGridView();
            this.btnQuery1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Bisque;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(36, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 176);
            this.label3.TabIndex = 22;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgwTable
            // 
            this.dgwTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTable.Location = new System.Drawing.Point(504, 89);
            this.dgwTable.Name = "dgwTable";
            this.dgwTable.RowHeadersWidth = 51;
            this.dgwTable.RowTemplate.Height = 24;
            this.dgwTable.Size = new System.Drawing.Size(1036, 666);
            this.dgwTable.TabIndex = 13;
            // 
            // btnQuery1
            // 
            this.btnQuery1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnQuery1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnQuery1.Location = new System.Drawing.Point(32, 287);
            this.btnQuery1.Name = "btnQuery1";
            this.btnQuery1.Size = new System.Drawing.Size(458, 67);
            this.btnQuery1.TabIndex = 12;
            this.btnQuery1.Text = "Query_1";
            this.btnQuery1.UseVisualStyleBackColor = false;
            this.btnQuery1.Click += new System.EventHandler(this.btnQuery1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(461, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 44);
            this.label1.TabIndex = 9;
            this.label1.Text = "LinQ With Working Multiple Table ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MultipleTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 800);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgwTable);
            this.Controls.Add(this.btnQuery1);
            this.Controls.Add(this.label1);
            this.Name = "MultipleTable";
            this.Text = "MultipleTable";
            this.Load += new System.EventHandler(this.MultipleTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgwTable;
        private System.Windows.Forms.Button btnQuery1;
        private System.Windows.Forms.Label label1;
    }
}