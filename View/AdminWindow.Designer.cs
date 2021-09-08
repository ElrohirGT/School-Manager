
namespace School_Manager
{
    partial class AdminWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._studentsButton = new System.Windows.Forms.Button();
            this._rolesButton = new System.Windows.Forms.Button();
            this._calificationsButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this._homeButton = new System.Windows.Forms.Button();
            this._assignationsButton = new System.Windows.Forms.Button();
            this._coursesButton = new System.Windows.Forms.Button();
            this._gradesButton = new System.Windows.Forms.Button();
            this._teachersButton = new System.Windows.Forms.Button();
            this._usersButton = new System.Windows.Forms.Button();
            this.ClientPanel = new System.Windows.Forms.Panel();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel1.Controls.Add(this._studentsButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._rolesButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._calificationsButton, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this._closeButton, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this._homeButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._assignationsButton, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this._coursesButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this._gradesButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this._teachersButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._usersButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ClientPanel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1326, 705);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _studentsButton
            // 
            this._studentsButton.BackColor = System.Drawing.Color.Gold;
            this._studentsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._studentsButton.FlatAppearance.BorderSize = 0;
            this._studentsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._studentsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._studentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._studentsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._studentsButton.Image = global::View.Properties.Resources.Student;
            this._studentsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._studentsButton.Location = new System.Drawing.Point(0, 210);
            this._studentsButton.Margin = new System.Windows.Forms.Padding(0);
            this._studentsButton.Name = "_studentsButton";
            this._studentsButton.Size = new System.Drawing.Size(159, 70);
            this._studentsButton.TabIndex = 11;
            this._studentsButton.Text = "Estudiantes";
            this._studentsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._studentsButton.UseVisualStyleBackColor = false;
            this._studentsButton.Click += new System.EventHandler(this._studentsButton_Click);
            // 
            // _rolesButton
            // 
            this._rolesButton.BackColor = System.Drawing.Color.Gold;
            this._rolesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rolesButton.FlatAppearance.BorderSize = 0;
            this._rolesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._rolesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._rolesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._rolesButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._rolesButton.Image = global::View.Properties.Resources.Role;
            this._rolesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._rolesButton.Location = new System.Drawing.Point(0, 70);
            this._rolesButton.Margin = new System.Windows.Forms.Padding(0);
            this._rolesButton.Name = "_rolesButton";
            this._rolesButton.Size = new System.Drawing.Size(159, 70);
            this._rolesButton.TabIndex = 10;
            this._rolesButton.Text = "Roles";
            this._rolesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._rolesButton.UseVisualStyleBackColor = false;
            this._rolesButton.Click += new System.EventHandler(this._rolesButton_Click);
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
            this._calificationsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._calificationsButton.Location = new System.Drawing.Point(0, 560);
            this._calificationsButton.Margin = new System.Windows.Forms.Padding(0);
            this._calificationsButton.Name = "_calificationsButton";
            this._calificationsButton.Size = new System.Drawing.Size(159, 70);
            this._calificationsButton.TabIndex = 9;
            this._calificationsButton.Text = "Notas";
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
            this._closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._closeButton.Location = new System.Drawing.Point(0, 630);
            this._closeButton.Margin = new System.Windows.Forms.Padding(0);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(159, 75);
            this._closeButton.TabIndex = 8;
            this._closeButton.Text = "Cerrar Sesión";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = false;
            this._closeButton.Click += new System.EventHandler(this.button1_Click);
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
            this._homeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._homeButton.Location = new System.Drawing.Point(0, 0);
            this._homeButton.Margin = new System.Windows.Forms.Padding(0);
            this._homeButton.Name = "_homeButton";
            this._homeButton.Size = new System.Drawing.Size(159, 70);
            this._homeButton.TabIndex = 7;
            this._homeButton.Text = "Inicio";
            this._homeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._homeButton.UseVisualStyleBackColor = false;
            this._homeButton.Click += new System.EventHandler(this._homeButton_Click);
            // 
            // _assignationsButton
            // 
            this._assignationsButton.BackColor = System.Drawing.Color.Gold;
            this._assignationsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._assignationsButton.FlatAppearance.BorderSize = 0;
            this._assignationsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._assignationsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._assignationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._assignationsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._assignationsButton.Image = global::View.Properties.Resources.Assignation;
            this._assignationsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._assignationsButton.Location = new System.Drawing.Point(0, 490);
            this._assignationsButton.Margin = new System.Windows.Forms.Padding(0);
            this._assignationsButton.Name = "_assignationsButton";
            this._assignationsButton.Size = new System.Drawing.Size(159, 70);
            this._assignationsButton.TabIndex = 5;
            this._assignationsButton.Text = "Asignaciones";
            this._assignationsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._assignationsButton.UseVisualStyleBackColor = false;
            this._assignationsButton.Click += new System.EventHandler(this._assignationsButton_Click);
            // 
            // _coursesButton
            // 
            this._coursesButton.BackColor = System.Drawing.Color.Gold;
            this._coursesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._coursesButton.FlatAppearance.BorderSize = 0;
            this._coursesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._coursesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._coursesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._coursesButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._coursesButton.Image = global::View.Properties.Resources.Course;
            this._coursesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._coursesButton.Location = new System.Drawing.Point(0, 420);
            this._coursesButton.Margin = new System.Windows.Forms.Padding(0);
            this._coursesButton.Name = "_coursesButton";
            this._coursesButton.Size = new System.Drawing.Size(159, 70);
            this._coursesButton.TabIndex = 4;
            this._coursesButton.Text = "Cursos";
            this._coursesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._coursesButton.UseVisualStyleBackColor = false;
            this._coursesButton.Click += new System.EventHandler(this._coursesButton_Click);
            // 
            // _gradesButton
            // 
            this._gradesButton.BackColor = System.Drawing.Color.Gold;
            this._gradesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gradesButton.FlatAppearance.BorderSize = 0;
            this._gradesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._gradesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._gradesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._gradesButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._gradesButton.Image = global::View.Properties.Resources.Grade;
            this._gradesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._gradesButton.Location = new System.Drawing.Point(0, 350);
            this._gradesButton.Margin = new System.Windows.Forms.Padding(0);
            this._gradesButton.Name = "_gradesButton";
            this._gradesButton.Size = new System.Drawing.Size(159, 70);
            this._gradesButton.TabIndex = 3;
            this._gradesButton.Text = "Grados";
            this._gradesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._gradesButton.UseVisualStyleBackColor = false;
            this._gradesButton.Click += new System.EventHandler(this._gradesButton_Click);
            // 
            // _teachersButton
            // 
            this._teachersButton.BackColor = System.Drawing.Color.Gold;
            this._teachersButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._teachersButton.FlatAppearance.BorderSize = 0;
            this._teachersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._teachersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._teachersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._teachersButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._teachersButton.Image = global::View.Properties.Resources.Teacher;
            this._teachersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._teachersButton.Location = new System.Drawing.Point(0, 280);
            this._teachersButton.Margin = new System.Windows.Forms.Padding(0);
            this._teachersButton.Name = "_teachersButton";
            this._teachersButton.Size = new System.Drawing.Size(159, 70);
            this._teachersButton.TabIndex = 2;
            this._teachersButton.Text = "Profesores";
            this._teachersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._teachersButton.UseVisualStyleBackColor = false;
            this._teachersButton.Click += new System.EventHandler(this._teachersButton_Click);
            // 
            // _usersButton
            // 
            this._usersButton.BackColor = System.Drawing.Color.Gold;
            this._usersButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._usersButton.FlatAppearance.BorderSize = 0;
            this._usersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this._usersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this._usersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._usersButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._usersButton.Image = global::View.Properties.Resources.User;
            this._usersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._usersButton.Location = new System.Drawing.Point(0, 140);
            this._usersButton.Margin = new System.Windows.Forms.Padding(0);
            this._usersButton.Name = "_usersButton";
            this._usersButton.Size = new System.Drawing.Size(159, 70);
            this._usersButton.TabIndex = 0;
            this._usersButton.Text = "Usuarios";
            this._usersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._usersButton.UseVisualStyleBackColor = false;
            this._usersButton.Click += new System.EventHandler(this._usersButton_Click);
            // 
            // ClientPanel
            // 
            this.ClientPanel.BackColor = System.Drawing.Color.Transparent;
            this.ClientPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientPanel.Location = new System.Drawing.Point(159, 0);
            this.ClientPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ClientPanel.Name = "ClientPanel";
            this.tableLayoutPanel1.SetRowSpan(this.ClientPanel, 10);
            this.ClientPanel.Size = new System.Drawing.Size(1167, 705);
            this.ClientPanel.TabIndex = 6;
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::View.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "AdminWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _usersButton;
        private System.Windows.Forms.Button _assignationsButton;
        private System.Windows.Forms.Button _coursesButton;
        private System.Windows.Forms.Button _gradesButton;
        private System.Windows.Forms.Button _teachersButton;
        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.Button _homeButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _calificationsButton;
        private System.Windows.Forms.Button _studentsButton;
        private System.Windows.Forms.Button _rolesButton;
    }
}

