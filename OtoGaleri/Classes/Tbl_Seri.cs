using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace OtoGaleri.Classes
{
    class Tbl_Seri
    {
        OleDbDataAdapter akmt;
        OleDbCommand ckmt;
        OleDbDataReader oku;
        Baglanti bgl = new Baglanti();
        DataTable dt;
        public void SeriListCmb(int Markaid, ComboBox seri)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Seri Where MarkaID=@p1", bgl.baglanti());
            akmt.SelectCommand.Parameters.AddWithValue("@p1", Markaid);
            dt = new DataTable();
            akmt.Fill(dt);
            seri.DisplayMember = "Seri";
            seri.ValueMember = "ID";
            seri.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
