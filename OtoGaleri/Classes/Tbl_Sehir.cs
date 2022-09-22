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
    public class Tbl_Sehir
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataAdapter akmt;
        OleDbDataReader oku;

        public void SehirCmbList(ComboBox cmb_sehir)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Sehir Order By ID", bgl.baglanti());
            DataTable dt = new DataTable();
            akmt.Fill(dt);
            cmb_sehir.DisplayMember = "Sehir";
            cmb_sehir.ValueMember = "ID";
            cmb_sehir.DataSource = dt;
            bgl.baglanti().Close();
        }

    }
}
