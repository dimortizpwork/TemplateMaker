
namespace TemplateMaker.Viewer.Helpers.PropertyEditors
{
    partial class FormTableInfoPropertyEditor
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
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFullName.Location = new System.Drawing.Point(37, 147);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(671, 24);
            this.textBoxFullName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Table Full Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table Prefix:";
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPrefix.Location = new System.Drawing.Point(37, 233);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(232, 24);
            this.textBoxPrefix.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Location = new System.Drawing.Point(321, 233);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(387, 24);
            this.textBoxName.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 322);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1311, 680);
            this.dataGridView1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Columns:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(1256, 1019);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(92, 35);
            this.buttonConfirm.TabIndex = 9;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // FormTableInfoPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 1193);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFullName);
            this.Name = "FormTableInfoPropertyEditor";
            this.Text = "FormTablePropertyEditor";
            this.Shown += new System.EventHandler(this.FormTableInfoPropertyEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonConfirm;
    }
}