namespace LiveSplit.SplitOffsets
{
    partial class SplitOffsetsSettings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label lblTagStyle;
        private System.Windows.Forms.ComboBox cmbTagStyle;
        private System.Windows.Forms.TableLayoutPanel topLevelLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.lblTagStyle = new System.Windows.Forms.Label();
            this.cmbTagStyle = new System.Windows.Forms.ComboBox();
            this.topLevelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topLevelLayoutPanel.SuspendLayout();
            this.SuspendLayout();

            // topLevelLayoutPanel
            this.topLevelLayoutPanel.ColumnCount = 2;
            this.topLevelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.topLevelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLevelLayoutPanel.Controls.Add(this.chkEnable, 0, 0);
            this.topLevelLayoutPanel.SetColumnSpan(this.chkEnable, 2);
            this.topLevelLayoutPanel.Controls.Add(this.lblTagStyle, 0, 1);
            this.topLevelLayoutPanel.Controls.Add(this.cmbTagStyle, 1, 1);
            this.topLevelLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLevelLayoutPanel.Location = new System.Drawing.Point(7, 7);
            this.topLevelLayoutPanel.Name = "topLevelLayoutPanel";
            this.topLevelLayoutPanel.RowCount = 2;
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.topLevelLayoutPanel.Size = new System.Drawing.Size(462, 60);

            // chkEnable
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(3, 3);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(120, 17);
            this.chkEnable.Text = "Enable Split Offsets";
            this.chkEnable.UseVisualStyleBackColor = true;

            // lblTagStyle
            this.lblTagStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTagStyle.AutoSize = true;
            this.lblTagStyle.Location = new System.Drawing.Point(3, 37);
            this.lblTagStyle.Name = "lblTagStyle";
            this.lblTagStyle.Size = new System.Drawing.Size(79, 13);
            this.lblTagStyle.Text = "Tag Enclosure:";

            // cmbTagStyle
            this.cmbTagStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTagStyle.FormattingEnabled = true;
            this.cmbTagStyle.Items.AddRange(new object[] {
                "Square Brackets [ ]",
                "Parentheses ( )",
                "Curly Braces { }",
                "Angle Brackets < >"
            });
            this.cmbTagStyle.Location = new System.Drawing.Point(113, 32);
            this.cmbTagStyle.Name = "cmbTagStyle";
            this.cmbTagStyle.Size = new System.Drawing.Size(160, 21);

            // SplitOffsetsSettings
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topLevelLayoutPanel);
            this.Name = "SplitOffsetsSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(476, 74);
            this.topLevelLayoutPanel.ResumeLayout(false);
            this.topLevelLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}