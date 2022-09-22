using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleri.Classes
{
    public class Tbl_Arac
    {
        Baglanti bgl = new Baglanti();
        OleDbCommand ckmt;
        OleDbDataReader oku;
        ListViewItem item;
        Tbl_Marka tbl_Marka = new Tbl_Marka();
        Tbl_Seri tbl_Seri = new Tbl_Seri();
        Tbl_Model tbl_Model = new Tbl_Model();
        Tbl_Renk tbl_Renk = new Tbl_Renk();
        Tbl_Yakit tbl_Yakit = new Tbl_Yakit();
        Tbl_Musteri tbl_Musteri = new Tbl_Musteri();
        Frm_Kullanıci frm_kul;

        public string AracEkle(string Plaka, int MarkaID, int SeriID, int ModelID, int RenkID, string Yil, int YakitID, string Vites, int Km, int MotorHacmi, int MotorGucu, string SaseNo, decimal AlisFiyati, decimal SatisFiyati, decimal SonFiyat, decimal _1Kaza, decimal _2Kaza, decimal _3Kaza, decimal _4Kaza, decimal _5Kaza, string Aciklama, string KayitKullanici, int AracDurumID)
        {
            try
            {
                if (MessageBox.Show("Araç Eklemek için Emin Misiniz?", "Araç Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ckmt = new OleDbCommand("insert into Tbl_Arac (Plaka,MarkaID,SeriID,ModelID,RenkID,Yil,YakitID,Vites,Km,MotorHacmi,MotorGucu,SaseNo,AlisFiyati,SatisFiyati,SonFiyat, _1Kaza ,_2Kaza,_3Kaza,_4Kaza,_5Kaza,Aciklama,KayitTarih,KayitKullanici,AracDurumID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24)", bgl.baglanti());
                    ckmt.Parameters.AddWithValue("@p1", Plaka);
                    ckmt.Parameters.AddWithValue("@p2", MarkaID);
                    ckmt.Parameters.AddWithValue("@p3", SeriID);
                    ckmt.Parameters.AddWithValue("@p4", ModelID);
                    ckmt.Parameters.AddWithValue("@p5", RenkID);
                    ckmt.Parameters.AddWithValue("@p6", Yil);
                    ckmt.Parameters.AddWithValue("@p7", YakitID);
                    ckmt.Parameters.AddWithValue("@p8", Vites);
                    ckmt.Parameters.AddWithValue("@p9", Km);
                    ckmt.Parameters.AddWithValue("@p10", MotorHacmi);
                    ckmt.Parameters.AddWithValue("@p11", MotorGucu);
                    ckmt.Parameters.AddWithValue("@p12", SaseNo);
                    ckmt.Parameters.AddWithValue("@p13", AlisFiyati);
                    ckmt.Parameters.AddWithValue("@p14", SatisFiyati);
                    ckmt.Parameters.AddWithValue("@p15", SonFiyat);
                    ckmt.Parameters.AddWithValue("@p16", _1Kaza);
                    ckmt.Parameters.AddWithValue("@p17", _2Kaza);
                    ckmt.Parameters.AddWithValue("@p18", _3Kaza);
                    ckmt.Parameters.AddWithValue("@p19", _4Kaza);
                    ckmt.Parameters.AddWithValue("@p20", _5Kaza);
                    ckmt.Parameters.AddWithValue("@p21", Aciklama);
                    ckmt.Parameters.AddWithValue("@p22", DateTime.Now.ToShortDateString());
                    ckmt.Parameters.AddWithValue("@p23", KayitKullanici);
                    ckmt.Parameters.AddWithValue("@p24", AracDurumID);
                    if (ckmt.ExecuteNonQuery() > 0)
                    {
                        return "Araç Ekleme Başarılı";
                    }
                    return "Araç Ekleme Başarısız";
                }
                return "İşlem İptal Edildi";
            }
            catch (Exception hata) { return "Araç Ekleme İşleminde Hata Oluştu Lütfen Yetkiliye Bildiriniz\n" + hata; }
        }

        public void AracListYenile(ListView AracList)
        {
            try
            {
                AracList.Items.Clear();
                ckmt = new OleDbCommand("select *from Tbl_AracList", bgl.baglanti());
                oku = ckmt.ExecuteReader();
                while (oku.Read())
                {
                    item = new ListViewItem();
                    item.Text = oku["ID"].ToString();
                    item.SubItems.Add(oku["Plaka"].ToString());
                    item.SubItems.Add(oku["Marka"].ToString());
                    item.SubItems.Add(oku["Seri"].ToString());
                    item.SubItems.Add(oku["Model"].ToString());
                    item.SubItems.Add(oku["Renk"].ToString());
                    item.SubItems.Add(oku["Yıl"].ToString());
                    item.SubItems.Add(oku["Yakıt"].ToString());
                    item.SubItems.Add(oku["Vites"].ToString());
                    item.SubItems.Add(oku["Km"].ToString());
                    item.SubItems.Add(oku["Motor Hacmi"].ToString());
                    item.SubItems.Add(oku["Motor Gücü"].ToString());
                    item.SubItems.Add(oku["Şase No"].ToString());
                    item.SubItems.Add(oku["Alış Fiyatı"].ToString());
                    item.SubItems.Add(oku["Satış Fiyatı"].ToString());
                    item.SubItems.Add(oku["Son Fiyat"].ToString());
                    item.SubItems.Add(oku["1 Kaza"].ToString());
                    item.SubItems.Add(oku["2 Kaza"].ToString());
                    item.SubItems.Add(oku["3 Kaza"].ToString());
                    item.SubItems.Add(oku["4 Kaza"].ToString());
                    item.SubItems.Add(oku["5 Kaza"].ToString());
                    item.SubItems.Add(oku["Açıklama"].ToString());
                    item.SubItems.Add(oku["Kayıt Tarihi"].ToString());
                    item.SubItems.Add(oku["KayitKullanici"].ToString());
                    item.SubItems.Add(oku["DuzenleTarih"].ToString());
                    item.SubItems.Add(oku["DuzenleKullanici"].ToString());
                    item.SubItems.Add(oku["AracDurum"].ToString());
                    AracList.Items.Add(item);
                }
                bgl.baglanti().Close();
            }
            catch (Exception hata) { MessageBox.Show("Arac Listesi Yenileme İşleminde Hata Vardır Lütfen Yetkiliye Bildiriniz\n" + hata); }
        }

        public void AracGetir(ListView araclist, TextBox plaka, ComboBox marka, ComboBox seri, ComboBox model, ComboBox renk, MaskedTextBox yil, ComboBox yakit, ComboBox vites, TextBox km, TextBox motorhacmi, TextBox motorgucu, TextBox saseno, TextBox alisfiyat, TextBox satisfiyati, TextBox sonfiyat, ComboBox aracdurumu, TextBox aciklama, TextBox _1kaza, TextBox _2kaza, TextBox _3kaza, TextBox _4kaza, TextBox _5kaza)
        {
            try
            {
                plaka.Text = araclist.SelectedItems[0].SubItems[1].Text;
                if (!string.IsNullOrWhiteSpace(araclist.SelectedItems[0].SubItems[2].Text)) { marka.Text = araclist.SelectedItems[0].SubItems[2].Text; } else { marka.SelectedItem = null; }
                if (!string.IsNullOrWhiteSpace(araclist.SelectedItems[0].SubItems[3].Text)) { seri.Text = araclist.SelectedItems[0].SubItems[3].Text; } else { seri.SelectedItem = null; }
                if (!string.IsNullOrWhiteSpace(araclist.SelectedItems[0].SubItems[4].Text)) { model.Text = araclist.SelectedItems[0].SubItems[4].Text; } else { model.SelectedItem = null; }
                if (!string.IsNullOrWhiteSpace(araclist.SelectedItems[0].SubItems[5].Text)) { renk.Text = araclist.SelectedItems[0].SubItems[5].Text; } else { renk.SelectedItem = null; }
                yil.Text = araclist.SelectedItems[0].SubItems[6].Text;
                if (!string.IsNullOrWhiteSpace(araclist.SelectedItems[0].SubItems[7].Text)) { yakit.Text = araclist.SelectedItems[0].SubItems[7].Text; } else { yakit.SelectedItem = null; }
                if (!string.IsNullOrWhiteSpace(araclist.SelectedItems[0].SubItems[8].Text)) { vites.Text = araclist.SelectedItems[0].SubItems[8].Text; } else { vites.SelectedItem = null; }
                km.Text = araclist.SelectedItems[0].SubItems[9].Text;
                motorhacmi.Text = araclist.SelectedItems[0].SubItems[10].Text;
                motorgucu.Text = araclist.SelectedItems[0].SubItems[11].Text;
                saseno.Text = araclist.SelectedItems[0].SubItems[12].Text;
                alisfiyat.Text = araclist.SelectedItems[0].SubItems[13].Text;
                satisfiyati.Text = araclist.SelectedItems[0].SubItems[14].Text;
                sonfiyat.Text = araclist.SelectedItems[0].SubItems[15].Text;
                _1kaza.Text = araclist.SelectedItems[0].SubItems[16].Text;
                _2kaza.Text = araclist.SelectedItems[0].SubItems[17].Text;
                _3kaza.Text = araclist.SelectedItems[0].SubItems[18].Text;
                _4kaza.Text = araclist.SelectedItems[0].SubItems[19].Text;
                _4kaza.Text = araclist.SelectedItems[0].SubItems[19].Text;
                _5kaza.Text = araclist.SelectedItems[0].SubItems[20].Text;
                aciklama.Text = araclist.SelectedItems[0].SubItems[21].Text;
                if (!string.IsNullOrWhiteSpace(aracdurumu.Text = araclist.SelectedItems[0].SubItems[26].Text)) { aracdurumu.Text = araclist.SelectedItems[0].SubItems[26].Text; } else { aracdurumu.SelectedItem = null; }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata vardır Yetkiliye Bildiriniz\n" + hata);
            }
        }

        public void PlakaAra(string plaka, ListView araclist)
        {
            try
            {
                araclist.Items.Clear();
                ckmt = new OleDbCommand("select *from Tbl_AracList where Plaka=@p1", bgl.baglanti());
                ckmt.Parameters.AddWithValue("@p1", plaka);
                oku = ckmt.ExecuteReader();
                if (oku.Read())
                {
                    item = new ListViewItem();
                    item.Text = oku["ID"].ToString();
                    item.SubItems.Add(oku["Plaka"].ToString());
                    item.SubItems.Add(oku["Marka"].ToString());
                    item.SubItems.Add(oku["Seri"].ToString());
                    item.SubItems.Add(oku["Model"].ToString());
                    item.SubItems.Add(oku["Renk"].ToString());
                    item.SubItems.Add(oku["Yıl"].ToString());
                    item.SubItems.Add(oku["Yakıt"].ToString());
                    item.SubItems.Add(oku["Vites"].ToString());
                    item.SubItems.Add(oku["Km"].ToString());
                    item.SubItems.Add(oku["Motor Hacmi"].ToString());
                    item.SubItems.Add(oku["Motor Gücü"].ToString());
                    item.SubItems.Add(oku["Şase No"].ToString());
                    item.SubItems.Add(oku["Alış Fiyatı"].ToString());
                    item.SubItems.Add(oku["Satış Fiyatı"].ToString());
                    item.SubItems.Add(oku["Son Fiyat"].ToString());
                    item.SubItems.Add(oku["1 Kaza"].ToString());
                    item.SubItems.Add(oku["2 Kaza"].ToString());
                    item.SubItems.Add(oku["3 Kaza"].ToString());
                    item.SubItems.Add(oku["4 Kaza"].ToString());
                    item.SubItems.Add(oku["5 Kaza"].ToString());
                    item.SubItems.Add(oku["Açıklama"].ToString());
                    item.SubItems.Add(oku["Kayıt Tarihi"].ToString());
                    item.SubItems.Add(oku["KayitKullanici"].ToString());
                    item.SubItems.Add(oku["DuzenleTarih"].ToString());
                    item.SubItems.Add(oku["DuzenleKullanici"].ToString());
                    item.SubItems.Add(oku["AracDurum"].ToString());
                    araclist.Items.Add(item);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Plaka Arama İşleminde Hata Oluştu Lütfen Yetkilie Bildiriniz\n" + hata);
            }
        }

        public string AracSil(int aracid)
        {
            if (MessageBox.Show(aracid + " nolu Araç Kaydı Silinsin mi?", "Arac Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ckmt = new OleDbCommand("delete from Tbl_Arac where ID=@p1", bgl.baglanti());
                ckmt.Parameters.AddWithValue("@p1", aracid);
                if (ckmt.ExecuteNonQuery() > 0)
                {
                    bgl.baglanti().Close();
                    frm_kul = (Frm_Kullanıci)Application.OpenForms["Frm_Kullanıci"];
                    frm_kul.Btn_AracSil.Enabled = false;
                    return "Arac Silme Başarılı";
                }
                bgl.baglanti().Close();
                return "Arac Silme Başarısız";
            }
            return "İşlem İptal Edildi";
        }

        public string AracGuncelle(int aracid, string plaka, int markaid, int seriid, int modelid, int renkid, string yil, int yakitid, string vites, int km, int motorhacmi, int motorgucu, string saseno, decimal alisfiyati, decimal satisfiyati, decimal sonfiyati, decimal _1kaza, decimal _2kaza, decimal _3kaza, decimal _4kaza, decimal _5kaza, string aciklama, string duzenlekullanici, int aracdurumuid)
        {
            if (MessageBox.Show("Güncellemekten Emin Misiniz?", "Araç Güncelleme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                ckmt = new OleDbCommand("Update Tbl_Arac set Plaka = @p1 ,MarkaID = @p2, SeriID = @p3, ModelID = @p4, RenkID = @p5, Yil = @p6, YakitID = @p7, Vites = @p8, Km = @p9, MotorHacmi = @p10, MotorGucu = @p11, SaseNo = @p12, AlisFiyati = @p13, SatisFiyati = @p14, SonFiyat = @p15, _1Kaza = @p16, _2Kaza = @p17, _3Kaza = @p18, _4Kaza = @p19, _5Kaza = @p20, Aciklama = @p21, DuzenleTarih = @p22, DuzenleKullanici = @p23, AracDurumID = @p24 where ID=@p25", bgl.baglanti());
                ckmt.Parameters.AddWithValue("@p1", plaka);
                ckmt.Parameters.AddWithValue("@p2", markaid);
                ckmt.Parameters.AddWithValue("@p3", seriid);
                ckmt.Parameters.AddWithValue("@p4", modelid);
                ckmt.Parameters.AddWithValue("@p5", renkid);
                ckmt.Parameters.AddWithValue("@p6", yil);
                ckmt.Parameters.AddWithValue("@p7", yakitid);
                ckmt.Parameters.AddWithValue("@p8", vites);
                ckmt.Parameters.AddWithValue("@p9", km);
                ckmt.Parameters.AddWithValue("@p10", motorhacmi);
                ckmt.Parameters.AddWithValue("@p11", motorgucu);
                ckmt.Parameters.AddWithValue("@p12", saseno);
                ckmt.Parameters.AddWithValue("@p13", alisfiyati);
                ckmt.Parameters.AddWithValue("@p14", satisfiyati);
                ckmt.Parameters.AddWithValue("@p15", sonfiyati);
                ckmt.Parameters.AddWithValue("@p16", _1kaza);
                ckmt.Parameters.AddWithValue("@p17", _2kaza);
                ckmt.Parameters.AddWithValue("@p18", _3kaza);
                ckmt.Parameters.AddWithValue("@p19", _4kaza);
                ckmt.Parameters.AddWithValue("@p20", _5kaza);
                ckmt.Parameters.AddWithValue("@p21", aciklama);
                ckmt.Parameters.AddWithValue("@p22", DateTime.Now.ToShortDateString());
                ckmt.Parameters.AddWithValue("@p23", duzenlekullanici);
                ckmt.Parameters.AddWithValue("@p24", aracdurumuid);
                ckmt.Parameters.AddWithValue("@p25", aracid);

                if (ckmt.ExecuteNonQuery() > 0)
                {
                    bgl.baglanti().Close();
                    frm_kul = (Frm_Kullanıci)Application.OpenForms["Frm_Kullanıci"];
                    frm_kul.Btn_AracGuncelle.Enabled = false;
                    return "Araç Güncelleme Başarılı";
                }
                bgl.baglanti().Close();
                return "Araç Güncelleme Başarısız";
            }
            return "İşlem İptal Edildi";
        }

        public void AracKontrol(string plaka, string saseno, Label marka, Label seri, Label model, Label renk, Label yil, Label alisfiyat, Label satisfiyat, Label sonfiyat, Label aracsahibi, Label tc)
        {
            ckmt = new OleDbCommand("SELECT *FROM Tbl_AracList where   Plaka = @p1 and  [Şase No] =@p2", bgl.baglanti());
            ckmt.Parameters.AddWithValue("@p1", plaka);
            ckmt.Parameters.AddWithValue("@p2", saseno);
            oku = ckmt.ExecuteReader();
            if (oku.Read())
            {
                marka.Text = oku["Marka"].ToString();
                seri.Text = oku["Seri"].ToString();
                model.Text = oku["Model"].ToString();
                renk.Text = oku["Renk"].ToString();
                yil.Text = oku["Yıl"].ToString();
                alisfiyat.Text = oku["Alış Fiyatı"].ToString();
                satisfiyat.Text = oku["Satış Fiyatı"].ToString();
                sonfiyat.Text = oku["Son Fiyat"].ToString();
                tc.Text = oku["AracSahibi"].ToString();
                aracsahibi.Text = tbl_Musteri.MusteriAd(tc.Text);
            }
            else
            {
                marka.Text = "---";
                seri.Text = "---";
                model.Text = "---";
                renk.Text = "---";
                yil.Text = "---";
                alisfiyat.Text = "---";
                satisfiyat.Text = "---";
                sonfiyat.Text = "---";
                tc.Text = "---";
                aracsahibi.Text = "---";
            }
            bgl.baglanti().Close();

        }
    }
}
