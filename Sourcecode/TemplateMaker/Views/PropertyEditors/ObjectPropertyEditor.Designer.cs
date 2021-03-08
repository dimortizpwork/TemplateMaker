
namespace TemplateMaker.Views.PropertyEditors
{
    partial class ObjectPropertyEditor
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
            this.smartPropertyGrid1 = new SmartProperty.SmartPropertyGrid();
            this.SuspendLayout();
            // 
            // smartPropertyGrid1
            // 
            this.smartPropertyGrid1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartPropertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.smartPropertyGrid1.Name = "smartPropertyGrid1";
            this.smartPropertyGrid1.Size = new System.Drawing.Size(747, 396);
            this.smartPropertyGrid1.TabIndex = 0;
            // 
            // ObjectPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.smartPropertyGrid1);
            this.Name = "ObjectPropertyEditor";
            this.Size = new System.Drawing.Size(753, 402);
            this.ResumeLayout(false);

        }

        #endregion

        private SmartProperty.SmartPropertyGrid smartPropertyGrid1;
    }
}
