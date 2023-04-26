using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace MTS_service.Control
{
    public class ExcelExport
    {
        public static void SaveEmploer(Model.ApplicationContext db)
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные о сотрудниках?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Сотрудники";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "ФИО";
                    sheet.Cells[1, 3] = "Логин";
                    sheet.Cells[1, 4] = "Пароль";
                    sheet.Cells[1, 5] = "Должность";


                    int i = 1;
                    var n = 0;
                    foreach (var y in db.Users.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = y.FIO;
                        sheet.Cells[i, 3] = y.Login;
                        sheet.Cells[i, 4] = y.Password;
                        sheet.Cells[i, 5] = db.Categoryes.First(x => x.Id == y.User_category).Name;

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 5];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }

            }
        }



        public static void SaveClient(Model.ApplicationContext db)
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные о клиентах?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Клиенты";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "ФИО";
                    sheet.Cells[1, 3] = "Дата рождения";
                    sheet.Cells[1, 4] = "Номер документа";
                    sheet.Cells[1, 5] = "Дата документа";
                    sheet.Cells[1, 6] = "Прописка";

                    int i = 1;
                    var n = 0;
                    foreach (var y in db.Clients.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = y.FIO;
                        sheet.Cells[i, 3] = y.Birthday;
                        sheet.Cells[i, 4] = y.Doc_number;
                        sheet.Cells[i, 5] = y.Doc_date;
                        sheet.Cells[i, 6] = y.Adres;

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 6];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }

            }
        }



        public static void SaveRate(Model.ApplicationContext db)
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные о тарифах?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Тарифв";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "Название";
                    sheet.Cells[1, 3] = "Описание";
                    sheet.Cells[1, 4] = "Стоимость";
                    sheet.Cells[1, 5] = "Тип тарифа";
                    sheet.Cells[1, 6] = "Актуальность";

                    int i = 1;
                    var n = 0;
                    foreach (var y in db.Rates.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = y.Name;
                        sheet.Cells[i, 3] = y.Node;
                        sheet.Cells[i, 4] = y.Base_count;
                        sheet.Cells[i, 5] = db.Rate_Categoryes.First(x => x.Id == y.Rate_category).Name;
                        sheet.Cells[i, 6] = db.Rate_types.First(x => x.Id == y.Actual).Name;

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 6];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }

            }
        }

        public static void SavePac(Model.ApplicationContext db)
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные о дполнительных опциях?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Тарифв";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "Название";
                    sheet.Cells[1, 3] = "Описание";
                    sheet.Cells[1, 4] = "Стоимость";


                    int i = 1;
                    var n = 0;
                    foreach (var y in db.Packages.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = y.Name;
                        sheet.Cells[i, 3] = y.Node;
                        sheet.Cells[i, 4] = y.Count;

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 4];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }

            }
        }



        public static void SaveConnect(Model.ApplicationContext db)
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные о подключенных абонентах?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Тарифв";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "ФИО клиента";
                    sheet.Cells[1, 3] = "Номер";
                    sheet.Cells[1, 4] = "Тариф";
                    sheet.Cells[1, 5] = "Продавец";
                    sheet.Cells[1, 6] = "Стоимость";

                    int i = 1;
                    var n = 0;
                    foreach (var y in db.Conections.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = db.Clients.First(x => x.Id == y.Id_client).FIO;
                        sheet.Cells[i, 3] = db.Sim_Cards.First(x => x.Id == y.Id_sim).Number;
                        sheet.Cells[i, 4] = db.Rates.First(x => x.Id == y.Id_rate).Name;
                        sheet.Cells[i, 5] = db.Users.First(x => x.Id == y.Id_emploer).FIO;
                        sheet.Cells[i, 6] = y.Count;
                        if (db.Packages_on_connections.Where(x=>x.Id_connect == y.Id).Count()>0)
                        {
                            i++;
                            sheet.Cells[i, 2] = "Опции в заказе";
                            foreach (var g in db.Packages_on_connections.Where(x => x.Id_connect == y.Id).ToList())
                            {
                                i++;
                                sheet.Cells[i, 2] = db.Packages.First(x => x.Id == g.Id_package).Name;
                                sheet.Cells[i, 6] = db.Packages.First(x => x.Id == g.Id_package).Count;
                            }
                         }
                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 6];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }

            }
        }


        public static  void SaveSim(Model.ApplicationContext db)
        {

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные о симкартах?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Сим-карты";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "Номер";
                    sheet.Cells[1, 3] = "Описание";
                    sheet.Cells[1, 4] = "Стоимость";
                    sheet.Cells[1, 5] = "Актуальность";

                    int i = 1;
                    var n = 0;
                    foreach (var y in db.Sim_Cards.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = y.Number;
                        sheet.Cells[i, 3] = y.Node;
                        sheet.Cells[i, 4] = y.Base_count;
                        sheet.Cells[i, 5] = y.Dostup == 1? "Доступен к продаже" : "Продан";

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 5];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }

            }
        }
    }
}
