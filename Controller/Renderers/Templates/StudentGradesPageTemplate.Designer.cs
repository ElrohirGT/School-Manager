
namespace Controller.Renderers.Templates
{
    partial class StudentGradesPageTemplate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataDisplay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dataDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataDisplay
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            this._dataDisplay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dataDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataDisplay.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this._dataDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataDisplay.Location = new System.Drawing.Point(0, 0);
            this._dataDisplay.Margin = new System.Windows.Forms.Padding(0);
            this._dataDisplay.Name = "_dataDisplay";
            this._dataDisplay.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this._dataDisplay.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this._dataDisplay.Size = new System.Drawing.Size(800, 450);
            this._dataDisplay.TabIndex = 0;
            // 
            // StudentGradesPageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._dataDisplay);
            this.Name = "StudentGradesPageTemplate";
            this.Text = "StudenGradesTemplate";
            ((System.ComponentModel.ISupportInitialize)(this._dataDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataDisplay;
    }
}