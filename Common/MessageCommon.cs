using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class MessageCommon
    {
        /// <summary>
        /// 根据类型弹出提示框
        /// </summary>
        /// <param name="type">类型 war:警告  que:询问  err:错误  其他默认为消息提示 </param>
        /// <param name="msg">消息</param>
        private static DialogResult ShowMassage(string type, string msg)
        {

            switch (type)
            {
                case "war":
                    return MessageBox.Show(msg, "警告!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                case "que":
                    return MessageBox.Show(msg, "是否继续?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                case "err":
                    return MessageBox.Show(msg, "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                default:
                    return MessageBox.Show(msg, "提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 警告提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static DialogResult ShowWar(string msg)
        {
            return ShowMassage("war", msg);
        }

        /// <summary>
        /// 询问提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns>DialogResult.OK or DialogResult.Cancel</returns>
        public static DialogResult ShowQue(string msg)
        {
            return ShowMassage("que", msg);
        }

        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static DialogResult ShowErr(string msg)
        {
            return ShowMassage("err", msg);
        }

        /// <summary>
        /// 一般提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static DialogResult ShowInf(string msg)
        {
            return ShowMassage("inf", msg);
        }
    }
}
