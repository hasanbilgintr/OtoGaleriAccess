using Microsoft.VisualBasic;
using OtoGaleri.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleri
{
    public partial class Frm_Kullanıci : Form
    {
        public Frm_Kullanıci()
        {
            InitializeComponent();
        }

        #region TANIMLAMALAR
        Tbl_Sehir tbl_sehir = new Tbl_Sehir();
        Tbl_Ilce tbl_ilce = new Tbl_Ilce();
        Tbl_Musteri tbl_musteri = new Tbl_Musteri();
        Tbl_MusSilTalep tbl_mussiltalep = new Tbl_MusSilTalep();
        Tbl_Marka tbl_marka = new Tbl_Marka();
        Tbl_Seri tbl_Seri = new Tbl_Seri();
        Tbl_Model tbl_Model = new Tbl_Model();
        Tbl_Yakit tbl_Yakit = new Tbl_Yakit();
        Tbl_Renk tbl_Renk = new Tbl_Renk();
        Tbl_AracDurum tbl_AracDurum = new Tbl_AracDurum();
        Tbl_Arac tbl_Arac = new Tbl_Arac();
        Tbl_Banka tbl_Banka = new Tbl_Banka();
        Tbl_BankaTaksit tbl_BankaTaksit = new Tbl_BankaTaksit();
        Tbl_SenetTaksit tbl_SenetTaksit = new Tbl_SenetTaksit();
        #endregion

        decimal taksitucreti = 0;
        private void Btn_TaksitBilg_Click(object sender, EventArgs e)
        {
            Frm_TaksitBilgisi frm_taksit = new Frm_TaksitBilgisi();
            ListViewItem item = null;
            for (int i = 1; i <= int.Parse(Cmb_AracSatisTaksit.Text); i++)
            {
                item = new ListViewItem();
                item.Text = i.ToString() + ".";
                decimal sayi = (satisfiyati + (decimal.Parse(Lbl_Ucret.Text))) / ((decimal.Parse(Cmb_AracSatisTaksit.Text)));
                item.SubItems.Add(Math.Round(sayi) + " TL");
                frm_taksit.LstVw_TaksitBilg.Items.Add(item);
            }
            frm_taksit.Lbl_ToplamFiyat.Text = Convert.ToString((satisfiyati) + (decimal.Parse(Lbl_Ucret.Text)))+" TL";
            frm_taksit.ShowDialog();
        }

        private void ChckBx_Kefil_Ekle_CheckedChanged(object sender, EventArgs e)
        {
            if (ChckBx_Kefil_Ekle.Checked == true)
            {
                panel1.Visible = true;
            }
            else { panel1.Visible = false; }
        }

        private void Btn_YeniArac_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void Frm_Kullanıci_Load(object sender, EventArgs e)
        {
            OnYukleme();
        }

        public void AracListYenile()
        {
            tbl_Arac.AracListYenile(LstVw_AracList);
        }

        private void OnYukleme()
        {
            EvSehirListCmb();//Müşteri Ev adresi için sehir listelenesi
            IsSehirListCmb();  //Müşteri iş adresi için sehir listelenesi
            MusListYenile(); //müşteri listesi listviewe yüklenmesi 
            AracListYenile();
            AracMarkaListCmb(); 
            YakitListCmb();
            RenkListCmb();
            AracDurumListCmb();
            BankaListCmb();
        }

        public void BankaListCmb()
        {
            tbl_Banka.BankaListCmb(Cmb_AracSatisBanka);
        }

        public void BankaTaksitListCmb()
        {
            if (!string.IsNullOrWhiteSpace(Cmb_AracSatisBanka.Text))
            {
                tbl_BankaTaksit.BankaTaksitListCmb(Cmb_AracSatisTaksit, int.Parse(Cmb_AracSatisBanka.SelectedValue.ToString()));
            }
        }

        public void AracDurumListCmb()
        {
            tbl_AracDurum.AracDurumListCmb(Cmb_AracDurum);
        }

        private void AracMarkaListCmb()
        {
            tbl_marka.MarkaListCmb(Cmb_AracMarka);
        }

        private void EvSehirListCmb()
        {
            tbl_sehir.SehirCmbList(Cmb_MusEvSehir);
        }

        private void IsSehirListCmb()
        {
            tbl_sehir.SehirCmbList(Cmb_MusIsSehir);
        }

        public void MusListYenile()
        {
            tbl_musteri.MusteriListview(LstVw_MusList);
        }

        private void Cmb_MusIsSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_MusIsSehir.Text != string.Empty)
            {
                tbl_ilce.IlceCmbList(int.Parse(Cmb_MusIsSehir.SelectedValue.ToString()), Cmb_MusIsIlce); //müşteri işadresinden il seçilince ilçe ler yüklencek
            }
        }

        private void Cmb_MusEvSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_MusEvSehir.Text != string.Empty)
            {
                tbl_ilce.IlceCmbList(int.Parse(Cmb_MusEvSehir.SelectedValue.ToString()), Cmb_MusEvIlce); //müşteri evadresinden il seçilince ilçe ler yüklencek
            }
        }

        private void Btn_MusEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Mskd_MusTc.Text) && !string.IsNullOrWhiteSpace(Txt_MusAdSoyad.Text) && !string.IsNullOrWhiteSpace(Mskd_MusCepTel.Text) && !string.IsNullOrWhiteSpace(Mskd_MusEvTel.Text) && !string.IsNullOrWhiteSpace(Txt_MusMail.Text) && !string.IsNullOrWhiteSpace(Txt_MusEhliyetNo.Text) && !string.IsNullOrWhiteSpace(Cmb_MusEvSehir.Text) && !string.IsNullOrWhiteSpace(Cmb_MusEvIlce.Text) && !string.IsNullOrWhiteSpace(Txt_MusEvAdres.Text) && !string.IsNullOrWhiteSpace(Cmb_MusIsSehir.Text) && !string.IsNullOrWhiteSpace(Cmb_MusIsIlce.Text) && !string.IsNullOrWhiteSpace(Txt_MusIsAdres.Text) && !string.IsNullOrWhiteSpace(Mskd_MusKTc.Text) && !string.IsNullOrWhiteSpace(Txt_MusKAdSoyad.Text) && !string.IsNullOrWhiteSpace(Mskd_MusKCepTel.Text))
            {
                MessageBox.Show(tbl_musteri.MusteriEkle(Mskd_MusTc.Text, Txt_MusAdSoyad.Text, RdBtn_MusErkek.Checked, Mskd_MusCepTel.Text, Mskd_MusEvTel.Text, Txt_MusMail.Text, DateTime.Parse(DtTm_MusDTarih.Value.ToShortDateString()), Txt_MusEhliyetNo.Text, int.Parse(Cmb_MusEvSehir.SelectedValue.ToString()), int.Parse(Cmb_MusEvIlce.SelectedValue.ToString()), Txt_MusEvAdres.Text, int.Parse(Cmb_MusIsSehir.SelectedValue.ToString()), int.Parse(Cmb_MusIsIlce.SelectedValue.ToString()), Txt_MusIsAdres.Text, Mskd_MusKTc.Text, Txt_MusKAdSoyad.Text, Mskd_MusKCepTel.Text, DateTime.Parse(DtTm_MusKDTarih.Value.ToShortDateString()), "kullanici"));
                MusListYenile();
            }
            else { MessageBox.Show("Lütfen Alanları Doldurunuz"); }
        }

        private void Btn_YeniMusteri_Click(object sender, EventArgs e)
        {
            YeniMusteri();
        }

        private void YeniMusteri()//temizleme için
        {
            Mskd_MusTc.Text = "";
            Txt_MusAdSoyad.Text = "";
            RdBtn_MusErkek.Checked = true;
            Mskd_MusCepTel.Text = "";
            Mskd_MusEvTel.Text = "";
            Txt_MusMail.Text = "";
            DtTm_MusDTarih.Value = DateTime.Now;
            Txt_MusEhliyetNo.Text = "";
            Cmb_MusEvSehir.SelectedIndex = 0;
            Txt_MusEvAdres.Text = "";
            Cmb_MusIsSehir.SelectedIndex = 0;
            Txt_MusIsAdres.Text = "";
            ChckBx_Kefil_Ekle.Checked = false;
            Mskd_MusKTc.Text = "";
            Txt_MusKAdSoyad.Text = "";
            Mskd_MusKCepTel.Text = "";
            DtTm_MusKDTarih.Value = DateTime.Now;
        }

        private void Btn_MusListYenile_Click(object sender, EventArgs e)
        {
            MusListYenile();
        }

        private void Btn_MusTcAra_Click(object sender, EventArgs e)
        {
            tbl_musteri.MusTcAra(LstVw_MusList, Txt_MusTcAra.Text);
            if (LstVw_MusList.Items.Count == 0)
            {
                MessageBox.Show(Txt_MusTcAra.Text + " Tc Kaydı Yoktur");
            }
            else { Txt_MusTcAra.Text = ""; }
        }
        int musid;
        private void Btn_MusSil_Click(object sender, EventArgs e) //MüşSilTalebi Admin Siler
        {
            try { musid = int.Parse(LstVw_MusList.SelectedItems[0].SubItems[0].Text); } catch (Exception) { musid = 0; }
            if (musid > 0) { MessageBox.Show(tbl_mussiltalep.MusSilTalep(int.Parse(LstVw_MusList.SelectedItems[0].SubItems[0].Text), Interaction.InputBox("Açıklama Giriniz ", "Açıklama Kutusu", ""))); } else { MessageBox.Show("Lütfen Silincek Olan Kaydı Seçiniz"); }
            MusListYenile();
        }

        private void Btn_MusGuncelle_Click(object sender, EventArgs e)
        {
            try { musid = int.Parse(LstVw_MusList.SelectedItems[0].SubItems[0].Text); } catch (Exception) { musid = 0; }
            if (musid > 0)
            {
                if (!string.IsNullOrWhiteSpace(Mskd_MusTc.Text) && !string.IsNullOrWhiteSpace(Txt_MusAdSoyad.Text) && !string.IsNullOrWhiteSpace(Mskd_MusCepTel.Text) && !string.IsNullOrWhiteSpace(Mskd_MusEvTel.Text) && !string.IsNullOrWhiteSpace(Txt_MusMail.Text) && !string.IsNullOrWhiteSpace(Txt_MusEhliyetNo.Text) && !string.IsNullOrWhiteSpace(Cmb_MusEvSehir.Text) && !string.IsNullOrWhiteSpace(Cmb_MusEvIlce.Text) && !string.IsNullOrWhiteSpace(Txt_MusEvAdres.Text) && !string.IsNullOrWhiteSpace(Cmb_MusIsSehir.Text) && !string.IsNullOrWhiteSpace(Cmb_MusIsIlce.Text) && !string.IsNullOrWhiteSpace(Txt_MusIsAdres.Text) && !string.IsNullOrWhiteSpace(Mskd_MusKTc.Text) && !string.IsNullOrWhiteSpace(Txt_MusKAdSoyad.Text) && !string.IsNullOrWhiteSpace(Mskd_MusKCepTel.Text))
                {
                    MessageBox.Show(tbl_musteri.MusGuncelle(musid, Mskd_MusTc.Text, Txt_MusAdSoyad.Text, RdBtn_MusErkek.Checked, Mskd_MusCepTel.Text, Mskd_MusEvTel.Text, Txt_MusMail.Text, DtTm_MusDTarih.Value, Txt_MusEhliyetNo.Text, int.Parse(Cmb_MusEvSehir.SelectedValue.ToString()), int.Parse(Cmb_MusEvIlce.SelectedValue.ToString()), Txt_MusEvAdres.Text, int.Parse(Cmb_MusIsSehir.SelectedValue.ToString()), int.Parse(Cmb_MusIsIlce.SelectedValue.ToString()), Txt_MusIsAdres.Text, Mskd_MusKTc.Text, Txt_MusKAdSoyad.Text, Mskd_MusKCepTel.Text, DtTm_MusKDTarih.Value, "duzenlekullanici", DateTime.Now));
                }
                else { MessageBox.Show("Lütfen Zorunlu alanları Dolduralım"); }
            }
            else { MessageBox.Show("Lütfen Güncellenecek Kaydı Seçiniz"); }
            MusListYenile();
        }

        private void LstVw_MusList_MouseClick(object sender, MouseEventArgs e)
        {
            Btn_MusSil.Enabled = true;
            Btn_MusGuncelle.Enabled = true;
            tbl_musteri.MusGetir(LstVw_MusList, Mskd_MusTc, Txt_MusAdSoyad, RdBtn_MusErkek, RdBtn_MusKadin, Mskd_MusCepTel, Mskd_MusEvTel, Txt_MusMail, DtTm_MusDTarih, Txt_MusEhliyetNo, Cmb_MusEvSehir, Cmb_MusEvIlce, Txt_MusEvAdres, Cmb_MusIsSehir, Cmb_MusIsIlce, Txt_MusIsAdres, ChckBx_Kefil_Ekle, Mskd_MusKTc, Txt_MusKAdSoyad, Mskd_MusKCepTel, DtTm_MusKDTarih);
        }

        private void Cmb_AracMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Cmb_AracMarka.Text))
            {
                tbl_Seri.SeriListCmb(int.Parse(Cmb_AracMarka.SelectedValue.ToString()), Cmb_AracSeri);
            }
            else { Cmb_AracSeri.SelectedItem = null; }
        }

        private void Cmb_AracSeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Cmb_AracSeri.Text))
            {
                tbl_Model.ModelListCmb(int.Parse(Cmb_AracSeri.SelectedValue.ToString()), Cmb_AracModel);
            }
            else { Cmb_AracModel.SelectedItem = null; }
        }

        public void YakitListCmb()
        {
            tbl_Yakit.YakitListCmb(Cmb_AracYakit);
        }

        public void RenkListCmb()
        {
            tbl_Renk.RenkListCmb(Cmb_AracRenk);
        }

        private void Btn_AracEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Txt_AracPlaka.Text) && !string.IsNullOrWhiteSpace(Txt_AracSaseNo.Text) && !string.IsNullOrWhiteSpace(Cmb_AracVites.Text) && !string.IsNullOrWhiteSpace(Cmb_AracYakit.Text) && !string.IsNullOrWhiteSpace(Cmb_AracMarka.Text) && !string.IsNullOrWhiteSpace(Cmb_AracSeri.Text))//istediklerini olmasını zorunlu kılabiliriz
            {
                MessageBox.Show(tbl_Arac.AracEkle(Txt_AracPlaka.Text, int.Parse(Cmb_AracMarka.SelectedValue.ToString()), int.Parse(Cmb_AracSeri.SelectedValue.ToString()), int.Parse(Cmb_AracModel.SelectedValue.ToString()), int.Parse(Cmb_AracRenk.SelectedValue.ToString()), Mskd_Yil.Text, int.Parse(Cmb_AracYakit.SelectedValue.ToString()), Cmb_AracVites.Text, int.Parse(Txt_AracKm.Text), int.Parse(Txt_AracMotorHacmi.Text), int.Parse(Txt_AracMotorGucu.Text), Txt_AracSaseNo.Text, decimal.Parse(Txt_AracAlisFiyati.Text), decimal.Parse(Txt_AracSatisFiyati.Text), decimal.Parse(Txt_AracSonFiyat.Text), decimal.Parse(Txt_1kaza.Text), decimal.Parse(Txt_2kaza.Text), decimal.Parse(Txt_3kaza.Text), decimal.Parse(Txt_4kaza.Text), decimal.Parse(Txt_5kaza.Text), txt_AracAciklama.Text, "Kullanici", int.Parse(Cmb_AracDurum.SelectedValue.ToString())));
                AracListYenile();
            }
            else { MessageBox.Show("Zorunlu Alanları Doldurun"); }
        }

        private void Btn_AracListYenile_Click(object sender, EventArgs e)
        {
            AracListYenile();
        }

        private void LstVw_AracList_MouseClick(object sender, MouseEventArgs e)
        {
            Btn_AracSil.Enabled = true;
            Btn_AracGuncelle.Enabled = true;
            tbl_Arac.AracGetir(LstVw_AracList, Txt_AracPlaka, Cmb_AracMarka, Cmb_AracSeri, Cmb_AracModel, Cmb_AracRenk, Mskd_Yil, Cmb_AracYakit, Cmb_AracVites, Txt_AracKm, Txt_AracMotorHacmi, Txt_AracMotorGucu, Txt_AracSaseNo, Txt_AracAlisFiyati, Txt_AracSatisFiyati, Txt_AracSonFiyat, Cmb_AracDurum, txt_AracAciklama, Txt_1kaza, Txt_2kaza, Txt_3kaza, Txt_4kaza, Txt_5kaza);
        }

        private void Btn_AracPlakaAra_Click(object sender, EventArgs e)
        {
            tbl_Arac.PlakaAra(Txt_AracPlakaAra.Text, LstVw_AracList);
            if (LstVw_AracList.Items.Count == 0)
            {
                MessageBox.Show(Txt_AracPlakaAra.Text + " Plaka Kaydı Yoktur");
            }
            else { Txt_AracPlakaAra.Text = ""; }
        }

        int aracid;

        private void Btn_AracSil_Click(object sender, EventArgs e)
        {
            try { aracid = int.Parse(LstVw_AracList.SelectedItems[0].SubItems[0].Text); } catch (Exception) { aracid = 0; }
            if (aracid > 0) { MessageBox.Show(tbl_Arac.AracSil(aracid)); } else { MessageBox.Show("Lütfen Silincek Kaydı Seçiniz"); }
            AracListYenile();
        }

        private void Btn_AracGuncelle_Click(object sender, EventArgs e)
        {
            try { aracid = int.Parse(LstVw_AracList.SelectedItems[0].SubItems[0].Text); } catch (Exception) { aracid = 0; }
            if (aracid > 0)
            {
                if (!string.IsNullOrWhiteSpace(Txt_AracPlaka.Text) && !string.IsNullOrWhiteSpace(Txt_AracSaseNo.Text) && !string.IsNullOrWhiteSpace(Cmb_AracVites.Text) && !string.IsNullOrWhiteSpace(Cmb_AracYakit.Text) && !string.IsNullOrWhiteSpace(Cmb_AracMarka.Text) && !string.IsNullOrWhiteSpace(Cmb_AracSeri.Text))
                {
                    MessageBox.Show(tbl_Arac.AracGuncelle(aracid, Txt_AracPlaka.Text, int.Parse(Cmb_AracMarka.SelectedValue.ToString()), int.Parse(Cmb_AracSeri.SelectedValue.ToString()), int.Parse(Cmb_AracModel.SelectedValue.ToString()), int.Parse(Cmb_AracRenk.SelectedValue.ToString()), Mskd_Yil.Text, int.Parse(Cmb_AracYakit.SelectedValue.ToString()), Cmb_AracVites.Text, int.Parse(Txt_AracKm.Text), int.Parse(Txt_AracMotorHacmi.Text), int.Parse(Txt_AracMotorGucu.Text), Txt_AracSaseNo.Text, Convert.ToInt32(Txt_AracAlisFiyati.Text), decimal.Parse(Txt_AracSatisFiyati.Text), decimal.Parse(Txt_AracSonFiyat.Text), decimal.Parse(Txt_1kaza.Text), decimal.Parse(Txt_2kaza.Text), decimal.Parse(Txt_3kaza.Text), decimal.Parse(Txt_4kaza.Text), decimal.Parse(Txt_5kaza.Text), txt_AracAciklama.Text, "düzenleKullanıcı", int.Parse(Cmb_AracDurum.SelectedValue.ToString())));
                }
                else { MessageBox.Show("Lütfen Zorunlu alanları Dolduralım"); }
            }
            else { MessageBox.Show("Lütfen Güncellencek Kaydı Seçiniz"); }
            AracListYenile();
        }


        private void Mskd_AracSatisMusTc_KeyUp(object sender, KeyEventArgs e)
        {
            if (Mskd_AracSatisMusTc.Text.Count() == 11)
            {
                tbl_musteri.MusKontrol(Mskd_AracSatisMusTc.Text, Lbl_AracSatisMusAdSoyad, Lbl_AracSatisMusTel, Lbl_AracSatisMusDTarih, Lbl_AracSatisMusEhliyetNo);
            }
            else { Lbl_AracSatisMusAdSoyad.Text = "---"; Lbl_AracSatisMusTel.Text = "---"; Lbl_AracSatisMusDTarih.Text = "---"; Lbl_AracSatisMusEhliyetNo.Text = "---"; }
        }

        private void Txt_AracSatisPlaka_TextChanged(object sender, EventArgs e)
        {
            AracKontrol();
        }

        private void Txt_AracSatisSaseNo_TextChanged(object sender, EventArgs e)
        {
            AracKontrol();
        }

        public void AracKontrol()
        {
            if (!string.IsNullOrWhiteSpace(Txt_AracSatisPlaka.Text) && !string.IsNullOrWhiteSpace(Txt_AracSatisSaseNo.Text))
            {
                tbl_Arac.AracKontrol(Txt_AracSatisPlaka.Text, Txt_AracSatisSaseNo.Text, Lbl_AracSatisMarka, Lbl_AracSatisSeri, Lbl_AracSatisModel, Lbl_AracSatisRenk, Lbl_AracSatisYil, Lbl_AracSatisAlisFiyat, Lbl_AracSatisSatisFiyat, Lbl_AracSatisSonFiyat, Lbl_AracSatisSaticiAd, Lbl_AracSatisSaticiTc);
            }
        }

        private void Btn_AracSatisEkle_Click(object sender, EventArgs e)
        {

        }

        private void RdBtn_Pesin_CheckedChanged(object sender, EventArgs e)
        {
            Cmb_AracSatisOdemeTipi.Enabled = false;
            Cmb_AracSatisOdemeTipi.SelectedItem = null;
            Cmb_AracSatisBanka.Enabled = false;
            Cmb_AracSatisBanka.SelectedItem = null;
            Cmb_AracSatisTaksit.Enabled = false;
            Cmb_AracSatisTaksit.SelectedItem = null;
            Dt_OdemeGunu.Enabled = false;
            Num_Komisyon.Value = 0;
            Num_Komisyon.Enabled = false;
            Lbl_Ucret.Text = "---";
            Btn_TaksitBilg.Enabled = false;
        }

        private void RdBtn_Taksit_CheckedChanged(object sender, EventArgs e)
        {
            Cmb_AracSatisOdemeTipi.Enabled = true;
            Cmb_AracSatisTaksit.Enabled = true;
            Dt_OdemeGunu.Enabled = true;
            Num_Komisyon.Enabled = true;
            Btn_TaksitBilg.Enabled = true;
        }

        private void Cmb_AracSatisBanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankaTaksitListCmb();
        }

        decimal satisfiyati = 0;
        private void Cmb_AracSatisTaksit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Cmb_AracSatisTaksit.Text) && !string.IsNullOrWhiteSpace(Txt_Pesinat.Text))
            {
                satisfiyati = decimal.Parse(Lbl_AracSatisSatisFiyat.Text) - decimal.Parse(Txt_Pesinat.Text);
            }
        }


        private void Num_Komisyon_ValueChanged(object sender, EventArgs e)
        {
            Lbl_Ucret.Text = Convert.ToString(satisfiyati * (decimal.Parse(Num_Komisyon.Value.ToString()) / 100));
        }

        private void Cmb_AracSatisOdemeTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_AracSatisOdemeTipi.Text == "Senet")
            {
                Cmb_AracSatisBanka.Enabled = false;
                Cmb_AracSatisBanka.SelectedItem = null;
                tbl_SenetTaksit.BankaTaksitListCmb(Cmb_AracSatisTaksit);
            }
            else { Cmb_AracSatisBanka.Enabled = true; }
        }
    }
}
