using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMANAGERMENT
{
    public static class newMessBox
    {
        public static DialogResult Show(string notice, string caption, MessageBoxButtons button)
        {
            DialogResult dialogResult = DialogResult.None;
            switch (button)
            {
                case MessageBoxButtons.OK:
                    using (MessageOK msbOK = new MessageOK())
                    {
                        msbOK.Text = msbOK.Caption = caption;
                        msbOK.Message = notice;
                        dialogResult = msbOK.ShowDialog();
                    }
                    break;
                case MessageBoxButtons.OKCancel:
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    break;
                case MessageBoxButtons.YesNoCancel:
                    break;
                case MessageBoxButtons.YesNo:
                    using (MessageYesNo msbYesNo = new MessageYesNo())
                    {
                        msbYesNo.Text = msbYesNo.Caption = caption;
                        msbYesNo.Message = notice;
                        dialogResult = msbYesNo.ShowDialog();
                    }
                    break;
                case MessageBoxButtons.RetryCancel:
                    break;
                default:
                    break;
            }
            return dialogResult;
        }
    }
}
