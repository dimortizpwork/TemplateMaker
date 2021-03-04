
namespace TemplateMaker.Viewer
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTemplate = new System.Windows.Forms.ComboBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.richTextBoxParametersJson = new System.Windows.Forms.RichTextBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template:";
            // 
            // comboBoxTemplate
            // 
            this.comboBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTemplate.FormattingEnabled = true;
            this.comboBoxTemplate.Location = new System.Drawing.Point(30, 48);
            this.comboBoxTemplate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxTemplate.Name = "comboBoxTemplate";
            this.comboBoxTemplate.Size = new System.Drawing.Size(1984, 33);
            this.comboBoxTemplate.TabIndex = 1;
            this.comboBoxTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxTemplate_SelectedIndexChanged);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxDescription.Location = new System.Drawing.Point(30, 133);
            this.richTextBoxDescription.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(1994, 87);
            this.richTextBoxDescription.TabIndex = 4;
            this.richTextBoxDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(28, 240);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(1056, 748);
            this.propertyGrid.TabIndex = 6;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // richTextBoxParametersJson
            // 
            this.richTextBoxParametersJson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxParametersJson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxParametersJson.Location = new System.Drawing.Point(1096, 718);
            this.richTextBoxParametersJson.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.richTextBoxParametersJson.Name = "richTextBoxParametersJson";
            this.richTextBoxParametersJson.Size = new System.Drawing.Size(928, 270);
            this.richTextBoxParametersJson.TabIndex = 7;
            this.richTextBoxParametersJson.Text = "";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecute.Location = new System.Drawing.Point(1908, 1008);
            this.buttonExecute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(116, 50);
            this.buttonExecute.TabIndex = 8;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(2048, 1061);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.richTextBoxParametersJson);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.comboBoxTemplate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormMain";
            this.Text = "Template Maker";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTemplate;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.RichTextBox richTextBoxParametersJson;
        private System.Windows.Forms.Button buttonExecute;
    }
}