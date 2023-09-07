using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmPromotion;
namespace WinFrmControls
{
    public partial class FrmMain : Form
    {
        //1.声明自适应类实例
        public readonly AutoSizeFormClass AutoSizeFrm = new AutoSizeFormClass();
        public FrmMain()
        {
            InitializeComponent();
            SetFrmMainProperty(this);
        }
        private void SetFrmMainProperty(Form frm)
        {

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Left = 100;
            frm.Top = 100;
            frm.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            frm.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
            frm.TopMost = true;
            AutoSizeFrm.controllInitializeSize(frm);
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            AutoSizeFrm.controlAutoSize(this);
        }
    }
}
