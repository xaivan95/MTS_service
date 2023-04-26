using MaterialSkin2DotNet.Controls;
using MaterialSkin2DotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTS_service.Model;
using ApplicationContext = MTS_service.Model.ApplicationContext;
using MTS_service.Control;

namespace MTS_service.View
{
    public partial class UserForm : MaterialForm
    {
        ApplicationContext db;
        User nowUser;
        public UserForm(User nowUser, ApplicationContext db)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.WHITE);
            this.db = db;
            this.nowUser = nowUser;
            this.Text = "Здравствуйте, " + nowUser.FIO;
            GetClient();
            GetRate();
            GetPackages();
            GetSim(true);
            GetConnect();
        }
        public void GetClient()
        {
            materialDataTable2.AutoGenerateColumns = false;
            materialDataTable2.DataSource = db.Clients.ToList();
            materialDataTable2.Columns[0].DataPropertyName = "Id";
            materialDataTable2.Columns[1].DataPropertyName = "FIO";
            materialDataTable2.Columns[2].DataPropertyName = "Birthday";
            materialDataTable2.Columns[3].DataPropertyName = "Doc_number";
            materialDataTable2.Columns[4].DataPropertyName = "Doc_date";
            materialDataTable2.Columns[5].DataPropertyName = "Adres";
        }
        public void GetRate()
        {
            materialDataTable3.AutoGenerateColumns = false;
            materialDataTable3.DataSource = db.Rates.ToList();
            materialDataTable3.Columns[0].DataPropertyName = "Id";
            materialDataTable3.Columns[1].DataPropertyName = "Name";
            materialDataTable3.Columns[2].DataPropertyName = "Node";
            materialDataTable3.Columns[3].DataPropertyName = "Base_count";
            materialDataTable3.Columns[4].DataPropertyName = "Rate_category";
            materialDataTable3.Columns[5].DataPropertyName = "Actual";

            (materialDataTable3.Columns[4] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (materialDataTable3.Columns[4] as DataGridViewComboBoxColumn).ValueMember = "Id";
            (materialDataTable3.Columns[4] as DataGridViewComboBoxColumn).DataSource = db.Rate_Categoryes.ToList();

            (materialDataTable3.Columns[5] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (materialDataTable3.Columns[5] as DataGridViewComboBoxColumn).ValueMember = "Id";
            (materialDataTable3.Columns[5] as DataGridViewComboBoxColumn).DataSource = db.Rate_types.ToList();
        }
        public void GetPackages()
        {
            materialDataTable4.AutoGenerateColumns = false;
            materialDataTable4.DataSource = db.Packages.ToList();
            materialDataTable4.Columns[0].DataPropertyName = "Id";
            materialDataTable4.Columns[1].DataPropertyName = "Name";
            materialDataTable4.Columns[2].DataPropertyName = "Node";
            materialDataTable4.Columns[3].DataPropertyName = "Count";
            materialDataTable4.Columns[3].DefaultCellStyle.Format = "N2";
        }
        public void GetSim(bool flag)
        {
            materialDataTable1.AutoGenerateColumns = false;
            if (!flag)
                materialDataTable1.DataSource = db.Sim_Cards.ToList();
            else
                materialDataTable1.DataSource = db.Sim_Cards.Where(x => x.Dostup == 1).ToList();
            materialDataTable1.Columns[0].DataPropertyName = "Id";
            materialDataTable1.Columns[1].DataPropertyName = "Number";
            materialDataTable1.Columns[2].DataPropertyName = "Node";
            materialDataTable1.Columns[3].DataPropertyName = "Base_count";
        }
        public void GetConnect()
        {
            materialDataTable5.AutoGenerateColumns = false;
            materialDataTable5.DataSource = db.Conections.ToList();
            materialDataTable5.Columns[0].DataPropertyName = "Id";
            materialDataTable5.Columns[1].DataPropertyName = "Id_client";
            materialDataTable5.Columns[2].DataPropertyName = "Id_sim";
            materialDataTable5.Columns[3].DataPropertyName = "Id_rate";
            materialDataTable5.Columns[4].DataPropertyName = "Id_emploer";
            materialDataTable5.Columns[5].DataPropertyName = "Count";

            (materialDataTable5.Columns[1] as DataGridViewComboBoxColumn).DisplayMember = "FIO";
            (materialDataTable5.Columns[1] as DataGridViewComboBoxColumn).ValueMember = "Id";
            (materialDataTable5.Columns[1] as DataGridViewComboBoxColumn).DataSource = db.Clients.ToList();

            (materialDataTable5.Columns[2] as DataGridViewComboBoxColumn).DisplayMember = "Number";
            (materialDataTable5.Columns[2] as DataGridViewComboBoxColumn).ValueMember = "Id";
            (materialDataTable5.Columns[2] as DataGridViewComboBoxColumn).DataSource = db.Sim_Cards.ToList();

            (materialDataTable5.Columns[3] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (materialDataTable5.Columns[3] as DataGridViewComboBoxColumn).ValueMember = "Id";
            (materialDataTable5.Columns[3] as DataGridViewComboBoxColumn).DataSource = db.Rates.ToList();

            (materialDataTable5.Columns[4] as DataGridViewComboBoxColumn).DisplayMember = "FIO";
            (materialDataTable5.Columns[4] as DataGridViewComboBoxColumn).ValueMember = "Id";
            (materialDataTable5.Columns[4] as DataGridViewComboBoxColumn).DataSource = db.Users.ToList();
        }

        #region Вкладка клиенты
        private void materialButton7_Click(object sender, EventArgs e)
        {
            if (materialDataTable2.SelectedRows.Count > 0)
            {
                if ((int)materialDataTable2.SelectedRows[0].Cells[0].Value > 0)
                    db.Clients.Remove(db.Clients.First(x => x.Id == (int)materialDataTable2.SelectedRows[0].Cells[0].Value));
                db.SaveChanges();
                GetClient();
            }
            else
                MessageBox.Show("Выберите клиента для удаления");
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.FIO = "";
            cl.Doc_date = DateTime.Now.ToShortDateString();
            cl.Birthday = DateTime.Now.ToShortDateString();
            cl.Doc_number = "1234 123456";
            cl.Adres = "";
            db.Clients.Add(cl);
            db.SaveChanges();
            GetClient();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            materialDataTable2.EndEdit();
            db.SaveChanges();
        }

        private void materialTextBox22_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox22.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            materialDataTable2.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in materialDataTable2.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in materialDataTable2.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[4].Value != null)
                        if (row.Cells[4].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[5].Value != null)
                        if (row.Cells[5].Value.ToString().ToLower().Contains(s)) flag = true;//поиск

                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }
        #endregion
        #region Вкладка опции
        private void materialTextBox24_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox24.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            materialDataTable4.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in materialDataTable4.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in materialDataTable4.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск


                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }
        #endregion
        #region Вкладка тарифы
        private void materialTextBox23_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox23.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            materialDataTable3.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in materialDataTable3.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in materialDataTable3.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск

                    var a = db.Rate_Categoryes.First(x => x.Id == (int)(row.Cells[4] as DataGridViewComboBoxCell).Value).Name;
                    if (a.ToLower().Contains(s)) flag = true;//поиск

                    var b = db.Rate_types.First(x => x.Id == (int)(row.Cells[5] as DataGridViewComboBoxCell).Value).Name;
                    if (b.ToLower().Contains(s)) flag = true;//поиск

                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }
        #endregion
        #region Вкладка Сим-карты
        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialDataTable1.EndEdit();
            db.SaveChanges();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            if (materialDataTable1.SelectedRows.Count > 0)
            {
                if ((int)materialDataTable1.SelectedRows[0].Cells[0].Value > 0)
                    db.Sim_Cards.Remove(db.Sim_Cards.First(x => x.Id == (int)materialDataTable1.SelectedRows[0].Cells[0].Value));
                db.SaveChanges();
                GetSim(materialCheckbox1.Checked);
            }
            else
                MessageBox.Show("Выберите клиента для удаления");
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Sim_card sim = new Sim_card();
            sim.Node = "";
            sim.Number = "";
            sim.Base_count = 0;
            sim.Dostup = 1;
            db.Sim_Cards.Add(sim);
            db.SaveChanges();
            GetSim(materialCheckbox1.Checked);
        }

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox21.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            materialDataTable1.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in materialDataTable1.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in materialDataTable1.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[1].Value != null)
                        if (row.Cells[1].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[2].Value != null)
                        if (row.Cells[2].Value.ToString().ToLower().Contains(s)) flag = true;//поиск
                    if (row.Cells[3].Value != null)
                        if (row.Cells[3].Value.ToString().ToLower().Contains(s)) flag = true;//поиск

                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }
        #endregion
        #region Вкладка подключение
        private void materialTextBox25_TextChanged(object sender, EventArgs e)
        {
            string s = materialTextBox25.Text.ToLower();
            //поиск 
            bool flag = false; //состояние поиска
            materialDataTable5.CurrentCell = null; //снимаем выделения строк с таблицы
            if (s.Equals("")) //если ничего не введено
            {
                foreach (DataGridViewRow row in materialDataTable5.Rows)
                {
                    row.Visible = true;//делаем все строчки видимыми
                }
            }
            else //если что-то ввели
            {
                foreach (DataGridViewRow row in materialDataTable5.Rows)
                {
                    flag = false;//состояние поиска - не найдено
                    if (row.Cells[5].Value != null)
                        if (row.Cells[5].Value.ToString().ToLower().Contains(s)) flag = true;//поиск

                    var a = db.Clients.First(x => x.Id == (int)(row.Cells[1] as DataGridViewComboBoxCell).Value).FIO;
                    if (a.ToLower().Contains(s)) flag = true;//поиск

                    var b = db.Sim_Cards.First(x => x.Id == (int)(row.Cells[2] as DataGridViewComboBoxCell).Value).Number;
                    if (b.ToLower().Contains(s)) flag = true;//поиск

                    var c = db.Rates.First(x => x.Id == (int)(row.Cells[3] as DataGridViewComboBoxCell).Value).Name;
                    if (c.ToLower().Contains(s)) flag = true;//поиск

                    var d = db.Users.First(x => x.Id == (int)(row.Cells[4] as DataGridViewComboBoxCell).Value).FIO;
                    if (d.ToLower().Contains(s)) flag = true;//поиск

                    if (flag) row.Visible = true;//если нашли совпадение строчка видна
                    else row.Visible = false;//иначе скрываем
                }
            }
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            AddConnection add = new AddConnection(nowUser, db);
            add.ShowDialog();
            GetConnect();
            GetSim(materialCheckbox1.Checked);
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox1.Checked)
                GetSim(true);
            else
                GetSim(false);
        }
        #endregion

        private void materialDataTable5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((int)materialDataTable5.Rows[e.RowIndex].Cells[0].Value > 0)
            {
                ViewConnect view = new ViewConnect(db, (int)materialDataTable5.Rows[e.RowIndex].Cells[0].Value);
                view.ShowDialog();
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        DateTimePicker dtp;
        MaterialMaskedTextBox MMTB;
        DataGridViewColumn col;
        private void materialDataTable2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp_CloseUp(new object(), new EventArgs());
            if (materialDataTable2.Columns[e.ColumnIndex].DataPropertyName == "Birthday" ||
                materialDataTable2.Columns[e.ColumnIndex].DataPropertyName == "Doc_date")
            {
                // col = materialDataTable2.Columns[e.ColumnIndex];
                //col.ReadOnly = true;
                // initialize DateTimePicker
                dtp = new DateTimePicker();
                dtp.Format = DateTimePickerFormat.Short;
                dtp.Visible = true;
                dtp.Height = 100;
                try
                {
                    dtp.Value = DateTime.Parse(materialDataTable2.CurrentCell.Value.ToString());
                }
                catch
                {
                    dtp.Value = DateTime.Now;
                }

                // set size and location
                var rect = materialDataTable2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);

                // attach events
                dtp.CloseUp += new EventHandler(dtp_CloseUp);
                dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                dtp.LostFocus += new EventHandler(dtp_CloseUp);
                materialDataTable2.Controls.Add(dtp);
            }
            else
            {
                if (materialDataTable2.Columns[e.ColumnIndex].DataPropertyName == "Doc_number")
                {
                    // initialize DateTimePicker
                    MMTB = new MaterialMaskedTextBox();
                    MMTB.Mask = "0000 000000";
                    MMTB.Visible = true;
                    try
                    {
                        MMTB.Text = materialDataTable2.CurrentCell.Value.ToString();
                    }
                    catch
                    {
                        MMTB.Text = "";
                    }

                    // set size and location
                    var rect = materialDataTable2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    MMTB.Size = new Size(rect.Width, rect.Height);
                    MMTB.Location = new Point(rect.X, rect.Y);

                    // attach events
                    MMTB.LostFocus += new EventHandler(dtp_CloseUp);
                    MMTB.TextChanged += new EventHandler(MMTB_OnTextChange);

                    materialDataTable2.Controls.Add(MMTB);
                }
            }
        }

        // on text change of dtp, assign back to cell
        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            // col.ReadOnly = false;
            materialDataTable2.CurrentCell.Value = dtp.Text.ToString();
            // col.ReadOnly = true;
        }

        // on close of cell, hide dtp
        void dtp_CloseUp(object sender, EventArgs e)
        {
            //  col.ReadOnly = false;
            foreach (var com in materialDataTable2.Controls)
            {
                if (com.GetType() == typeof(DateTimePicker)) (com as DateTimePicker).Visible = false;
                if (com.GetType() == typeof(MaterialMaskedTextBox)) (com as MaterialMaskedTextBox).Visible = false;
            }
        }


        private void MMTB_OnTextChange(object sender, EventArgs e)
        {
            materialDataTable2.CurrentCell.Value = MMTB.Text.ToString();
        }
        MaterialMaskedTextBox MMTB1;
        private void materialDataTable1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp1_CloseUp(new object(), new EventArgs());
            if (e.RowIndex >= 0)
                if (materialDataTable1.Columns[e.ColumnIndex].DataPropertyName == "Number")
                {
                    // initialize DateTimePicker
                    MMTB1 = new MaterialMaskedTextBox();
                    MMTB1.Mask = "+7(000)-00-00-00";
                    MMTB1.Visible = true;
                    try
                    {
                        MMTB1.Text = materialDataTable1.CurrentCell.Value.ToString();
                    }
                    catch
                    {
                        MMTB1.Text = "";
                    }

                    // set size and location
                    var rect = materialDataTable1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    MMTB1.Size = new Size(rect.Width, rect.Height);
                    MMTB1.Location = new Point(rect.X, rect.Y);

                    // attach events
                    MMTB1.LostFocus += new EventHandler(dtp1_CloseUp);
                    MMTB1.TextChanged += new EventHandler(MMTB1_OnTextChange);

                    materialDataTable1.Controls.Add(MMTB1);
                }
        }
        void dtp1_CloseUp(object sender, EventArgs e)
        {
            //  col.ReadOnly = false;
            foreach (var com in materialDataTable1.Controls)
            {
                try
                {
                    if (com != null)
                        if (com.GetType() == typeof(MaterialMaskedTextBox)) (com as MaterialMaskedTextBox).Visible = false;
                }
                catch { }
            }
        }


        private void MMTB1_OnTextChange(object sender, EventArgs e)
        {
            materialDataTable1.CurrentCell.Value = MMTB1.Text.ToString();
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveClient(db);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveSim(db);
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveConnect(db);
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            ExcelExport.SaveRate(db);
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            ExcelExport.SavePac(db);
        }
    }
}

