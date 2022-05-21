namespace ClipboardLogger
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.clipList = new System.Windows.Forms.ListBox();
            this.clipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clipList
            // 
            this.clipList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipList.FormattingEnabled = true;
            this.clipList.ItemHeight = 21;
            this.clipList.Location = new System.Drawing.Point(13, 41);
            this.clipList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clipList.Name = "clipList";
            this.clipList.Size = new System.Drawing.Size(452, 403);
            this.clipList.TabIndex = 0;
            // 
            // clipLabel
            // 
            this.clipLabel.AutoSize = true;
            this.clipLabel.Location = new System.Drawing.Point(13, 15);
            this.clipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clipLabel.Name = "clipLabel";
            this.clipLabel.Size = new System.Drawing.Size(459, 21);
            this.clipLabel.TabIndex = 1;
            this.clipLabel.Text = "Logs the clipboard copy action even when this form is minimised";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 469);
            this.Controls.Add(this.clipLabel);
            this.Controls.Add(this.clipList);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(494, 508);
            this.Name = "MainForm";
            this.Text = "Clipboard Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox clipList;
        private System.Windows.Forms.Label clipLabel;
    }
}