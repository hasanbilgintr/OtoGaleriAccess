using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleri.Classes
{
    public class Tbl_MusSilTalep
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        public string MusSilTalep(int musid, string Aciklama)
        {
            
            if (MessageBox.Show("Silmek İstediğiniziden Emin Misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ckmt = new OleDbCommand("insert into Tbl_MusSilTalep (MusteriID,Aciklama) values (@p1,@p2)", bgl.baglanti());
                ckmt.Parameters.AddWithValue("@p1", musid);
                ckmt.Parameters.AddWithValue("@p2", Aciklama);
                if (ckmt.ExecuteNonQuery() > 0)
                {
                    return "Müşteri Silme Talebi Başarılı";
                }
                return "Müşteri Silem Talebi Başarısız";
            }
            return "İşlem İptal Edildi";
        }
    }
}
