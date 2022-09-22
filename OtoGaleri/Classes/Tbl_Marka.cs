using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleri.Classes
{
   public  class Tbl_Marka
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataAdapter akmt;
        DataTable dt;
        OleDbDataReader oku;
        public void MarkaListCmb(ComboBox  marka)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Marka Order By Ad",bgl.baglanti());
            dt = new DataTable();
            akmt.Fill(dt);
            marka.DisplayMember = "Ad";
            marka.ValueMember = "ID";
            marka.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
