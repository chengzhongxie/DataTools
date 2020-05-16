using Common;
using Common.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    /// <summary>
    /// 文件公共工具
    /// </summary>
    public class FileUtilities : Utilities
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileClass { get; set; }
        /// <summary>
        /// 文件还是文件夹
        /// </summary>
        public string FolderIfFile { get; set; }
        /// <summary>
        /// 文件参数
        /// </summary>
        /// <param name="fileClass">文件类型</param>
        /// <param name="folderIfFile">文件还是文件夹</param>
        public FileUtilities(string fileClass, string folderIfFile)
        {
            // 非空判断
            if (string.IsNullOrWhiteSpace(fileClass) || string.IsNullOrWhiteSpace(folderIfFile))
            {
                LogUtilities.WriteLog("ArgumentException", ClassMethodName, $"{nameof(fileClass)}:{fileClass}|{nameof(folderIfFile)}:{folderIfFile}");
                throw new ArgumentException("message", nameof(fileClass));
            }
            // 校验参数格式
            if ( fileClass != FileEnum.JsonFiles && fileClass != FileEnum.XMLFiles)
            {
                LogUtilities.WriteLog("FormatException", ClassMethodName, $"{nameof(FileClass)}:{FileClass}");
                throw new FormatException("fileClass");
            }
            FileClass = fileClass;
            FolderIfFile = folderIfFile;
        }

        #region 选择文件/文件夹工具
        /// <summary>
        /// 选择文件/文件夹
        /// </summary>
        /// <returns></returns>
        public string SelectFile()
        {
            return FolderIfFile == FileEnum.Files ? OpenFileDialog() : FolderBrowserDialog();
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <returns></returns>
        private string OpenFileDialog()
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//默认打开路径
            //openFileDialog.Filter = "文本文件|*.txt|word文件|*.doc;*.docx|所有文件|*.*";//过滤文件格式 
            openFileDialog.Filter = FileClass == FileEnum.JsonFiles ? "Json文件|*.json" : "XML文件|*.xml";//过滤文件格式 
            openFileDialog.FilterIndex = 2;//格式索引
            openFileDialog.RestoreDirectory = false;//每次打卡文件是否恢复默认路径

            //判断用户是否正确的选择了文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //fileDialog.FileName：文件的全路径，如“C:\Users\lenovo\Desktop\新建文件夹\微信图片_20190401154431.jpg”
                //fileDialog.SafeFileName：文件的名称，如“微信图片_20190401154431.jpg”
                //----------------此处和openFileDialog1.Filter写一个即可
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(openFileDialog.FileName);
                //声明允许的后缀名
                //string[] str = new string[] { ".gif", ".jpge", ".jpg" };
                string[] str = FileClass == FileEnum.JsonFiles ? new string[] { ".json" } : new string[] { ".xml" };
                if (!((IList)str).Contains(extension))
                {
                    MessageCommon.ShowErr("请上传正确的文件类型！");
                }
                else
                {
                    //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                    //FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    //if (fileInfo.Length > 20480)
                    //{
                    //    MessageBox.Show("上传的图片不能大于20K");
                    //}
                    //else
                    //{
                    //    //在这里就可以写获取到正确文件后的代码了
                    //}
                    return openFileDialog.FileName;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <returns></returns>
        private string FolderBrowserDialog()
        {
            string defaultPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //打开的文件夹浏览对话框上的描述  
            dialog.Description = "请选择一个文件夹";
            //是否显示对话框左下角 新建文件夹 按钮，默认为 true  
            dialog.ShowNewFolderButton = false;
            //首次defaultPath为空，按FolderBrowserDialog默认设置（即桌面）选择  
            if (defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录  
                dialog.SelectedPath = defaultPath;
            }
            //按下确定选择的按钮  
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultPath = dialog.SelectedPath;
            }
            return defaultPath;
        }
        #endregion
    }
}
