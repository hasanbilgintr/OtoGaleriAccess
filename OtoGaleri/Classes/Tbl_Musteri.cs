using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OtoGaleri.Classes
{
    public class Tbl_Musteri
    {
        Baglanti bgl = new Baglanti();
        Tbl_Sehir tbl_Sehir = new Tbl_Sehir();
        Tbl_Ilce tbl_ilce = new Tbl_Ilce();
        Frm_Kullanıci frm_Kullanıci;
        OleDbDataAdapter akmt;
        OleDbCommand ckmt;
        OleDbDataReader oku;
        ListViewItem item;

        public string MusteriEkle(string Tc, string AdSoyad, bool erkek, string CepTel, string EvTel, string Mail, DateTime Dtarih, string EhliyetNo, int Ev_Sehirid, int Ev_Ilceid, string Ev_Adres, int Is_Sehirid, int Is_Ilceid, string Is_Adres, string K_Tc, string K_AdSoyad, string K_CepTel, DateTime K_Dtarih, string KayitKullanici)
        {
            try
            {
                if (MessageBox.Show("Müşteri Eklemek İstiyor musunuz", "Müşteri Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ckmt = new OleDbCommand("insert into Tbl_Musteri (Tc,AdSoyad,Cinsiyet,CepTel,EvTel,Mail,Dtarih,EhliyetNo,Ev_SehirID,Ev_IlceID,Ev_Adres,Is_SehirID,Is_IlceID,Is_Adres,K_Tc,K_AdSoyad,K_CepTel,K_Dtarih,KayitKullanici,KayitTarih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20)", bgl.baglanti());
                    ckmt.Parameters.AddWithValue("@p1", Tc);
                    ckmt.Parameters.AddWithValue("@p2", AdSoyad);
                    if (erkek == true) { ckmt.Parameters.AddWithValue("@p3", "Erkek"); } else { ckmt.Parameters.AddWithValue("@p3", "Kadın"); }
                    ckmt.Parameters.AddWithValue("@p4", CepTel);
                    ckmt.Parameters.AddWithValue("@p5", EvTel);
                    ckmt.Parameters.AddWithValue("@p6", Mail);
                    ckmt.Parameters.AddWithValue("@p7", Dtarih);
                    ckmt.Parameters.AddWithValue("@p8", EhliyetNo);
                    ckmt.Parameters.AddWithValue("@p9", Ev_Sehirid);
                    ckmt.Parameters.AddWithValue("@p10", Ev_Ilceid);
                    ckmt.Parameters.AddWithValue("@p11", Ev_Adres);
                    ckmt.Parameters.AddWithValue("@p12", Is_Sehirid);
                    ckmt.Parameters.AddWithValue("@p13", Is_Ilceid);
                    ckmt.Parameters.AddWithValue("@p14", Is_Adres);
                    ckmt.Parameters.AddWithValue("@p15", K_Tc);
                    ckmt.Parameters.AddWithValue("@p16", K_AdSoyad);
                    ckmt.Parameters.AddWithValue("@p17", K_CepTel);
                    ckmt.Parameters.AddWithValue("@p18", K_Dtarih);
                    ckmt.Parameters.AddWithValue("@p19", KayitKullanici);
                    ckmt.Parameters.AddWithValue("@p20", DateTime.Now.ToShortDateString());
                    if (ckmt.ExecuteNonQuery() > 0)
                    {
                        return "Müşteri Ekleme Başarılı";
                    }
                    return "Müşteri Ekleme Başarısız";
                }
                return "İşlem İptal Edildi";
            }
            catch (Exception hata)
            {
                return "Hata Vardır Yetkiliye Bildirin hata kodu\n" + hata;
            }
        }

        public void MusteriListview(ListView MusList)
        {
            bgl = new Baglanti();
            tbl_Sehir = new Tbl_Sehir();
            tbl_ilce = new Tbl_Ilce();
            MusList.Items.Clear();
            ckmt = new OleDbCommand("select *from Tbl_MusteriList", bgl.baglanti());
            oku = ckmt.ExecuteReader();
            while (oku.Read())
            {
                item = new ListViewItem();
                item.Text = oku["ID"].ToString();
                item.SubItems.Add(oku["Tc"].ToString());
                item.SubItems.Add(oku["AdSoyad"].ToString());
                item.SubItems.Add(oku["Cinsiyet"].ToString());
                item.SubItems.Add(oku["CepTel"].ToString());
                item.SubItems.Add(oku["EvTel"].ToString());
                item.SubItems.Add(oku["Mail"].ToString());
                item.SubItems.Add(oku["Dtarih"].ToString());
                item.SubItems.Add(oku["EhliyetNo"].ToString());
                item.SubItems.Add(oku["Şehir"].ToString() + "/" + oku["İlçe"].ToString() + "/" + oku["Ev_Adres"].ToString());
                item.SubItems.Add(oku["Şehir2"].ToString() + "/" + oku["İlçe2"].ToString() + "/" + oku["Is_Adres"].ToString());
                item.SubItems.Add(oku["K_Tc"].ToString());
                item.SubItems.Add(oku["K_AdSoyad"].ToString());
                item.SubItems.Add(oku["K_CepTel"].ToString());
                item.SubItems.Add(oku["K_Dtarih"].ToString());
                item.SubItems.Add(oku["KayitKullanici"].ToString());
                item.SubItems.Add(oku["KayitTarih"].ToString());
                item.SubItems.Add(oku["DuzenleKullanici"].ToString());
                item.SubItems.Add(oku["DuzenleTarih"].ToString());
                MusList.Items.Add(item);
            }
            bgl.baglanti().Close();
        }


        public void MusTcAra(ListView MusList, string tc)
        {
            bgl = new Baglanti();
            tbl_Sehir = new Tbl_Sehir();
            tbl_ilce = new Tbl_Ilce();
            MusList.Items.Clear();
            ckmt = new OleDbCommand("select *from Tbl_Musteri where Tc=@p1", bgl.baglanti());
            ckmt.Parameters.AddWithValue("@p1", tc);
            oku = ckmt.ExecuteReader();
            if (oku.Read())
            {
                item = new ListViewItem();
                item.Text = oku["ID"].ToString();
                item.SubItems.Add(oku["Tc"].ToString());
                item.SubItems.Add(oku["AdSoyad"].ToString());
                item.SubItems.Add(oku["Cinsiyet"].ToString());
                item.SubItems.Add(oku["CepTel"].ToString());
                item.SubItems.Add(oku["EvTel"].ToString());
                item.SubItems.Add(oku["Mail"].ToString());
                item.SubItems.Add(oku["Dtarih"].ToString());
                item.SubItems.Add(oku["EhliyetNo"].ToString());
                item.SubItems.Add(oku["Şehir"].ToString() + "/" + oku["İlçe"].ToString() + "/" + oku["Ev_Adres"].ToString());
                item.SubItems.Add(oku["Şehir2"].ToString() + "/" + oku["İlçe2"].ToString() + "/" + oku["Is_Adres"].ToString());
                item.SubItems.Add(oku["K_Tc"].ToString());
                item.SubItems.Add(oku["K_AdSoyad"].ToString());
                item.SubItems.Add(oku["K_CepTel"].ToString());
                item.SubItems.Add(oku["K_Dtarih"].ToString());
                item.SubItems.Add(oku["KayitKullanici"].ToString());
                item.SubItems.Add(oku["KayitTarih"].ToString());
                item.SubItems.Add(oku["DuzenleKullanici"].ToString());
                item.SubItems.Add(oku["DuzenleTarih"].ToString());
                MusList.Items.Add(item);
            }
            bgl.baglanti().Close();
        }

        public string MusSil(int musid)
        {
            if (MessageBox.Show("Silmek İstediğiniziden Emin Misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ckmt = new OleDbCommand("delete from Tbl_Musteri where ID=@p1", bgl.baglanti());
                ckmt.Parameters.AddWithValue("@p1", musid);
                if (ckmt.ExecuteNonQuery() > 0)
                {
                    bgl.baglanti().Close();
                    frm_Kullanıci = (Frm_Kullanıci)Application.OpenForms["Frm_Kullanıci"];
                    frm_Kullanıci.Btn_MusSil.Enabled = true;
                    return "Müşteri Silme Başarılı";
                }
                bgl.baglanti().Close();
                return "Müşteri Ekleme Başarısız";
            }
            return "İşlem İptal Edildi";
        }

        public string MusGuncelle(int musid, string Tc, string AdSoyad, bool Erkek, string CepTel, string EvTel, string Mail, DateTime Dtarih, string EhliyetNo, int Ev_SehirID, int Ev_IlceID, string Ev_Adres, int Is_SehirID, int Is_IlceID, string Is_Adres, string K_Tc, string K_AdSoyad, string K_CepTel, DateTime K_Dtarih, string DuzenleKullanici, DateTime DuzenleTarih)
        {
            try
            {
                ckmt = new OleDbCommand("Update Tbl_Musteri set Tc=@p1,AdSoyad=@p2,Cinsiyet=@p3,CepTel=@p4,EvTel=@p5,Mail=@p6,Dtarih=@p7,EhliyetNo=@p8,Ev_SehirID=@p9,Ev_IlceID=@p10,Ev_Adres=@p11,Is_SehirID=@p12,Is_IlceID=@p13,Is_Adres=@p14,K_Tc=@p15,K_AdSoyad=@p16,K_CepTel=@p17,K_Dtarih=@p18,DuzenleKullanici=@p19,DuzenleTarih=@p20 where ID=@p21", bgl.baglanti());
                ckmt.Parameters.AddWithValue("@p1", Tc);
                ckmt.Parameters.AddWithValue("@p2", AdSoyad);
                if (Erkek) { ckmt.Parameters.AddWithValue("@p3", "Erkek"); } else { ckmt.Parameters.AddWithValue("@p3", "Kadın"); }
                ckmt.Parameters.AddWithValue("@p4", CepTel);
                ckmt.Parameters.AddWithValue("@p5", EvTel);
                ckmt.Parameters.AddWithValue("@p6", Mail);
                ckmt.Parameters.AddWithValue("@p7", Dtarih.ToShortDateString());
                ckmt.Parameters.AddWithValue("@p8", EhliyetNo);
                ckmt.Parameters.AddWithValue("@p9", Ev_SehirID);
                ckmt.Parameters.AddWithValue("@p10", Ev_IlceID);
                ckmt.Parameters.AddWithValue("@p11", Ev_Adres);
                ckmt.Parameters.AddWithValue("@p12", Is_SehirID);
                ckmt.Parameters.AddWithValue("@p13", Is_IlceID);
                ckmt.Parameters.AddWithValue("@p14", Is_Adres);
                ckmt.Parameters.AddWithValue("@p15", K_Tc);
                ckmt.Parameters.AddWithValue("@p16", K_AdSoyad);
                ckmt.Parameters.AddWithValue("@p17", K_CepTel);
                ckmt.Parameters.AddWithValue("@p18", K_Dtarih.ToShortDateString());
                ckmt.Parameters.AddWithValue("@p19", DuzenleKullanici);
                ckmt.Parameters.AddWithValue("@p20", DuzenleTarih.ToShortDateString());
                ckmt.Parameters.AddWithValue("@p21", musid);
                if (ckmt.ExecuteNonQuery() > 0)
                {
                    bgl.baglanti().Close();
                    frm_Kullanıci = (Frm_Kullanıci)Application.OpenForms["Frm_Kullanıci"];
                    frm_Kullanıci.Btn_MusGuncelle.Enabled = true;
                    return "Müşteri Güncelleme Başarılı";
                }
                bgl.baglanti().Close();
                return "Müşteri Güncelleme Başarısız";
            }
            catch (Exception hata)
            {
                return "Hata Vardır Yetkili Birisine Bildiriniz\n" + hata;
            }
        }

        public void MusGetir(ListView muslist, MaskedTextBox tc, TextBox adsoyad, RadioButton erkek, RadioButton kadin, MaskedTextBox ceptel, MaskedTextBox evtel, TextBox mail, DateTimePicker dtarih, TextBox ehliyetno, ComboBox Ev_Sehir, ComboBox Ev_Ilce, TextBox Ev_Adres, ComboBox Is_Sehir, ComboBox Is_Ilce, TextBox Is_Adres, CheckBox kefilekle, MaskedTextBox ktc, TextBox k_adsoyad, MaskedTextBox kceptel, DateTimePicker kdtarih)
        {
            try
            {
                tc.Text = muslist.SelectedItems[0].SubItems[1].Text;
                adsoyad.Text = muslist.SelectedItems[0].SubItems[2].Text;
                if (muslist.SelectedItems[0].SubItems[3].Text == "Erkek") { erkek.Checked = true; } else { kadin.Checked = true; }
                ceptel.Text = muslist.SelectedItems[0].SubItems[4].Text;
                evtel.Text = muslist.SelectedItems[0].SubItems[5].Text;
                mail.Text = muslist.SelectedItems[0].SubItems[6].Text;
                dtarih.Text = muslist.SelectedItems[0].SubItems[7].Text;
                ehliyetno.Text = muslist.SelectedItems[0].SubItems[8].Text;

                string[] evadresial = muslist.SelectedItems[0].SubItems[9].Text.Split('/');
                Ev_Sehir.Text = evadresial[0].ToString();
                Ev_Ilce.Text = evadresial[1].ToString();
                Ev_Adres.Text = evadresial[2].ToString();
                string[] isadresial = muslist.SelectedItems[0].SubItems[10].Text.Split('/');

                Is_Sehir.Text = isadresial[0].ToString();
                Is_Ilce.Text = isadresial[1].ToString();
                Is_Adres.Text = isadresial[2].ToString();
                kefilekle.Checked = true;
                ktc.Text = muslist.SelectedItems[0].SubItems[11].Text;
                k_adsoyad.Text = muslist.SelectedItems[0].SubItems[12].Text;
                kceptel.Text = muslist.SelectedItems[0].SubItems[13].Text;
                kdtarih.Text = muslist.SelectedItems[0].SubItems[14].Text;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Vardır Yetkiliye Bildiriniz\n" + hata);
            }

        }

        public void MusKontrol(string tc, Label Adsoyad, Label tel, Label dtarihi, Label ehliyetno)
        {
            ckmt = new OleDbCommand("Select *from Tbl_Musteri Where Tc=@p1", bgl.baglanti());
            ckmt.Parameters.AddWithValue("@p1", tc);
            oku = ckmt.ExecuteReader();
            if (oku.Read())
            {
                Adsoyad.Text = oku["AdSoyad"].ToString();
                tel.Text = oku["CepTel"].ToString();
                dtarihi.Text = oku["Dtarih"].ToString();
                ehliyetno.Text = oku["EhliyetNo"].ToString();
            }
            bgl.baglanti().Close();
        }

        public string MusteriAd(string tc)
        {
            ckmt = new OleDbCommand("select *from Tbl_Musteri where Tc=@p1", bgl.baglanti());
            ckmt.Parameters.AddWithValue("@p1", tc);
            oku = ckmt.ExecuteReader();
            if (oku.Read())
            {
                return oku["Adsoyad"].ToString();
            }
            return "";
        }

    }
}

