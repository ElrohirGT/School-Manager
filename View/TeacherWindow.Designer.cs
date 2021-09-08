
namespace School_Manager
{
    partial class TeacherWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._homeButton = new System.Windows.Forms.Button();
            this.ClientPanel = new System.Windows.Forms.Panel();
            this._calificationsButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel1.Controls.Add(this._calificationsButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._closeButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._homeButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ClientPanel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _homeButton
            // 
            this._homeButton.BackColor = System.Drawing.Color.Gold;
            this._homeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._homeButton.FlatAppearance.BorderSize = 0;
            this._homeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._homeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._homeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._homeButton.Image = global::View.Properties.Resources.Home;
            this._homeButton.Location = new System.Drawing.Point(0, 0);
            this._homeButton.Margin = new System.Windows.Forms.Padding(0);
            this._homeButton.Name = "_homeButton";
            this._homeButton.Size = new System.Drawing.Size(62, 141);
            this._homeButton.TabIndex = 7;
            this._homeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._homeButton.UseVisualStyleBackColor = false;
            this._homeButton.Click += new System.EventHandler(this._homeButton_Click);
            // 
            // ClientPanel
            // 
            this.ClientPanel.BackColor = System.Drawing.Color.Transparent;
            this.ClientPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientPanel.Location = new System.Drawing.Point(62, 0);
            this.ClientPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ClientPanel.Name = "ClientPanel";
            this.tableLayoutPanel1.SetRowSpan(this.ClientPanel, 3);
            this.ClientPanel.Size = new System.Drawing.Size(714, 426);
            this.ClientPanel.TabIndex = 6;
            // 
            // _calificationsButton
            // 
            this._calificationsButton.BackColor = System.Drawing.Color.Gold;
            this._calificationsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._calificationsButton.FlatAppearance.BorderSize = 0;
            this._calificationsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._calificationsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._calificationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._calificationsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._calificationsButton.Image = global::View.Properties.Resources.Grades;
            this._calificationsButton.Location = new System.Drawing.Point(0, 141);
            this._calificationsButton.Margin = new System.Windows.Forms.Padding(0);
            this._calificationsButton.Name = "_calificationsButton";
            this._calificationsButton.Size = new System.Drawing.Size(62, 141);
            this._calificationsButton.TabIndex = 9;
            this._calificationsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._calificationsButton.UseVisualStyleBackColor = false;
            this._calificationsButton.Click += new System.EventHandler(this._calificationsButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.BackColor = System.Drawing.Color.Gold;
            this._closeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._closeButton.FlatAppearance.BorderSize = 0;
            this._closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._closeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._closeButton.Image = global::View.Properties.Resources.Logout;
            this._closeButton.Location = new System.Drawing.Point(0, 282);
            this._closeButton.Margin = new System.Windows.Forms.Padding(0);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(62, 144);
            this._closeButton.TabIndex = 8;
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = false;
            this._closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TeacherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::View.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeacherWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.Button _homeButton;
        private System.Windows.Forms.Button _calificationsButton;
        private System.Windows.Forms.Button _closeButton;
    }
}

