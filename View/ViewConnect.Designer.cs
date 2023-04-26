namespace MTS_service.View
{
    partial class ViewConnect
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            materialDataTable4 = new MaterialSkin2DotNet.Controls.MaterialDataTable();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)materialDataTable4).BeginInit();
            SuspendLayout();
            // 
            // materialDataTable4
            // 
            materialDataTable4.AllowUserToDeleteRows = false;
            materialDataTable4.AllowUserToResizeRows = false;
            materialDataTable4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            materialDataTable4.BackgroundColor = Color.FromArgb(255, 255, 255);
            materialDataTable4.BorderStyle = BorderStyle.None;
            materialDataTable4.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            materialDataTable4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            materialDataTable4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            materialDataTable4.ColumnHeadersHeight = 56;
            materialDataTable4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            materialDataTable4.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            materialDataTable4.DefaultCellStyle = dataGridViewCellStyle2;
            materialDataTable4.Depth = 0;
            materialDataTable4.Dock = DockStyle.Fill;
            materialDataTable4.EnableHeadersVisualStyles = false;
            materialDataTable4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialDataTable4.GridColor = Color.FromArgb(239, 239, 239);
            materialDataTable4.Location = new Point(3, 64);
            materialDataTable4.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            materialDataTable4.Name = "materialDataTable4";
            materialDataTable4.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            materialDataTable4.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            materialDataTable4.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialDataTable4.RowsDefaultCellStyle = dataGridViewCellStyle4;
            materialDataTable4.RowTemplate.Height = 52;
            materialDataTable4.ScrollBars = ScrollBars.None;
            materialDataTable4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            materialDataTable4.ShowRowErrors = false;
            materialDataTable4.ShowVerticalScroll = false;
            materialDataTable4.Size = new Size(609, 263);
            materialDataTable4.TabIndex = 35;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "id";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "Название";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "Описание";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "Стоимость подключения";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // ViewConnect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 330);
            Controls.Add(materialDataTable4);
            Name = "ViewConnect";
            Text = "Опции в заказе";
            ((System.ComponentModel.ISupportInitialize)materialDataTable4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin2DotNet.Controls.MaterialDataTable materialDataTable4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}