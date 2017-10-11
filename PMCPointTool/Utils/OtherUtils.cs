using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;

namespace PMCPointTool
{
    class OtherUtils
    {
        public static object[,] convertDataTabelToArray(DataTable dt)
        {
            object[,] obj = null;
            int col = dt.Columns.Count;
            string[,] array = new string[dt.Rows.Count, col];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    array[i, j] = dt.Rows[i][j].ToString().Trim();
                }
            }
            obj = array;

            return obj;
        }

        public static DataTable convertArrayToDataTabel(String[,] arr)
        {
            DataTable dataSouce = new DataTable();
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                DataColumn newColumn = new DataColumn(i.ToString(), arr[0, 0].GetType());
                dataSouce.Columns.Add(newColumn);
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                DataRow newRow = dataSouce.NewRow();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    newRow[j.ToString()] = arr[i, j];
                }
                dataSouce.Rows.Add(newRow);
            }
            return dataSouce;
        }

        /// <summary> 记录日志
        /// 类型:txt;log
        /// filestream 操作字节流
        /// </summary>
        /// <param name="path">文件路径(含名)</param>
        /// <param name="functionName">方法名</param>
        /// <param name="logContent">内容</param>
        public static void writeMsgByByte(string path, string logContent)
        {
            using (System.IO.FileStream fileStream = new System.IO.FileStream(path, System.IO.FileMode.Append))
            {
                logContent = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " , " + logContent + Environment.NewLine; // \r\n
                byte[] buffer = Encoding.Default.GetBytes(logContent);
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// 去除括号内的字符
        /// </summary>
        /// <param name="sBracket">{}/[]/()/</param>
        /// <returns></returns>
        public static string getStringBetweenBracket(string sBracket)
        {
            string result = sBracket;
            List<string> list = new List<string>();
            list.Add("[");
            list.Add("]");
            list.Add("(");
            list.Add(")");
            list.Add("{");
            list.Add("}");
            list.Add("<");
            list.Add(">");

            foreach (string item in list)
                result = result.Replace(item, "");

            return result;
        }
    }
}
