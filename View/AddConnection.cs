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

namespace MTS_service.View
{
    public partial class AddConnection : MaterialForm
    {
        ApplicationContext db;
        int count = 0;
        User nowUser;
        List<Package> nowZakaz = new List<Package>();
        public AddConnection(User nowUser, ApplicationContext db)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.WHITE);
            this.db = db;
            this.nowUser = nowUser;
            materialComboBox1.DisplayMember = "FIO";
            materialComboBox1.ValueMember = "Id";
            materialComboBox1.DataSource = db.Clients.ToList();

            materialComboBox2.DisplayMember = "Number";
            materialComboBox2.ValueMember = "Id";
            materialComboBox2.DataSource = db.Sim_Cards.Where(x => x.Dostup == 1).ToList();

            materialComboBox3.DisplayMember = "Name";
            materialComboBox3.ValueMember = "Id";
            materialComboBox3.DataSource = db.Rates.ToList();
            materialComboBox3.SelectedIndex = 0;
            GetPackages();
        }
        public void GetPackages()
        {
            materialDataTable4.AutoGenerateColumns = false;
            materialDataTable4.DataSource = db.Packages.ToList();
            materialDataTable4.Columns[0].DataPropertyName = "Id";
            materialDataTable4.Columns[1].DataPropertyName = "Name";
            materialDataTable4.Columns[2].DataPropertyName = "Node";
            materialDataTable4.Columns[3].DataPropertyName = "Count";

            materialDataTable1.AutoGenerateColumns = false;
            materialDataTable1.DataSource = nowZakaz.GetRange(0, nowZakaz.Count);
            materialDataTable1.Columns[0].DataPropertyName = "Id";
            materialDataTable1.Columns[1].DataPropertyName = "Name";
            materialDataTable1.Columns[2].DataPropertyName = "Node";
            materialDataTable1.Columns[3].DataPropertyName = "Count";
            CalculatCount();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialDataTable4.SelectedRows.Count > 0)
            {
                if ((int)materialDataTable4.SelectedRows[0].Cells[0].Value > 0)
                    nowZakaz.Add(db.Packages.First(x => x.Id == (int)materialDataTable4.SelectedRows[0].Cells[0].Value));
                materialDataTable1.DataSource = null;
                materialDataTable1.DataSource = nowZakaz.GetRange(0, nowZakaz.Count);
                CalculatCount();
            }
            else
                MessageBox.Show("Выберите опцию для добавления");
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (materialDataTable1.SelectedRows.Count > 0)
            {
                if ((int)materialDataTable1.SelectedRows[0].Cells[0].Value > 0)
                    nowZakaz.Remove(nowZakaz.First(x => x.Id == (int)materialDataTable1.SelectedRows[0].Cells[0].Value));
                materialDataTable1.DataSource = null;
                materialDataTable1.DataSource = nowZakaz.GetRange(0, nowZakaz.Count);
                CalculatCount();
            }
            else
                MessageBox.Show("Выберите опцию для удаления из заказа");
        }

        public void CalculatCount()
        {
            if (materialComboBox3.SelectedValue != null)
            {
                count = 0;
                count += db.Rates.First(x => x.Id == (int)materialComboBox3.SelectedValue).Base_count;
                foreach (var package in nowZakaz)
                {
                    count += package.Count;
                }
                materialLabel4.Text = "Итого к оплате: " + count + " руб.";
            }
        }

        private void materialComboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculatCount();
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            Conection con = new Conection();
            con.Id_emploer = nowUser.Id;
            con.Id_rate = (int)materialComboBox3.SelectedValue;
            con.Id_client = (int)materialComboBox1.SelectedValue;
            con.Id_sim = (int)materialComboBox2.SelectedValue;
            con.Count = count;
            db.Conections.Add(con);
            db.Sim_Cards.First(x => x.Id == con.Id_sim).Dostup = 2;
            db.SaveChanges();
            foreach (var package in nowZakaz)
            {
                var pac = new Packages_on_connection();
                pac.Id_package = package.Id;
                pac.Id_connect = con.Id;
                db.Packages_on_connections.Add(pac);
            }
            db.SaveChanges();
            this.Close();
        }
    }
}
