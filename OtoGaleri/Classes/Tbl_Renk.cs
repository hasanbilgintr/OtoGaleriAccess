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
    class Tbl_Renk
    {
        Baglanti bgl = new Baglanti();
        OleDbDataAdapter akmt;
        OleDbCommand ckmt;
        OleDbDataReader oku;
        DataTable dt;
        public void RenkListCmb(ComboBox Renk)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Renk Order By Ad", bgl.baglanti());
            dt = new DataTable();
            akmt.Fill(dt);
            Renk.DisplayMember = "Ad";
            Renk.ValueMember = "ID";
            Renk.DataSource = dt;
            bgl.baglanti().Close();
        }


    }
}
