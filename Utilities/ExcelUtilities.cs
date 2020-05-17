using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    /// <summary>
    /// Excel工具类
    /// </summary>
    public class ExcelUtilities : Utilities
    {

        /// <summary>
        /// Excel 转换为 Datatable
        /// </summary>
        /// <param name="fileUrl">Excel文件路径</param>
        /// <param name="sheetNum">工作表索引</param>
        /// <param name="isFirstRowColumn">首行为列</param>
        /// <returns></returns>
        public DataTable ExcelToDataTable(string fileUrl, int sheetNum = 0, bool isFirstRowColumn = true)
        {
            Dictionary<string, string> valuePairs = null;
            if (string.IsNullOrWhiteSpace(fileUrl))
            {
                valuePairs = new Dictionary<string, string>();
                valuePairs.Add("fileUrl", fileUrl);
                LogUtilities.IsNullErrorLog(valuePairs);
            }
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable myTable = new DataTable();
            try
            {
                using (var fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read))
                {
                    if (fileUrl.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    else if (fileUrl.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);
                    sheet = workbook.GetSheetAt(sheetNum);
                }
                //工作表不能为空
                if (sheet == null)
                {
                    string str = "";
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        str += workbook.GetSheetAt(i).SheetName + ",";
                    }
                    str = workbook.NumberOfSheets + str;
                    throw new Exception($"sheet不能为空！参数：{sheetNum} 工作簿信息：{str}");
                }

                //Excel最大列数
                int MaxColumnNum = 0;
                for (int i = 0; i < sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.LastCellNum > MaxColumnNum)
                    {
                        MaxColumnNum = row.LastCellNum;
                    }
                }
                //Excel行数
                int MaxRowNum = sheet.LastRowNum;

                //table新增列
                for (int i = 0; i < MaxColumnNum; ++i)
                {
                    //首行为列
                    if (isFirstRowColumn)
                    {
                        bool addEmptyCell = true;//是否添加空列
                        ICell cell = sheet.GetRow(0).GetCell(i);
                        if (cell != null)
                        {
                            //table列赋值
                            string cellValue = "";//列名
                            if (cell.CellType == CellType.Numeric)
                            {
                                cellValue = cell.NumericCellValue.ToString();
                            }
                            else
                            {
                                cellValue = cell.StringCellValue;
                            }
                            if (!string.IsNullOrWhiteSpace(cellValue))
                            {
                                //列数据为Excel的数据
                                addEmptyCell = false;
                                myTable.Columns.Add(new DataColumn(cellValue));
                            }
                        }
                        if (addEmptyCell)
                        {
                            myTable.Columns.Add(new DataColumn(""));//列数据为空
                        }
                    }
                    else
                    {
                        myTable.Columns.Add(new DataColumn(i + ""));
                    }
                }

                //起始行
                int startRow = 0;
                if (isFirstRowColumn)
                {
                    startRow = 1;
                }

                //DataTable赋值
                for (int i = startRow; i <= MaxRowNum; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    DataRow NewRow = myTable.NewRow();
                    for (int j = row.FirstCellNum; j < row.LastCellNum; ++j)
                    {
                        ICell cell = row.GetCell(j);
                        string value = "";
                        if (cell != null)
                        {
                            //table行赋值                            
                            if (cell.CellType == CellType.Numeric)
                            {
                                value = cell.NumericCellValue.ToString();
                                if ((j == 0) && ((i == 6) || (i == 12)))
                                {
                                    //特殊的几个单元格 转换为 日期格式
                                    value = ToDateTimeValue(cell.NumericCellValue.ToString());
                                }
                            }
                            else
                            {
                                //row.GetCell(j).SetCellType(CellType.String);
                                value = cell.StringCellValue;
                            }
                        }
                        NewRow[j] = value;
                    }
                    myTable.Rows.Add(NewRow);
                }
                return myTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DataTable 转换为 Html
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetHtmlString(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head>");
            sb.Append("<title>Excel转换为Table</title>");
            sb.Append("<meta http-equiv='content-type' content='text/html; charset=GB2312'> ");
            sb.Append("<style type=text/css>");
            sb.Append("td{font-size: 9pt;border:solid 1 #000000;}");
            sb.Append("table{padding:3 0 3 0;border:solid 1 #000000;margin:0 0 0 0;BORDER-COLLAPSE: collapse;}");
            sb.Append("</style>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<table cellSpacing='0' cellPadding='0' width ='100%' border='1'>");
            sb.Append("<tr valign='middle'>");
            sb.Append("<td><b></b></td>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<td><b><span>" + column.ColumnName + "</span></b></td>");
            }
            sb.Append("</tr>");
            int iColsCount = dt.Columns.Count;
            int rowsCount = dt.Rows.Count - 1;
            for (int j = 0; j <= rowsCount; j++)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + ((int)(j + 1)).ToString() + "</td>");
                for (int k = 0; k <= iColsCount - 1; k++)
                {
                    sb.Append("<td>");
                    object obj = dt.Rows[j][k];
                    if (obj == DBNull.Value)
                    {
                        obj = "&nbsp;";//如果是NULL则在HTML里面使用一个空格替换之
                    }
                    if (obj.ToString() == "")
                    {
                        obj = "&nbsp;";
                    }
                    string strCellContent = obj.ToString().Trim();
                    sb.Append("<span>" + strCellContent + "</span>");
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            //点击单元格 输出 行和列
            sb.Append("<script src='https://cdn.bootcss.com/jquery/1.12.4/jquery.min.js'></script>");
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('table tbody').on('click', 'td', function (e) {");
            sb.Append("var row = $(this).parent().prevAll().length-1 ;");
            sb.Append("var column = $(this).prevAll().length-1 ;");
            sb.Append("var str = 'dt.Rows[' + row + '][' + column + '].ToString()';");
            sb.Append("console.log(str);alert(str);");
            sb.Append("});");
            sb.Append("</script>");

            sb.Append("</body></html>");
            return sb.ToString();
        }

        /// <summary>
        /// Datatable转换Excel保存文件
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="saveUrl">保存地址</param>
        public bool ToExcel(DataTable dt, string saveUrl)
        {
            var FilePath = saveUrl;//产生Excel文件路径
            //创建全新的Workbook 
            var workbook = new HSSFWorkbook();//一個sheet最多65536行
            var count = 0;
            for (double i = 0; i < Convert.ToDouble(dt.Rows.Count) / Convert.ToDouble(65534); i++)//每个Excel文件的一个页签只能存放65536行数据
            {
                var row_index = 0;
                //创建Sheet
                workbook.CreateSheet("Sheet" + i);
                //根据Sheet名字获得Sheet对象  
                var sheet = workbook.GetSheet("Sheet" + i);
                IRow row;
                row = sheet.CreateRow(row_index);

                //写入标题
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(dt.Columns[j].Caption.ToString());
                }
                row = sheet.CreateRow(++row_index);

                //写入数据
                for (int j = 0; j < (dt.Rows.Count - count > 65534 ? 65534 : dt.Rows.Count - count); j++)
                {
                    var r = dt.Rows[j + count];
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        row.CreateCell(k).SetCellValue(r[k].ToString());

                        //如果是数字,判断是否需要转换为数字
                        //if (IsNumeric(r[k].ToString()))
                        //{
                        //    row.CreateCell(k).SetCellValue(Convert.ToDouble(r[k].ToString()));
                        //}
                        //else
                        //{
                        //    row.CreateCell(k).SetCellValue(r[k].ToString());
                        //}
                    }

                    row = sheet.CreateRow(++row_index);
                }
                count += row_index - 2;
            }
            //保存Workbook方式一： 以文件形式保存到服务器中（每次导出都会生成一个文件，慎重使用）
            var FileName = $"\\{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls";
            var sw = File.Create(FilePath + FileName);
            workbook.Write(sw);
            sw.Close();
            return true;
        }

        /// <summary>
        /// 数字格式的时间 转换为 字符串格式的时间
        /// 数字格式的时间 如： 42095.7069444444/0.650694444444444
        /// </summary>
        /// <param name="timeStr">数字,如:42095.7069444444/0.650694444444444</param>
        /// <returns>日期/时间格式</returns>
        private string ToDateTimeValue(string strNumber)
        {
            if (!string.IsNullOrWhiteSpace(strNumber))
            {
                Decimal tempValue;
                //先检查 是不是数字;
                if (Decimal.TryParse(strNumber, out tempValue))
                {
                    //天数,取整
                    int day = Convert.ToInt32(Math.Truncate(tempValue));
                    //这里也不知道为什么. 如果是小于32,则减1,否则减2
                    //日期从1900-01-01开始累加 
                    // day = day < 32 ? day - 1 : day - 2;
                    DateTime dt = new DateTime(1900, 1, 1).AddDays(day < 32 ? (day - 1) : (day - 2));

                    //小时:减掉天数,这个数字转换小时:(* 24) 
                    Decimal hourTemp = (tempValue - day) * 24;//获取小时数
                                                              //取整.小时数
                    int hour = Convert.ToInt32(Math.Truncate(hourTemp));
                    //分钟:减掉小时,( * 60)
                    //这里舍入,否则取值会有1分钟误差.
                    Decimal minuteTemp = Math.Round((hourTemp - hour) * 60, 2);//获取分钟数
                    int minute = Convert.ToInt32(Math.Truncate(minuteTemp));
                    //秒:减掉分钟,( * 60)
                    //这里舍入,否则取值会有1秒误差.
                    Decimal secondTemp = Math.Round((minuteTemp - minute) * 60, 2);//获取秒数
                    int second = Convert.ToInt32(Math.Truncate(secondTemp));

                    //时间格式:00:00:00
                    string resultTimes = string.Format("{0}:{1}:{2}",
                            (hour < 10 ? ("0" + hour) : hour.ToString()),
                            (minute < 10 ? ("0" + minute) : minute.ToString()),
                            (second < 10 ? ("0" + second) : second.ToString()));

                    if (day > 0)
                        return string.Format("{0} {1}", dt.ToString("yyyy-MM-dd"), resultTimes);
                    else
                        return resultTimes;
                }
            }
            return string.Empty;
        }
    }
}
