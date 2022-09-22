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
    public class Tbl_Ilce
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataAdapter akmt;
        DataTable dt;
        OleDbDataReader oku;

        public void IlceCmbList(int sehirid, ComboBox ilce)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Ilce where SehirID=@p1 Order By ID", bgl.baglanti());
            akmt.SelectCommand.Parameters.AddWithValue("@p1", sehirid);
            dt = new DataTable();
            akmt.Fill(dt);
            ilce.DisplayMember = "Ilce";
            ilce.ValueMember = "ID";
            ilce.DataSource = dt;

            bgl.baglanti().Close();
        }
    }
}
