using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmPromotion
{
    public partial class 控件自适应窗体变化 : Form
    {

        public 控件自适应窗体变化()
        {
            InitializeComponent();
        }

        //1.声明自适应类实例
       public readonly AutoSizeFormClass asc = new AutoSizeFormClass();
        private void 控件自适应窗体变化_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
        private void 控件自适应窗体变化_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }

}
