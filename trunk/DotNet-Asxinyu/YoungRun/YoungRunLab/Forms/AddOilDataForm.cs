using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YoungRunLab.Forms
{
    public partial class AddOilDataForm : Form
    {
        public AddOilDataForm()
        {
            InitializeComponent();
            addOilData1.IsNext = true;
        }
        public string GetDataID()
        {
        	return this.addOilData1.GetDataID () ;
        }
        public bool IsNext 
        {
            get {return addOilData1.IsNext; }
            set { addOilData1.IsNext = value;}
        }
    }
}
