using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoungRunEntity ;

namespace YoungRunST.Forms
{
    public partial class AddOilTankInfoForm : Form
    {
        public AddOilTankInfoForm()
        {
            InitializeComponent();
        }
        public List<tb_oiltankinfo> ModelList
        {
            get { return addOilTankInfo1.ModelList; }
            set { addOilTankInfo1.ModelList = value; }
        }
        public tb_oiltankinfo Model
        {
            get { return addOilTankInfo1.Model; }
            set {addOilTankInfo1.Model = value; } 
        }
    }
}
