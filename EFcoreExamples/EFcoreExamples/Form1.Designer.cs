namespace EFcoreExamples
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
            this.btnIssueWithDeletingRows = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIssueWithDeletingRows
            // 
            this.btnIssueWithDeletingRows.Location = new System.Drawing.Point(35, 40);
            this.btnIssueWithDeletingRows.Name = "btnIssueWithDeletingRows";
            this.btnIssueWithDeletingRows.Size = new System.Drawing.Size(183, 23);
            this.btnIssueWithDeletingRows.TabIndex = 0;
            this.btnIssueWithDeletingRows.Text = "Issue with deleting rows";
            this.btnIssueWithDeletingRows.UseVisualStyleBackColor = true;
            this.btnIssueWithDeletingRows.Click += new System.EventHandler(this.btnIssueWithDeletingRows_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 415);
            this.Controls.Add(this.btnIssueWithDeletingRows);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIssueWithDeletingRows;
    }
}

