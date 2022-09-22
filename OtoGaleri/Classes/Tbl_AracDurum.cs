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
   public  class Tbl_AracDurum
    {
        Baglanti bgl = new Baglanti();
        public void AracDurumListCmb(ComboBox aracdurum)
        {
            OleDbDataAdapter akmt = new OleDbDataAdapter("select *from Tbl_AracDurum",bgl.baglanti());
            DataTable dt = new DataTable();
            akmt.Fill(dt);
            aracdurum.DisplayMember = "AracDurum";
            aracdurum.ValueMember = "ID";
            aracdurum.DataSource = dt;
            bgl.baglanti().Close();
        }
    }
}
