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
    public class Tbl_SenetTaksit
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataAdapter akmt;
        OleDbDataReader oku;
        DataTable dt;

        public void BankaTaksitListCmb(ComboBox senettaksitleri)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_SenetTaksit ", bgl.baglanti());
            dt = new DataTable();
            akmt.Fill(dt);
            senettaksitleri.DisplayMember = "Taksit";
            senettaksitleri.ValueMember = "ID";
            senettaksitleri.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
