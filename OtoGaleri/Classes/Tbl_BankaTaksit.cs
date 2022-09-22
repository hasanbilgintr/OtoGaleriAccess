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
    public class Tbl_BankaTaksit
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataAdapter akmt;
        OleDbDataReader oku;
        DataTable dt;

        public void BankaTaksitListCmb(ComboBox bankataksitleri, int bankaid)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_BankaTaksit where BankaID=@p1 ", bgl.baglanti());
            akmt.SelectCommand.Parameters.AddWithValue("@p1", bankaid);
            dt = new DataTable();
            akmt.Fill(dt);
            bankataksitleri.DisplayMember = "Taksit";
            bankataksitleri.ValueMember = "ID";
            bankataksitleri.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
