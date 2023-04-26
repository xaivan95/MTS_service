using MaterialSkin2DotNet;
using MaterialSkin2DotNet.Controls;
using MTS_service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTS_service.View
{
    public partial class ViewConnect : MaterialForm
    {
        public ViewConnect(Model.ApplicationContext db, int id)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.WHITE);
            materialDataTable4.AutoGenerateColumns = false;
            var result = db.Packages.Join(db.Packages_on_connections.Where(x=>x.Id_connect==id),
                x => x.Id,
                y => y.Id_package,
                (x, y) => new Package
                {
                    Id = x.Id,
                    Name = x.Name,
                    Node = x.Node,
                    Count = x.Count
                }
                ).ToList();
            materialDataTable4.DataSource = result;
            materialDataTable4.Columns[0].DataPropertyName = "Id";
            materialDataTable4.Columns[1].DataPropertyName = "Name";
            materialDataTable4.Columns[2].DataPropertyName = "Node";
            materialDataTable4.Columns[3].DataPropertyName = "Count";
        }
    }
}
