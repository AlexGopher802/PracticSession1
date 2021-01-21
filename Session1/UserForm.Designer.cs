namespace Session1
{
    partial class UserForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewActive = new System.Windows.Forms.DataGridView();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTimeInSystem = new System.Windows.Forms.Label();
            this.lblCrashes = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActive)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(882, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // dataGridViewActive
            // 
            this.dataGridViewActive.AllowUserToAddRows = false;
            this.dataGridViewActive.AllowUserToDeleteRows = false;
            this.dataGridViewActive.AllowUserToResizeColumns = false;
            this.dataGridViewActive.AllowUserToResizeRows = false;
            this.dataGridViewActive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActive.Location = new System.Drawing.Point(12, 55);
            this.dataGridViewActive.MultiSelect = false;
            this.dataGridViewActive.Name = "dataGridViewActive";
            this.dataGridViewActive.ReadOnly = true;
            this.dataGridViewActive.RowHeadersVisible = false;
            this.dataGridViewActive.RowHeadersWidth = 51;
            this.dataGridViewActive.RowTemplate.Height = 24;
            this.dataGridViewActive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActive.Size = new System.Drawing.Size(858, 386);
            this.dataGridViewActive.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(166)))));
            this.lblWelcome.Location = new System.Drawing.Point(12, 28);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 19);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome to AMONIC Airlines";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeInSystem
            // 
            this.lblTimeInSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeInSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(166)))));
            this.lblTimeInSystem.Location = new System.Drawing.Point(418, 29);
            this.lblTimeInSystem.Name = "lblTimeInSystem";
            this.lblTimeInSystem.Size = new System.Drawing.Size(224, 23);
            this.lblTimeInSystem.TabIndex = 4;
            this.lblTimeInSystem.Text = "Time in system";
            // 
            // lblCrashes
            // 
            this.lblCrashes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCrashes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(106)))), ((int)(((byte)(166)))));
            this.lblCrashes.Location = new System.Drawing.Point(649, 29);
            this.lblCrashes.Name = "lblCrashes";
            this.lblCrashes.Size = new System.Drawing.Size(221, 23);
            this.lblCrashes.TabIndex = 5;
            this.lblCrashes.Text = "Number of crashes";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.lblCrashes);
            this.Controls.Add(this.lblTimeInSystem);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.dataGridViewActive);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "UserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMONIC Airlines Automation System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewActive;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTimeInSystem;
        private System.Windows.Forms.Label lblCrashes;
    }
}