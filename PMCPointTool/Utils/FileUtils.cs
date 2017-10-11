using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data;

namespace PMCPointTool
{
    class FileUtils
    {
        public static bool createExcel(object[,] oDatas, Excel.XlFileFormat fileFormat, string sPath, out string sErrString)
        {
            bool flag = false;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(true);
            Excel.Worksheet worksheet = workbook.ActiveSheet as Excel.Worksheet;
            sErrString = "";

            try
            {
                int rows = oDatas.GetLength(0);
                int clumns = oDatas.GetLength(1);
                Excel.Range CellStart = worksheet.Cells[1, 1];
                Excel.Range CellEnd = worksheet.Cells[rows, clumns];
                Excel.Range range = worksheet.Range[CellStart, CellEnd];
                range.Value2 = oDatas;
                workbook.SaveAs(sPath, fileFormat, Missing.Value, Missing.Value, Missing.Value,
                                              Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value,
                                              Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                excel.DisplayAlerts = false;
                flag = true;
            }
            catch (Exception e)
            {
                sErrString = e.ToString();
            }
            finally
            {
                //释放内存
                if (workbook != null)
                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (excel.Workbooks != null)
                    excel.Workbooks.Close();
                if (excel != null)
                    excel.Quit();

                worksheet = null;
                workbook = null;
                excel = null;
            }

            return flag;

        }

        public static DataTable readExcelByOleDb(string filePath, string sheetName, bool hasTitle = false)
        {
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType)) return null;

            try
            {
                using (DataSet ds = new DataSet())
                {
                    //>excel2007是12.0,<2007是4.0
                    string strCon = string.Format("Provider=Microsoft.ACE.OLEDB.{0}.0;" +
                                    "Extended Properties=\"Excel {1}.0;HDR={2};IMEX=1;\";" +
                                    "data source={3};",
                                    (fileType == ".xls" ? 4 : 12), (fileType == ".xls" ? 8 : 12), (hasTitle ? "Yes" : "NO"), filePath);
                    string strCom = " SELECT * FROM [" + sheetName + "$]";
                    using (System.Data.OleDb.OleDbConnection myConn = new System.Data.OleDb.OleDbConnection(strCon))
                    using (System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, myConn))
                    {
                        myConn.Open();
                        myCommand.Fill(ds);
                    }
                    if (ds == null || ds.Tables.Count <= 0) return null;
                    return ds.Tables[0];
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable readExcelByCom(string filePath, int sheetNo, string sheetName = "", bool hasTitle = false)
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;
            DataTable dt = new DataTable();

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                Excel.Worksheet worksheet = null;

                if (sheetNo != 0)
                {
                    //将数据读入到DataTable中
                    worksheet = (Excel.Worksheet)sheets.get_Item(sheetNo);//读取第几张表  
                }
                else
                {
                    worksheet = (Excel.Worksheet)sheets.get_Item(sheetName);
                }

                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                //生成列头
                for (int i = 0; i < iColCount; i++)
                {
                    var name = "column" + i;
                    if (hasTitle)
                    {
                        var txt = ((Excel.Range)worksheet.Cells[1, i + 1]).Text.ToString();
                        if (!string.IsNullOrWhiteSpace(txt)) name = txt;
                    }
                    while (dt.Columns.Contains(name)) name = name + "_1";//重复行名称会报错。
                    dt.Columns.Add(new DataColumn(name, typeof(string)));
                }
                //生成行数据
                Excel.Range range;
                int rowIdx = hasTitle ? 2 : 1;
                for (int iRow = rowIdx; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Excel.Range)worksheet.Cells[iRow, iCol];
                        dr[iCol - 1] = (range.Value2 == null) ? "" : range.Text.ToString();
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }

        public static string[] getExcelPathByOfdlg()
        {
            string[] names = null;

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.Multiselect = true;
            System.Windows.Forms.DialogResult result = dlg.ShowDialog();

            //取消
            if (dlg.FileName.IndexOf(":") < 0)
                names = new string[] { string.Empty };

            if (result == System.Windows.Forms.DialogResult.OK)
                names = dlg.FileNames;

            return names;
        }

        public static string getSaveDlgPath()
        {
            string path = "";
            System.Windows.Forms.SaveFileDialog sfdlg = new System.Windows.Forms.SaveFileDialog();
            sfdlg.Filter = "CSV文件(*.csv)|*.csv";
            sfdlg.RestoreDirectory = true;
            System.Windows.Forms.DialogResult result = sfdlg.ShowDialog();
            //取消  
            if (sfdlg.FileName.IndexOf(":") < 0)
                path = string.Empty;

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //获得文件路径  
                path = sfdlg.FileName.ToString();
                //string filname = this.openFileDialog2.FileName;
                //获取文件名，不带路径  
                //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);  

                //获取文件路径，不带文件名  
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));  

                //给文件名前加上时间  
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;  

                //在文件名里加字符  
                //saveFileDialog1.FileName.Insert(1,"dameng");  

                //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();//输出文件 
            }

            return path;
        }

    }
}
