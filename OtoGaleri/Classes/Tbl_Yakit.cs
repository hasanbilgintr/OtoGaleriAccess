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
    class Tbl_Yakit
    {
        Baglanti bgl = new Baglanti();
        OleDbDataAdapter akmt;
        OleDbCommand ckmt;
        OleDbDataReader oku;
        DataTable dt;
        public void YakitListCmb(ComboBox Yakit)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Yakit Order By Ad", bgl.baglanti());
            dt = new DataTable();
            akmt.Fill(dt);
            Yakit.DisplayMember = "Ad";
            Yakit.ValueMember = "ID";
            Yakit.DataSource = dt;
            bgl.baglanti().Close();
        }

    }
}
