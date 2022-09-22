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
    public class Tbl_Model
    {
        Baglanti bgl = new Baglanti();
        DataTable dt;
        OleDbDataAdapter akmt;
        OleDbCommand ckmt;
        OleDbDataReader oku;

        public void ModelListCmb(int seriid, ComboBox model)
        {
            akmt = new OleDbDataAdapter("select *from Tbl_Model where SeriID=@p1", bgl.baglanti());
            akmt.SelectCommand.Parameters.AddWithValue("@p1", seriid);
            dt = new DataTable();
            akmt.Fill(dt);
            model.DisplayMember = "Ad";
            model.ValueMember = "ID";
            model.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
