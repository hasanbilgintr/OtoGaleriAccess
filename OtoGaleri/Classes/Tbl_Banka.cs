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
    public class Tbl_Banka
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataAdapter akmt;
        OleDbDataReader oku;
        DataTable dt;

        public void BankaListCmb(ComboBox bankalar)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Banka", bgl.baglanti());
            dt = new DataTable();
            akmt.Fill(dt);
            bankalar.DisplayMember = "Ad";
            bankalar.ValueMember = "ID";
            bankalar.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
