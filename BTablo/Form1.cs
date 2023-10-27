
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BTablo.Classlar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.Reflection.Emit;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BTablo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ParolaTextBox.PasswordChar = '*';
        }



        private void FilterButton_Click(object sender, EventArgs e)
        {

            VeriGetir();




        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        public void sqlbag_Click(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            string baglantiAdresi = baglantiTextBox.Text; // TextBox i�indeki ba�lant� adresini al
            string kullaniciAdi = kAdiTextBox.Text;
            string parola = ParolaTextBox.Text;

            string baglantiString = $"Data Source={baglantiAdresi};Initial Catalog=LOGO_DB;Integrated Security=True;User ID={kullaniciAdi};Password={parola}";
            label585.Text = baglantiAdresi;
            label584.Text = STimeMzn.Value.ToString("d") + " - " + FTimeMzn.Value.ToString("d") + " TAR�HL� B�LAN�O TABLOSU";
            label584.Location = new System.Drawing.Point(410, 31);

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                try
                {
                    sqlbag.BackColor = Color.DarkGreen;
                    MessageBox.Show("Ba�lant� ba�ar�l�!");

                    //Aktif (Varl�klar)
                    //DONEN VARLIKLAR
                    //HAZIR DE�ERLER
                    string kasasorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 100 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double kasa;
                    SqlCommand komut100 = new SqlCommand(kasasorgu, baglanti);
                    baglanti.Open();
                    kasa = (double)komut100.ExecuteScalar();
                    baglanti.Close();
                    label5.Text = Math.Round(kasa, 2).ToString();

                    string alinanCeklersorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 101 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double alinanCekler;
                    SqlCommand komut101 = new SqlCommand(alinanCeklersorgu, baglanti);
                    baglanti.Open();
                    alinanCekler = (double)komut101.ExecuteScalar();
                    baglanti.Close();
                    label6.Text = Math.Round(alinanCekler, 2).ToString();

                    string bankalarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 102 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double bankalar;
                    SqlCommand komut102 = new SqlCommand(bankalarSorgu, baglanti);
                    baglanti.Open();
                    bankalar = (double)komut102.ExecuteScalar();
                    baglanti.Close();
                    label7.Text = Math.Round(bankalar, 2).ToString();

                    string VerCekveOdEmSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 103 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double VerCekveOdEm;
                    SqlCommand komut103 = new SqlCommand(VerCekveOdEmSorgu, baglanti);
                    baglanti.Open();
                    VerCekveOdEm = (double)komut103.ExecuteScalar();
                    baglanti.Close();
                    label12.Text = Math.Round(VerCekveOdEm, 2).ToString();

                    string DigHazK�ymSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 108 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigHazK�ym;
                    SqlCommand komut108 = new SqlCommand(DigHazK�ymSorgu, baglanti);
                    baglanti.Open();
                    DigHazK�ym = (double)komut108.ExecuteScalar();
                    baglanti.Close();
                    label11.Text = Math.Round(DigHazK�ym, 2).ToString();

                    double HazirDegerlerTop = (kasa + alinanCekler + bankalar + VerCekveOdEm + DigHazK�ym);
                    label387.Text = Math.Round(HazirDegerlerTop, 2).ToString();

                    //Haz�r De�erler

                    //Menkul K�ymetler
                    double MenkulK�ymetlerTop = (0 + 0);
                    label10.Text = MenkulK�ymetlerTop.ToString();
                    //Menkul K�ymetler

                    //Ticari Alacaklar

                    string alicilarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 120 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double alicilar;
                    SqlCommand komut120 = new SqlCommand(alicilarSorgu, baglanti);
                    baglanti.Open();
                    alicilar = (double)komut120.ExecuteScalar();
                    baglanti.Close();
                    label8.Text = Math.Round(alicilar, 2).ToString();

                    string alacakSenetleriSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 121 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double alacakSenetleri;
                    SqlCommand komut121 = new SqlCommand(alacakSenetleriSorgu, baglanti);
                    baglanti.Open();
                    alacakSenetleri = (double)komut121.ExecuteScalar();
                    baglanti.Close();
                    label22.Text = Math.Round(alacakSenetleri, 2).ToString();

                    string alacakSenetleriReesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 122 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double alacakSenetleriRees;
                    SqlCommand komut122 = new SqlCommand(alacakSenetleriReesSorgu, baglanti);
                    baglanti.Open();
                    alacakSenetleriRees = (double)komut122.ExecuteScalar();
                    baglanti.Close();
                    label21.Text = Math.Round(alacakSenetleriRees, 2).ToString();

                    string KazFinKirFaizGelSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 124 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KazFinKirFaizGel;
                    SqlCommand komut124 = new SqlCommand(KazFinKirFaizGelSorgu, baglanti);
                    baglanti.Open();
                    KazFinKirFaizGel = (double)komut124.ExecuteScalar();
                    baglanti.Close();
                    label20.Text = Math.Round(KazFinKirFaizGel, 2).ToString();

                    string VerDepveTemSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 126 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double VerDepveTem;
                    SqlCommand komut126 = new SqlCommand(VerDepveTemSorgu, baglanti);
                    baglanti.Open();
                    VerDepveTem = (double)komut126.ExecuteScalar();
                    baglanti.Close();
                    label19.Text = Math.Round(VerDepveTem, 2).ToString();

                    string DigTicAlSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 127 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigTicAl;
                    SqlCommand komut127 = new SqlCommand(DigTicAlSorgu, baglanti);
                    baglanti.Open();
                    DigTicAl = (double)komut127.ExecuteScalar();
                    baglanti.Close();
                    label18.Text = Math.Round(DigTicAl, 2).ToString();

                    string SupTicAlSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 128 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double SupTicAl;
                    SqlCommand komut128 = new SqlCommand(SupTicAlSorgu, baglanti);
                    baglanti.Open();
                    SupTicAl = (double)komut128.ExecuteScalar();
                    baglanti.Close();
                    label17.Text = Math.Round(SupTicAl, 2).ToString();

                    string SupTicAlKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 129 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double SupTicAlKars;
                    SqlCommand komut129 = new SqlCommand(SupTicAlKarsSorgu, baglanti);
                    baglanti.Open();
                    SupTicAlKars = (double)komut129.ExecuteScalar();
                    baglanti.Close();
                    label16.Text = Math.Round(SupTicAlKars, 2).ToString();

                    double ticariAlacaklarTop = (alicilar + alacakSenetleri + alacakSenetleriRees + KazFinKirFaizGel + VerDepveTem + DigTicAl + SupTicAl + SupTicAlKars);
                    label380.Text = Math.Round(ticariAlacaklarTop, 2).ToString();

                    //Ticari Alacaklar

                    //Di�er Alacaklar

                    string ortalacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 131 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double ortalacaklar;
                    SqlCommand komut131 = new SqlCommand(ortalacaklarSorgu, baglanti);
                    baglanti.Open();
                    ortalacaklar = (double)komut131.ExecuteScalar();
                    baglanti.Close();
                    label14.Text = Math.Round(ortalacaklar, 2).ToString();

                    string IstAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 132 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double IstAlacaklar;
                    SqlCommand komut132 = new SqlCommand(IstAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    IstAlacaklar = (double)komut132.ExecuteScalar();
                    baglanti.Close();
                    label13.Text = Math.Round(IstAlacaklar, 2).ToString();

                    string BagOrtAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 133 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double BagOrtAlacaklar;
                    SqlCommand komut133 = new SqlCommand(BagOrtAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    BagOrtAlacaklar = (double)komut133.ExecuteScalar();
                    baglanti.Close();
                    label42.Text = Math.Round(BagOrtAlacaklar, 2).ToString();

                    string PersAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 135 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double PersAlacaklar;
                    SqlCommand komut135 = new SqlCommand(PersAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    PersAlacaklar = (double)komut135.ExecuteScalar();
                    baglanti.Close();
                    label41.Text = Math.Round(PersAlacaklar, 2).ToString();

                    string DigCesAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 136 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigCesAlacaklar;
                    SqlCommand komut136 = new SqlCommand(DigCesAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    DigCesAlacaklar = (double)komut136.ExecuteScalar();
                    baglanti.Close();
                    label40.Text = Math.Round(DigCesAlacaklar, 2).ToString();

                    string DigAlaSenReesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 137 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigAlaSenRees;
                    SqlCommand komut137 = new SqlCommand(DigAlaSenReesSorgu, baglanti);
                    baglanti.Open();
                    DigAlaSenRees = (double)komut137.ExecuteScalar();
                    baglanti.Close();
                    label39.Text = Math.Round(DigAlaSenRees, 2).ToString();

                    string SupDigAlSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 138 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double SupDigAl;
                    SqlCommand komut138 = new SqlCommand(SupDigAlSorgu, baglanti);
                    baglanti.Open();
                    SupDigAl = (double)komut138.ExecuteScalar();
                    baglanti.Close();
                    label38.Text = Math.Round(SupDigAl, 2).ToString();

                    string SupDigAlKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 139 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double SupDigAlKars;
                    SqlCommand komut139 = new SqlCommand(SupDigAlKarsSorgu, baglanti);
                    baglanti.Open();
                    SupDigAlKars = (double)komut139.ExecuteScalar();
                    baglanti.Close();
                    label37.Text = Math.Round(SupDigAlKars, 2).ToString();

                    double DigerAlacaklarTop = (ortalacaklar + IstAlacaklar + BagOrtAlacaklar + PersAlacaklar + DigCesAlacaklar + DigAlaSenRees + SupDigAl + SupDigAlKars);
                    label371.Text = Math.Round(DigerAlacaklarTop, 2).ToString();

                    //Di�er Alacaklar

                    //Stoklar

                    string IlkMadveMalSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 150 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double IlkMadveMal;
                    SqlCommand komut150 = new SqlCommand(IlkMadveMalSorgu, baglanti);
                    baglanti.Open();
                    IlkMadveMal = (double)komut150.ExecuteScalar();
                    baglanti.Close();
                    label35.Text = Math.Round(IlkMadveMal, 2).ToString();

                    string Yar�MamUrSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 151 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double Yar�MamUr;
                    SqlCommand komut151 = new SqlCommand(Yar�MamUrSorgu, baglanti);
                    baglanti.Open();
                    Yar�MamUr = (double)komut151.ExecuteScalar();
                    baglanti.Close();
                    label34.Text = Math.Round(Yar�MamUr, 2).ToString();

                    string MamullerSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 152 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double Mamuller;
                    SqlCommand komut152 = new SqlCommand(MamullerSorgu, baglanti);
                    baglanti.Open();
                    Mamuller = (double)komut152.ExecuteScalar();
                    baglanti.Close();
                    label33.Text = Math.Round(Mamuller, 2).ToString();

                    string TicMalSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 153 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicMal;
                    SqlCommand komut153 = new SqlCommand(TicMalSorgu, baglanti);
                    baglanti.Open();
                    TicMal = (double)komut153.ExecuteScalar();
                    baglanti.Close();
                    label32.Text = Math.Round(TicMal, 2).ToString();

                    string DigerStokSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 157 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigerStok;
                    SqlCommand komut157 = new SqlCommand(DigerStokSorgu, baglanti);
                    baglanti.Open();
                    DigerStok = (double)komut157.ExecuteScalar();
                    baglanti.Close();
                    label31.Text = Math.Round(DigerStok, 2).ToString();

                    string StokDegDusKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 158 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double StokDegDusKars;
                    SqlCommand komut158 = new SqlCommand(StokDegDusKarsSorgu, baglanti);
                    baglanti.Open();
                    StokDegDusKars = (double)komut158.ExecuteScalar();
                    baglanti.Close();
                    label30.Text = Math.Round(StokDegDusKars, 2).ToString();

                    string VerSipAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 159 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double VerSipAvans;
                    SqlCommand komut159 = new SqlCommand(VerSipAvansSorgu, baglanti);
                    baglanti.Open();
                    VerSipAvans = (double)komut159.ExecuteScalar();
                    baglanti.Close();
                    label29.Text = Math.Round(VerSipAvans, 2).ToString();

                    double StoklarTop = (IlkMadveMal + Yar�MamUr + Mamuller + TicMal + DigerStok + StokDegDusKars + VerSipAvans);
                    label362.Text = Math.Round(StoklarTop, 2).ToString();

                    //Stoklar

                    //Y�llara Yayg�n �n�aat ve Onar�m Maaliyetleri
                    double YilYayInsveOnMalTop = (0 + 0);
                    label354.Text = YilYayInsveOnMalTop.ToString();
                    //Y�llara Yayg�n �n�aat ve Onar�m Maaliyetleri

                    //Gelecek Aylara Ait Giderler ve Gelir Tahakkuklar�
                    string GelAyAitGidSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 180 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double GelAyAitGid;
                    SqlCommand komut180 = new SqlCommand(GelAyAitGidSorgu, baglanti);
                    baglanti.Open();
                    GelAyAitGid = (double)komut158.ExecuteScalar();
                    baglanti.Close();
                    label26.Text = Math.Round(GelAyAitGid, 2).ToString();

                    string GelirTahSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 181 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double GelirTah;
                    SqlCommand komut181 = new SqlCommand(GelirTahSorgu, baglanti);
                    baglanti.Open();
                    GelirTah = (double)komut159.ExecuteScalar();
                    baglanti.Close();
                    label25.Text = Math.Round(GelirTah, 2).ToString();

                    double GelAyAitGidveGelTahTop = (GelAyAitGid + GelirTah);
                    label353.Text = Math.Round(GelAyAitGidveGelTahTop, 2).ToString();
                    //Gelecek Aylara Ait Giderler ve Gelir Tahakkuklar�

                    //Di�er D�nen Varl�klar

                    string DevrKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 190 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DevrKDV;
                    SqlCommand komut190 = new SqlCommand(DevrKDVSorgu, baglanti);
                    baglanti.Open();
                    DevrKDV = (double)komut190.ExecuteScalar();
                    baglanti.Close();
                    label23.Text = Math.Round(DevrKDV, 2).ToString();

                    string IndKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 191 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double IndKDV;
                    SqlCommand komut191 = new SqlCommand(IndKDVSorgu, baglanti);
                    baglanti.Open();
                    IndKDV = (double)komut191.ExecuteScalar();
                    baglanti.Close();
                    label62.Text = Math.Round(IndKDV, 2).ToString();

                    string DigKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 192 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigKDV;
                    SqlCommand komut192 = new SqlCommand(DigKDVSorgu, baglanti);
                    baglanti.Open();
                    DigKDV = (double)komut192.ExecuteScalar();
                    baglanti.Close();
                    label61.Text = Math.Round(DigKDV, 2).ToString();

                    string PesOdVerveFonSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 193 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double PesOdVerveFon;
                    SqlCommand komut193 = new SqlCommand(PesOdVerveFonSorgu, baglanti);
                    baglanti.Open();
                    PesOdVerveFon = (double)komut193.ExecuteScalar();
                    baglanti.Close();
                    label60.Text = Math.Round(PesOdVerveFon, 2).ToString();

                    string IsAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 195 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double IsAvans;
                    SqlCommand komut195 = new SqlCommand(IsAvansSorgu, baglanti);
                    baglanti.Open();
                    IsAvans = (double)komut195.ExecuteScalar();
                    baglanti.Close();
                    label59.Text = Math.Round(IsAvans, 2).ToString();

                    string PersAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 196 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double PersAvans;
                    SqlCommand komut196 = new SqlCommand(PersAvansSorgu, baglanti);
                    baglanti.Open();
                    PersAvans = (double)komut196.ExecuteScalar();
                    baglanti.Close();
                    label58.Text = Math.Round(PersAvans, 2).ToString();

                    string SayveTesNoksSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 197 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double SayveTesNoks;
                    SqlCommand komut197 = new SqlCommand(SayveTesNoksSorgu, baglanti);
                    baglanti.Open();
                    SayveTesNoks = (double)komut197.ExecuteScalar();
                    baglanti.Close();
                    label57.Text = Math.Round(SayveTesNoks, 2).ToString();

                    string DigCesDonVarlSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 198 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigCesDonVarl;
                    SqlCommand komut198 = new SqlCommand(DigCesDonVarlSorgu, baglanti);
                    baglanti.Open();
                    DigCesDonVarl = (double)komut198.ExecuteScalar();
                    baglanti.Close();
                    label56.Text = Math.Round(DigCesDonVarl, 2).ToString();

                    string DigDonVarToplKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 199 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigDonVarToplKars;
                    SqlCommand komut199 = new SqlCommand(DigDonVarToplKarsSorgu, baglanti);
                    baglanti.Open();
                    DigDonVarToplKars = (double)komut199.ExecuteScalar();
                    baglanti.Close();
                    label55.Text = Math.Round(DigDonVarToplKars, 2).ToString();

                    double DigDonVarTop = (DevrKDV + IndKDV + DigKDV + PesOdVerveFon + IsAvans + PersAvans + SayveTesNoks + DigCesDonVarl + DigDonVarToplKars);
                    label350.Text = Math.Round(DigDonVarTop, 2).ToString();
                    //Di�er D�nen Varl�klar

                    double DonVartop = (kasa + alinanCekler + bankalar + VerCekveOdEm + DigHazK�ym + alicilar + alacakSenetleri + alacakSenetleriRees + KazFinKirFaizGel + VerDepveTem + DigTicAl + SupTicAl + SupTicAlKars + ortalacaklar +
                        IstAlacaklar + BagOrtAlacaklar + PersAlacaklar + DigCesAlacaklar + DigAlaSenRees + SupDigAl + SupDigAlKars + IlkMadveMal + Yar�MamUr + Mamuller + TicMal + DigerStok + StokDegDusKars + VerSipAvans + GelAyAitGid + GelirTah +
                        DevrKDV + IndKDV + DigKDV + PesOdVerveFon + IsAvans + PersAvans + SayveTesNoks + DigCesDonVarl + DigDonVarToplKars);
                    label340.Text = Math.Round(DonVartop, 2).ToString();

                    double DonVar = (HazirDegerlerTop + MenkulK�ymetlerTop + ticariAlacaklarTop + DigerAlacaklarTop + StoklarTop + YilYayInsveOnMalTop + GelAyAitGidveGelTahTop + DigDonVarTop);
                    label581.Text = Math.Round(DonVar, 2).ToString();
                    //DONEN VARLIKLAR

                    //Duran Varl�klar
                    //Ticari Alacaklar
                    string TicAl�c�larSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 220 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicAl�c�lar;
                    SqlCommand komut220 = new SqlCommand(TicAl�c�larSorgu, baglanti);
                    baglanti.Open();
                    TicAl�c�lar = (double)komut220.ExecuteScalar();
                    baglanti.Close();
                    label50.Text = Math.Round(TicAl�c�lar, 2).ToString();

                    string TicAlacakSenSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 221 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicAlacakSen;
                    SqlCommand komut221 = new SqlCommand(TicAlacakSenSorgu, baglanti);
                    baglanti.Open();
                    TicAlacakSen = (double)komut221.ExecuteScalar();
                    baglanti.Close();
                    label49.Text = Math.Round(TicAlacakSen, 2).ToString();

                    string TicAlacakSenReesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 222 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicAlacakSenRees;
                    SqlCommand komut222 = new SqlCommand(TicAlacakSenReesSorgu, baglanti);
                    baglanti.Open();
                    TicAlacakSenRees = (double)komut222.ExecuteScalar();
                    baglanti.Close();
                    label48.Text = Math.Round(TicAlacakSenRees, 2).ToString();

                    string TicKazFinKirFaizGelSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 224 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicKazFinKirFaizGel;
                    SqlCommand komut224 = new SqlCommand(TicKazFinKirFaizGelSorgu, baglanti);
                    baglanti.Open();
                    TicKazFinKirFaizGel = (double)komut224.ExecuteScalar();
                    baglanti.Close();
                    label47.Text = Math.Round(TicKazFinKirFaizGel, 2).ToString();

                    string TicVerDepveTemSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 226 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicVerDepveTem;
                    SqlCommand komut226 = new SqlCommand(TicVerDepveTemSorgu, baglanti);
                    baglanti.Open();
                    TicVerDepveTem = (double)komut226.ExecuteScalar();
                    baglanti.Close();
                    label46.Text = Math.Round(TicVerDepveTem, 2).ToString();

                    string TicSupAlKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 229 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double TicSupAlKars;
                    SqlCommand komut229 = new SqlCommand(TicSupAlKarsSorgu, baglanti);
                    baglanti.Open();
                    TicSupAlKars = (double)komut229.ExecuteScalar();
                    baglanti.Close();
                    label45.Text = Math.Round(TicSupAlKars, 2).ToString();

                    double TicariAlacaklar = (TicAl�c�lar + TicAlacakSen + TicAlacakSenRees + TicKazFinKirFaizGel + TicVerDepveTem + TicSupAlKars);
                    label338.Text = Math.Round(TicariAlacaklar, 2).ToString();
                    //Ticari Alacaklar

                    //Di�er Alacaklar
                    string DigOrtAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 231 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigOrtAlacaklar;
                    SqlCommand komut231 = new SqlCommand(DigOrtAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    DigOrtAlacaklar = (double)komut231.ExecuteScalar();
                    baglanti.Close();
                    label43.Text = Math.Round(DigOrtAlacaklar, 2).ToString();

                    string DigPersAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 235 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigPersAlacaklar;
                    SqlCommand komut235 = new SqlCommand(DigPersAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    DigPersAlacaklar = (double)komut235.ExecuteScalar();
                    baglanti.Close();
                    label93.Text = Math.Round(DigPersAlacaklar, 2).ToString();

                    string DigDigCesAlacaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 236 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigDigCesAlacaklar;
                    SqlCommand komut236 = new SqlCommand(DigDigCesAlacaklarSorgu, baglanti);
                    baglanti.Open();
                    DigDigCesAlacaklar = (double)komut236.ExecuteScalar();
                    baglanti.Close();
                    label92.Text = Math.Round(DigDigCesAlacaklar, 2).ToString();

                    string DigDigAlSenReesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 237 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigDigAlSenRees;
                    SqlCommand komut237 = new SqlCommand(DigDigAlSenReesSorgu, baglanti);
                    baglanti.Open();
                    DigDigAlSenRees = (double)komut237.ExecuteScalar();
                    baglanti.Close();
                    label91.Text = Math.Round(DigDigAlSenRees, 2).ToString();

                    string DigSupDigAlKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 239 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DigSupDigAlKars;
                    SqlCommand komut239 = new SqlCommand(DigSupDigAlKarsSorgu, baglanti);
                    baglanti.Open();
                    DigSupDigAlKars = (double)komut239.ExecuteScalar();
                    baglanti.Close();
                    label90.Text = Math.Round(DigSupDigAlKars, 2).ToString();

                    double DigerAlacaklar2 = (DigOrtAlacaklar + DigPersAlacaklar + DigDigCesAlacaklar + DigDigAlSenRees + DigSupDigAlKars);
                    label331.Text = Math.Round(DigerAlacaklar2, 2).ToString();
                    //Di�er Alacaklar

                    //Mali Duran Varl�klar
                    string MaliDigMaliDurVarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 248 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MaliDigMaliDurVar;
                    SqlCommand komut248 = new SqlCommand(MaliDigMaliDurVarSorgu, baglanti);
                    baglanti.Open();
                    MaliDigMaliDurVar = (double)komut248.ExecuteScalar();
                    baglanti.Close();
                    label88.Text = Math.Round(MaliDigMaliDurVar, 2).ToString();

                    string MaliDigMaliDurVarKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 249 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MaliDigMaliDurVarKars;
                    SqlCommand komut249 = new SqlCommand(MaliDigMaliDurVarKarsSorgu, baglanti);
                    baglanti.Open();
                    MaliDigMaliDurVarKars = (double)komut249.ExecuteScalar();
                    baglanti.Close();
                    label87.Text = Math.Round(MaliDigMaliDurVarKars, 2).ToString();

                    double MaliDurVar = (MaliDigMaliDurVar + MaliDigMaliDurVarKars);
                    label325.Text = Math.Round(MaliDurVar, 2).ToString();
                    //Mali Duran Varl�klar

                    //Maddi Duran Varl�klar
                    string MadArveArsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 250 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadArveArs;
                    SqlCommand komut250 = new SqlCommand(MadArveArsSorgu, baglanti);
                    baglanti.Open();
                    MadArveArs = (double)komut250.ExecuteScalar();
                    baglanti.Close();
                    label85.Text = Math.Round(MadArveArs, 2).ToString();

                    string MadBinalarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 252 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadBinalar;
                    SqlCommand komut252 = new SqlCommand(MadBinalarSorgu, baglanti);
                    baglanti.Open();
                    MadBinalar = (double)komut252.ExecuteScalar();
                    baglanti.Close();
                    label84.Text = Math.Round(MadBinalar, 2).ToString();

                    string MadTesMakveCihSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 253 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadTesMakveCih;
                    SqlCommand komut253 = new SqlCommand(MadTesMakveCihSorgu, baglanti);
                    baglanti.Open();
                    MadTesMakveCih = (double)komut253.ExecuteScalar();
                    baglanti.Close();
                    label83.Text = Math.Round(MadTesMakveCih, 2).ToString();

                    string MadTas�tlarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 254 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadTas�tlar;
                    SqlCommand komut254 = new SqlCommand(MadTas�tlarSorgu, baglanti);
                    baglanti.Open();
                    MadTas�tlar = (double)komut254.ExecuteScalar();
                    baglanti.Close();
                    label82.Text = Math.Round(MadTas�tlar, 2).ToString();

                    string MadDemirbasSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 255 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadDemirbas;
                    SqlCommand komut255 = new SqlCommand(MadDemirbasSorgu, baglanti);
                    baglanti.Open();
                    MadDemirbas = (double)komut255.ExecuteScalar();
                    baglanti.Close();
                    label81.Text = Math.Round(MadDemirbas, 2).ToString();

                    string MadDigMadDurVarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 256 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadDigMadDurVar;
                    SqlCommand komut256 = new SqlCommand(MadDigMadDurVarSorgu, baglanti);
                    baglanti.Open();
                    MadDigMadDurVar = (double)komut256.ExecuteScalar();
                    baglanti.Close();
                    label80.Text = Math.Round(MadDigMadDurVar, 2).ToString();

                    string MadBirikAmortSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 257 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadBirikAmort;
                    SqlCommand komut257 = new SqlCommand(MadBirikAmortSorgu, baglanti);
                    baglanti.Open();
                    MadBirikAmort = (double)komut257.ExecuteScalar();
                    baglanti.Close();
                    label79.Text = Math.Round(MadBirikAmort, 2).ToString();

                    string MadVerAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 259 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MadVerAvans;
                    SqlCommand komut259 = new SqlCommand(MadVerAvansSorgu, baglanti);
                    baglanti.Open();
                    MadVerAvans = (double)komut259.ExecuteScalar();
                    baglanti.Close();
                    label78.Text = Math.Round(MadVerAvans, 2).ToString();

                    double MadDuranVarl�k = (MadArveArs + MadBinalar + MadTesMakveCih + MadTas�tlar + MadDemirbas + MadDigMadDurVar + MadBirikAmort + MadVerAvans);
                    label322.Text = Math.Round(MadDuranVarl�k, 2).ToString();
                    //Maddi Duran Varl�klar

                    //Maddi Olmayan Duran Varl�klar
                    string MOlmHaklarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 260 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmHaklar;
                    SqlCommand komut260 = new SqlCommand(MOlmHaklarSorgu, baglanti);
                    baglanti.Open();
                    MOlmHaklar = (double)komut260.ExecuteScalar();
                    baglanti.Close();
                    label76.Text = Math.Round(MOlmHaklar, 2).ToString();

                    string MOlmKurveOrgGidSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 262 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmKurveOrgGid;
                    SqlCommand komut262 = new SqlCommand(MOlmKurveOrgGidSorgu, baglanti);
                    baglanti.Open();
                    MOlmKurveOrgGid = (double)komut262.ExecuteScalar();
                    baglanti.Close();
                    label75.Text = Math.Round(MOlmKurveOrgGid, 2).ToString();

                    string MOlmArsveGelGidSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 263 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmArsveGelGid;
                    SqlCommand komut263 = new SqlCommand(MOlmArsveGelGidSorgu, baglanti);
                    baglanti.Open();
                    MOlmArsveGelGid = (double)komut263.ExecuteScalar();
                    baglanti.Close();
                    label74.Text = Math.Round(MOlmArsveGelGid, 2).ToString();

                    string MOlmOzelMalSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 264 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmOzelMal;
                    SqlCommand komut264 = new SqlCommand(MOlmOzelMalSorgu, baglanti);
                    baglanti.Open();
                    MOlmOzelMal = (double)komut264.ExecuteScalar();
                    baglanti.Close();
                    label73.Text = Math.Round(MOlmOzelMal, 2).ToString();

                    string MOlmDigMOlmDurVarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 267 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmDigMOlmDurVar;
                    SqlCommand komut267 = new SqlCommand(MOlmDigMOlmDurVarSorgu, baglanti);
                    baglanti.Open();
                    MOlmDigMOlmDurVar = (double)komut267.ExecuteScalar();
                    baglanti.Close();
                    label72.Text = Math.Round(MOlmDigMOlmDurVar, 2).ToString();

                    string MOlmBirikAmortSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 268 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmBirikAmort;
                    SqlCommand komut268 = new SqlCommand(MOlmBirikAmortSorgu, baglanti);
                    baglanti.Open();
                    MOlmBirikAmort = (double)komut268.ExecuteScalar();
                    baglanti.Close();
                    label71.Text = Math.Round(MOlmBirikAmort, 2).ToString();

                    string MOlmVerAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 269 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double MOlmVerAvans;
                    SqlCommand komut269 = new SqlCommand(MOlmVerAvansSorgu, baglanti);
                    baglanti.Open();
                    MOlmVerAvans = (double)komut269.ExecuteScalar();
                    baglanti.Close();
                    label70.Text = Math.Round(MOlmVerAvans, 2).ToString();

                    double MadOlmDurVar = (MOlmHaklar + MOlmKurveOrgGid + MOlmArsveGelGid + MOlmOzelMal + MOlmDigMOlmDurVar + MOlmBirikAmort + MOlmVerAvans);
                    label313.Text = Math.Round(MadOlmDurVar, 2).ToString();
                    //Maddi Olmayan Duran Varl�klar

                    //�zel T�kenmeye Tabi Varl�klar
                    double OzelTukTabiVar = (0 + 0);
                    label10.Text = OzelTukTabiVar.ToString();
                    //�zel T�kenmeye Tabi Varl�klar

                    //Gelecek Y�llara Ait Gelirler ve Giderler Tahakkuklar�
                    string GYGelY�lAitGidSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 280 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double GYGelY�lAitGid;
                    SqlCommand komut280 = new SqlCommand(GYGelY�lAitGidSorgu, baglanti);
                    baglanti.Open();
                    GYGelY�lAitGid = (double)komut280.ExecuteScalar();
                    baglanti.Close();
                    label67.Text = Math.Round(GYGelY�lAitGid, 2).ToString();

                    string GYGelirTahSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 281 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double GYGelirTah;
                    SqlCommand komut281 = new SqlCommand(GYGelirTahSorgu, baglanti);
                    baglanti.Open();
                    GYGelirTah = (double)komut281.ExecuteScalar();
                    baglanti.Close();
                    label66.Text = Math.Round(GYGelirTah, 2).ToString();

                    double GelY�lAitGidveGelTah = (GYGelY�lAitGid + GYGelirTah);
                    label304.Text = Math.Round(GelY�lAitGidveGelTah, 2).ToString();
                    //Gelecek Y�llara Ait Gelirler ve Giderler Tahakkuklar�

                    //Di�er Duran Varl�klar
                    string DDurGelY�lIndKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 291 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DDurGelY�lIndKDV;
                    SqlCommand komut291 = new SqlCommand(DDurGelY�lIndKDVSorgu, baglanti);
                    baglanti.Open();
                    DDurGelY�lIndKDV = (double)komut291.ExecuteScalar();
                    baglanti.Close();
                    label64.Text = Math.Round(DDurGelY�lIndKDV, 2).ToString();

                    string DDurDigKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 292 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DDurDigKDV;
                    SqlCommand komut292 = new SqlCommand(DDurDigKDVSorgu, baglanti);
                    baglanti.Open();
                    DDurDigKDV = (double)komut292.ExecuteScalar();
                    baglanti.Close();
                    label63.Text = Math.Round(DDurDigKDV, 2).ToString();

                    string DDurPesOdVergveFonSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 295 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DDurPesOdVergveFon;
                    SqlCommand komut295 = new SqlCommand(DDurPesOdVergveFonSorgu, baglanti);
                    baglanti.Open();
                    DDurPesOdVergveFon = (double)komut295.ExecuteScalar();
                    baglanti.Close();
                    label101.Text = Math.Round(DDurPesOdVergveFon, 2).ToString();

                    string DDurDigCesDurVarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 296 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DDurDigCesDurVar;
                    SqlCommand komut296 = new SqlCommand(DDurDigCesDurVarSorgu, baglanti);
                    baglanti.Open();
                    DDurDigCesDurVar = (double)komut296.ExecuteScalar();
                    baglanti.Close();
                    label100.Text = Math.Round(DDurDigCesDurVar, 2).ToString();

                    string DDurStokDegDusKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 297 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DDurStokDegDusKars;
                    SqlCommand komut297 = new SqlCommand(DDurStokDegDusKarsSorgu, baglanti);
                    baglanti.Open();
                    DDurStokDegDusKars = (double)komut297.ExecuteScalar();
                    baglanti.Close();
                    label99.Text = Math.Round(DDurStokDegDusKars, 2).ToString();

                    string DDurBirikAmortSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 298 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double DDurBirikAmort;
                    SqlCommand komut298 = new SqlCommand(DDurBirikAmortSorgu, baglanti);
                    baglanti.Open();
                    DDurBirikAmort = (double)komut298.ExecuteScalar();
                    baglanti.Close();
                    label98.Text = Math.Round(DDurBirikAmort, 2).ToString();


                    double DigDurVar = (DDurGelY�lIndKDV + DDurDigKDV + DDurPesOdVergveFon + DDurDigCesDurVar + DDurStokDegDusKars + DDurBirikAmort);
                    label301.Text = Math.Round(DigDurVar, 2).ToString();
                    //Di�er Duran Varl�klar

                    double DurVar = (TicariAlacaklar + DigerAlacaklar2 + MadDuranVarl�k + MaliDurVar + MadOlmDurVar + OzelTukTabiVar + GelY�lAitGidveGelTah + +DigDurVar);
                    label390.Text = Math.Round(DurVar, 2).ToString();

                    double DurVarTop = (TicAl�c�lar + TicAlacakSen + TicAlacakSenRees + TicKazFinKirFaizGel + TicVerDepveTem + TicSupAlKars + DigOrtAlacaklar + DigPersAlacaklar + DigDigCesAlacaklar + DigDigAlSenRees + DigSupDigAlKars + MaliDigMaliDurVar + MaliDigMaliDurVarKars + MadArveArs + MadBinalar + MadTesMakveCih + MadTas�tlar + MadDemirbas + MadDigMadDurVar + MadBirikAmort + MadVerAvans + MOlmHaklar + MOlmKurveOrgGid + MOlmArsveGelGid + MOlmOzelMal + MOlmDigMOlmDurVar + MOlmBirikAmort + MOlmVerAvans + GYGelY�lAitGid + GYGelirTah + DDurGelY�lIndKDV + DDurDigKDV + DDurPesOdVergveFon + DDurDigCesDurVar + DDurStokDegDusKars + DDurBirikAmort);
                    label532.Text = Math.Round(DurVarTop, 2).ToString();
                    //Duran Varl�klar
                    double AktifVarl�klarTop = (DonVartop + DurVarTop);
                    label389.Text = Math.Round(AktifVarl�klarTop, 2).ToString();
                    //Aktif (Varl�klar)

                    //Pasif (Kaynaklar)
                    //K�sa Vadeli Yabanc� Kaynaklar
                    //Mali Bor�lar
                    string KVMBankaKredileriSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 300 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVMBankaKredileri;
                    SqlCommand komut300 = new SqlCommand(KVMBankaKredileriSorgu, baglanti);
                    baglanti.Open();
                    KVMBankaKredileri = (double)komut300.ExecuteScalar();
                    baglanti.Close();
                    label128.Text = Math.Round(KVMBankaKredileri, 2).ToString();

                    string KVMUzVaKreAnapTakveFaizSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 303 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVMUzVaKreAnapTakveFaiz;
                    SqlCommand komut303 = new SqlCommand(KVMUzVaKreAnapTakveFaizSorgu, baglanti);
                    baglanti.Open();
                    KVMUzVaKreAnapTakveFaiz = (double)komut303.ExecuteScalar();
                    baglanti.Close();
                    label127.Text = Math.Round(KVMUzVaKreAnapTakveFaiz, 2).ToString();

                    string KVMDigMaliBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 309 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVMDigMaliBorc;
                    SqlCommand komut309 = new SqlCommand(KVMDigMaliBorcSorgu, baglanti);
                    baglanti.Open();
                    KVMDigMaliBorc = (double)komut309.ExecuteScalar();
                    baglanti.Close();
                    label126.Text = Math.Round(KVMDigMaliBorc, 2).ToString();

                    double KVMaliBorclar = (KVMBankaKredileri + KVMUzVaKreAnapTakveFaiz + KVMDigMaliBorc);
                    label293.Text = Math.Round(KVMaliBorclar, 2).ToString();
                    //Mali Bor�lar
                    //Ticari Bor�lar
                    string KVTSat�c�larSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 320 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVTSat�c�lar;
                    SqlCommand komut320 = new SqlCommand(KVTSat�c�larSorgu, baglanti);
                    baglanti.Open();
                    KVTSat�c�lar = (double)komut320.ExecuteScalar();
                    baglanti.Close();
                    label124.Text = Math.Round(KVTSat�c�lar, 2).ToString();

                    string KVTBorcSenetSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 321 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVTBorcSenet;
                    SqlCommand komut321 = new SqlCommand(KVTBorcSenetSorgu, baglanti);
                    baglanti.Open();
                    KVTBorcSenet = (double)komut321.ExecuteScalar();
                    baglanti.Close();
                    label123.Text = Math.Round(KVTBorcSenet, 2).ToString();

                    string KVTBorcSenetReesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 322 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVTBorcSenetRees;
                    SqlCommand komut322 = new SqlCommand(KVTBorcSenetReesSorgu, baglanti);
                    baglanti.Open();
                    KVTBorcSenetRees = (double)komut322.ExecuteScalar();
                    baglanti.Close();
                    label122.Text = Math.Round(KVTBorcSenetRees, 2).ToString();

                    string KVTAlDepveTeminatSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 326 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVTAlDepveTeminat;
                    SqlCommand komut326 = new SqlCommand(KVTAlDepveTeminatSorgu, baglanti);
                    baglanti.Open();
                    KVTAlDepveTeminat = (double)komut326.ExecuteScalar();
                    baglanti.Close();
                    label121.Text = Math.Round(KVTAlDepveTeminat, 2).ToString();

                    string KVTDigTicBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 329 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVTDigTicBorc;
                    SqlCommand komut329 = new SqlCommand(KVTDigTicBorcSorgu, baglanti);
                    baglanti.Open();
                    KVTDigTicBorc = (double)komut329.ExecuteScalar();
                    baglanti.Close();
                    label120.Text = Math.Round(KVTDigTicBorc, 2).ToString();

                    double KVTicariBorclar = (KVTSat�c�lar + KVTBorcSenet + KVTBorcSenetRees + KVTAlDepveTeminat + KVTDigTicBorc);
                    label289.Text = Math.Round(KVTicariBorclar, 2).ToString();
                    //Ticari Bor�lar
                    //Di�er Bor�lar
                    string KVDOrtBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 331 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDOrtBorc;
                    SqlCommand komut331 = new SqlCommand(KVDOrtBorcSorgu, baglanti);
                    baglanti.Open();
                    KVDOrtBorc = (double)komut331.ExecuteScalar();
                    baglanti.Close();
                    label118.Text = Math.Round(KVDOrtBorc, 2).ToString();

                    string KVDIstBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 332 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDIstBorc;
                    SqlCommand komut332 = new SqlCommand(KVDIstBorcSorgu, baglanti);
                    baglanti.Open();
                    KVDIstBorc = (double)komut332.ExecuteScalar();
                    baglanti.Close();
                    label117.Text = Math.Round(KVDIstBorc, 2).ToString();

                    string KVDBagOrtBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 333 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDBagOrtBorc;
                    SqlCommand komut333 = new SqlCommand(KVDBagOrtBorcSorgu, baglanti);
                    baglanti.Open();
                    KVDBagOrtBorc = (double)komut333.ExecuteScalar();
                    baglanti.Close();
                    label116.Text = Math.Round(KVDBagOrtBorc, 2).ToString();

                    string KVDPersOlanBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 335 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDPersOlanBorc;
                    SqlCommand komut335 = new SqlCommand(KVDPersOlanBorcSorgu, baglanti);
                    baglanti.Open();
                    KVDPersOlanBorc = (double)komut335.ExecuteScalar();
                    baglanti.Close();
                    label115.Text = Math.Round(KVDPersOlanBorc, 2).ToString();

                    string KVDDigCestBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 336 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDDigCestBorc;
                    SqlCommand komut336 = new SqlCommand(KVDDigCestBorcSorgu, baglanti);
                    baglanti.Open();
                    KVDDigCestBorc = (double)komut336.ExecuteScalar();
                    baglanti.Close();
                    label14.Text = Math.Round(KVDDigCestBorc, 2).ToString();

                    string KVDDigBorcSenTahSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 337 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDDigBorcSenTah;
                    SqlCommand komut337 = new SqlCommand(KVDDigBorcSenTahSorgu, baglanti);
                    baglanti.Open();
                    KVDDigBorcSenTah = (double)komut337.ExecuteScalar();
                    baglanti.Close();
                    label13.Text = Math.Round(KVDDigBorcSenTah, 2).ToString();


                    double KVDigerBorclar = (KVDOrtBorc + KVDIstBorc + KVDBagOrtBorc + KVDPersOlanBorc + KVDDigCestBorc + KVDDigBorcSenTah);
                    label283.Text = Math.Round(KVDigerBorclar, 2).ToString();
                    //Di�er Bor�lar
                    //Al�nan Avanslar
                    string KVAAAlSipAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 340 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVAAAlSipAvans;
                    SqlCommand komut340 = new SqlCommand(KVAAAlSipAvansSorgu, baglanti);
                    baglanti.Open();
                    KVAAAlSipAvans = (double)komut340.ExecuteScalar();
                    baglanti.Close();
                    label111.Text = Math.Round(KVAAAlSipAvans, 2).ToString();

                    string KVAAAlDigAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 349 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVAAAlDigAvans;
                    SqlCommand komut349 = new SqlCommand(KVAAAlDigAvansSorgu, baglanti);
                    baglanti.Open();
                    KVAAAlDigAvans = (double)komut349.ExecuteScalar();
                    baglanti.Close();
                    label110.Text = Math.Round(KVAAAlDigAvans, 2).ToString();


                    double KVAlinanAvans = (KVAAAlSipAvans + KVAAAlDigAvans);
                    label276.Text = Math.Round(KVAlinanAvans, 2).ToString();
                    //Al�nan Avanslar
                    //Y�llara Yayg�n �n�aat ve Hakedi� Bedelleri
                    double KVY�lYayInsveHakBed = (0 + 0);
                    label273.Text = KVY�lYayInsveHakBed.ToString();
                    //Y�llara Yayg�n �n�aat ve Hakedi� Bedelleri
                    //�denecek vergi ve Di�er Y�k�ml�l�kler
                    string KVOdVerveFonSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 360 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVOdVerveFon;
                    SqlCommand komut360 = new SqlCommand(KVOdVerveFonSorgu, baglanti);
                    baglanti.Open();
                    KVOdVerveFon = (double)komut360.ExecuteScalar();
                    baglanti.Close();
                    label107.Text = Math.Round(KVOdVerveFon, 2).ToString();

                    string KVOdSosGuvKesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 361 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVOdSosGuvKes;
                    SqlCommand komut361 = new SqlCommand(KVOdSosGuvKesSorgu, baglanti);
                    baglanti.Open();
                    KVOdSosGuvKes = (double)komut361.ExecuteScalar();
                    baglanti.Close();
                    label106.Text = Math.Round(KVOdSosGuvKes, 2).ToString();

                    string KVVaGe�ErtveTakVerveDYSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 368 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVVaGe�ErtveTakVerveDY;
                    SqlCommand komut368 = new SqlCommand(KVVaGe�ErtveTakVerveDYSorgu, baglanti);
                    baglanti.Open();
                    KVVaGe�ErtveTakVerveDY = (double)komut368.ExecuteScalar();
                    baglanti.Close();
                    label105.Text = Math.Round(KVVaGe�ErtveTakVerveDY, 2).ToString();

                    string KVOdDigYukSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 369 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVOdDigYuk;
                    SqlCommand komut369 = new SqlCommand(KVOdDigYukSorgu, baglanti);
                    baglanti.Open();
                    KVOdDigYuk = (double)komut369.ExecuteScalar();
                    baglanti.Close();
                    label104.Text = Math.Round(KVOdDigYuk, 2).ToString();

                    double KVOdVerveDigYuk = (KVOdVerveFon + KVOdSosGuvKes + KVVaGe�ErtveTakVerveDY + KVOdDigYuk);
                    label272.Text = Math.Round(KVOdVerveDigYuk, 2).ToString();
                    //�denecek vergi ve Di�er Y�k�ml�l�kler
                    //Bor� ve Gider Kar��l�klar�
                    string KVDonKar�VergveDigYasYukKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 370 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDonKar�VergveDigYasYukKars;
                    SqlCommand komut370 = new SqlCommand(KVDonKar�VergveDigYasYukKarsSorgu, baglanti);
                    baglanti.Open();
                    KVDonKar�VergveDigYasYukKars = (double)komut370.ExecuteScalar();
                    baglanti.Close();
                    label102.Text = Math.Round(KVDonKar�VergveDigYasYukKars, 2).ToString();

                    string KVDonKarPesOdVergveDigYukSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 371 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDonKarPesOdVergveDigYuk;
                    SqlCommand komut371 = new SqlCommand(KVDonKarPesOdVergveDigYukSorgu, baglanti);
                    baglanti.Open();
                    KVDonKarPesOdVergveDigYuk = (double)komut371.ExecuteScalar();
                    baglanti.Close();
                    label97.Text = Math.Round(KVDonKarPesOdVergveDigYuk, 2).ToString();

                    string KVK�dTazKArsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 372 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVK�dTazKArs;
                    SqlCommand komut372 = new SqlCommand(KVK�dTazKArsSorgu, baglanti);
                    baglanti.Open();
                    KVK�dTazKArs = (double)komut372.ExecuteScalar();
                    baglanti.Close();
                    label96.Text = Math.Round(KVK�dTazKArs, 2).ToString();

                    string KVMalGidKArsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 373 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVMalGidKArs;
                    SqlCommand komut373 = new SqlCommand(KVMalGidKArsSorgu, baglanti);
                    baglanti.Open();
                    KVMalGidKArs = (double)komut373.ExecuteScalar();
                    baglanti.Close();
                    label53.Text = Math.Round(KVMalGidKArs, 2).ToString();

                    string KVDigBorcveGidKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 379 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDigBorcveGidKars;
                    SqlCommand komut379 = new SqlCommand(KVDigBorcveGidKarsSorgu, baglanti);
                    baglanti.Open();
                    KVDigBorcveGidKars = (double)komut379.ExecuteScalar();
                    baglanti.Close();
                    label162.Text = Math.Round(KVDigBorcveGidKars, 2).ToString();

                    double KVBorcveGiderKars = (KVDonKar�VergveDigYasYukKars + KVDonKarPesOdVergveDigYuk + KVK�dTazKArs + KVMalGidKArs + KVDigBorcveGidKars);
                    label267.Text = Math.Round(KVBorcveGiderKars, 2).ToString();
                    //Bor� ve Gider kar��l�klar�
                    //Gelecek Aylara Ait Gelirler ve Giderler Tahakkuklar�
                    string KVGelAyAitGelirlerSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 380 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVGelAyAitGelirler;
                    SqlCommand komut380 = new SqlCommand(KVGelAyAitGelirlerSorgu, baglanti);
                    baglanti.Open();
                    KVGelAyAitGelirler = (double)komut380.ExecuteScalar();
                    baglanti.Close();
                    label160.Text = Math.Round(KVGelAyAitGelirler, 2).ToString();

                    string KVGidTahSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 381 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVGidTah;
                    SqlCommand komut381 = new SqlCommand(KVGidTahSorgu, baglanti);
                    baglanti.Open();
                    KVGidTah = (double)komut381.ExecuteScalar();
                    baglanti.Close();
                    label59.Text = Math.Round(KVGidTah, 2).ToString();

                    double KVGelAyAitGelveGidTah = (KVGelAyAitGelirler + KVGidTah);
                    label261.Text = Math.Round(KVGelAyAitGelveGidTah, 2).ToString();
                    //Gelecek Aylara Ait Gelirler ve Giderler Tahakkuklar�
                    //Di�er K�sa Vadeli Yabanc� Kaynaklar
                    string KVHesKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 391 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVHesKDV;
                    SqlCommand komut391 = new SqlCommand(KVHesKDVSorgu, baglanti);
                    baglanti.Open();
                    KVHesKDV = (double)komut391.ExecuteScalar();
                    baglanti.Close();
                    label157.Text = Math.Round(KVHesKDV, 2).ToString();

                    string KVDigKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 392 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDigKDV;
                    SqlCommand komut392 = new SqlCommand(KVDigKDVSorgu, baglanti);
                    baglanti.Open();
                    KVDigKDV = (double)komut392.ExecuteScalar();
                    baglanti.Close();
                    label156.Text = Math.Round(KVDigKDV, 2).ToString();

                    string KVSayveTesFazSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 395 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVSayveTesFaz;
                    SqlCommand komut395 = new SqlCommand(KVSayveTesFazSorgu, baglanti);
                    baglanti.Open();
                    KVSayveTesFaz = (double)komut395.ExecuteScalar();
                    baglanti.Close();
                    label155.Text = Math.Round(KVSayveTesFaz, 2).ToString();

                    string KVDigCesYabKaySorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 399 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double KVDigCesYabKay;
                    SqlCommand komut399 = new SqlCommand(KVDigCesYabKaySorgu, baglanti);
                    baglanti.Open();
                    KVDigCesYabKay = (double)komut399.ExecuteScalar();
                    baglanti.Close();
                    label154.Text = Math.Round(KVDigCesYabKay, 2).ToString();

                    double KVDigK�saVadYabKay = (KVHesKDV + KVDigKDV + KVSayveTesFaz + KVDigCesYabKay);
                    label258.Text = Math.Round(KVDigK�saVadYabKay, 2).ToString();
                    //Di�er K�sa Vadeli Yabanc� Kaynaklar
                    double KisaVadeliYabanciKaynaklar = (KVMaliBorclar + KVTicariBorclar + KVDigerBorclar + KVAlinanAvans + KVOdVerveDigYuk + KVBorcveGiderKars + KVGelAyAitGelveGidTah + KVDigK�saVadYabKay);
                    label253.Text = Math.Round(KisaVadeliYabanciKaynaklar, 2).ToString();
                    label487.Text = Math.Round(KisaVadeliYabanciKaynaklar, 2).ToString();
                    //K�sa Vadeli Yabanc� Kaynaklar

                    //Uzun Vadeli Yabanc� Kaynaklar
                    //Mali Bor�lar
                    string UVYKBankaKrediSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 400 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKBankaKredi;
                    SqlCommand komut400 = new SqlCommand(UVYKBankaKrediSorgu, baglanti);
                    baglanti.Open();
                    UVYKBankaKredi = (double)komut400.ExecuteScalar();
                    baglanti.Close();
                    label149.Text = Math.Round(UVYKBankaKredi, 2).ToString();

                    string UVYKFinKirIsBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 401 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKFinKirIsBorc;
                    SqlCommand komut401 = new SqlCommand(UVYKFinKirIsBorcSorgu, baglanti);
                    baglanti.Open();
                    UVYKFinKirIsBorc = (double)komut401.ExecuteScalar();
                    baglanti.Close();
                    label148.Text = Math.Round(UVYKFinKirIsBorc, 2).ToString();

                    string UVYKErtFinKirBorcMalSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 402 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKErtFinKirBorcMal;
                    SqlCommand komut402 = new SqlCommand(UVYKErtFinKirBorcMalSorgu, baglanti);
                    baglanti.Open();
                    UVYKErtFinKirBorcMal = (double)komut402.ExecuteScalar();
                    baglanti.Close();
                    label147.Text = Math.Round(UVYKErtFinKirBorcMal, 2).ToString();

                    string UVYKC�kTahvilSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 405 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKC�kTahvil;
                    SqlCommand komut405 = new SqlCommand(UVYKC�kTahvilSorgu, baglanti);
                    baglanti.Open();
                    UVYKC�kTahvil = (double)komut405.ExecuteScalar();
                    baglanti.Close();
                    label146.Text = Math.Round(UVYKC�kTahvil, 2).ToString();

                    string UVYKC�kDigMenK�ymSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 407 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKC�kDigMenK�ym;
                    SqlCommand komut407 = new SqlCommand(UVYKC�kDigMenK�ymSorgu, baglanti);
                    baglanti.Open();
                    UVYKC�kDigMenK�ym = (double)komut407.ExecuteScalar();
                    baglanti.Close();
                    label145.Text = Math.Round(UVYKC�kDigMenK�ym, 2).ToString();

                    string UVYKMenkK�ymSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 408 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKMenkK�ym;
                    SqlCommand komut408 = new SqlCommand(UVYKMenkK�ymSorgu, baglanti);
                    baglanti.Open();
                    UVYKMenkK�ym = (double)komut408.ExecuteScalar();
                    baglanti.Close();
                    label144.Text = Math.Round(UVYKMenkK�ym, 2).ToString();

                    string UVYKDigMaliBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 409 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKDigMaliBorc;
                    SqlCommand komut409 = new SqlCommand(UVYKDigMaliBorcSorgu, baglanti);
                    baglanti.Open();
                    UVYKDigMaliBorc = (double)komut409.ExecuteScalar();
                    baglanti.Close();
                    label143.Text = Math.Round(UVYKDigMaliBorc, 2).ToString();

                    double UVYKMaliBorclar = (UVYKBankaKredi + UVYKFinKirIsBorc + UVYKErtFinKirBorcMal + UVYKC�kTahvil + UVYKC�kDigMenK�ym + UVYKMenkK�ym + UVYKDigMaliBorc);
                    label251.Text = Math.Round(UVYKMaliBorclar, 2).ToString();
                    //Mali Bor�lar
                    //Ticari Bor�lar
                    string UVYKSat�c�larSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 420 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKSat�c�lar;
                    SqlCommand komut420 = new SqlCommand(UVYKSat�c�larSorgu, baglanti);
                    baglanti.Open();
                    UVYKSat�c�lar = (double)komut420.ExecuteScalar();
                    baglanti.Close();
                    label141.Text = Math.Round(UVYKSat�c�lar, 2).ToString();

                    string UVYKBorcSenetSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 421 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKBorcSenet;
                    SqlCommand komut421 = new SqlCommand(UVYKBorcSenetSorgu, baglanti);
                    baglanti.Open();
                    UVYKBorcSenet = (double)komut421.ExecuteScalar();
                    baglanti.Close();
                    label140.Text = Math.Round(UVYKBorcSenet, 2).ToString();

                    string UVYKBorcSenetReesSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 422 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKBorcSenetRees;
                    SqlCommand komut422 = new SqlCommand(UVYKBorcSenetReesSorgu, baglanti);
                    baglanti.Open();
                    UVYKBorcSenetRees = (double)komut422.ExecuteScalar();
                    baglanti.Close();
                    label139.Text = Math.Round(UVYKBorcSenetRees, 2).ToString();

                    string UVYKAlDepveTemSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 426 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKAlDepveTem;
                    SqlCommand komut426 = new SqlCommand(UVYKAlDepveTemSorgu, baglanti);
                    baglanti.Open();
                    UVYKAlDepveTem = (double)komut426.ExecuteScalar();
                    baglanti.Close();
                    label138.Text = Math.Round(UVYKAlDepveTem, 2).ToString();

                    string UVYKDigTicBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 429 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKDigTicBorc;
                    SqlCommand komut429 = new SqlCommand(UVYKDigTicBorcSorgu, baglanti);
                    baglanti.Open();
                    UVYKDigTicBorc = (double)komut429.ExecuteScalar();
                    baglanti.Close();
                    label137.Text = Math.Round(UVYKDigTicBorc, 2).ToString();

                    double UVYKTicariBorclar = (UVYKSat�c�lar + UVYKBorcSenet + UVYKBorcSenetRees + UVYKAlDepveTem + UVYKDigTicBorc);
                    label243.Text = Math.Round(UVYKTicariBorclar, 2).ToString();
                    //Ticari Bor�lar
                    //Di�er Bor�lar
                    string UVYKOrtBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 431 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKOrtBorc;
                    SqlCommand komut431 = new SqlCommand(UVYKOrtBorcSorgu, baglanti);
                    baglanti.Open();
                    UVYKOrtBorc = (double)komut431.ExecuteScalar();
                    baglanti.Close();
                    label135.Text = Math.Round(UVYKOrtBorc, 2).ToString();

                    string UVYKDigCesBorcSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 436 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKDigCesBorc;
                    SqlCommand komut436 = new SqlCommand(UVYKDigCesBorcSorgu, baglanti);
                    baglanti.Open();
                    UVYKDigCesBorc = (double)komut436.ExecuteScalar();
                    baglanti.Close();
                    label134.Text = Math.Round(UVYKDigCesBorc, 2).ToString();

                    double UVYKDigerBorc = (UVYKOrtBorc + UVYKDigCesBorc);
                    label237.Text = Math.Round(UVYKDigerBorc, 2).ToString();
                    //Di�er Bor�lar
                    //Al�nan Avanslar
                    string UVYKAlSipAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 440 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKAlSipAvans;
                    SqlCommand komut440 = new SqlCommand(UVYKAlSipAvansSorgu, baglanti);
                    baglanti.Open();
                    UVYKAlSipAvans = (double)komut440.ExecuteScalar();
                    baglanti.Close();
                    label132.Text = Math.Round(UVYKAlSipAvans, 2).ToString();

                    string UVYKAlDigAvansSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 449 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKAlDigAvans;
                    SqlCommand komut449 = new SqlCommand(UVYKAlDigAvansSorgu, baglanti);
                    baglanti.Open();
                    UVYKAlDigAvans = (double)komut449.ExecuteScalar();
                    baglanti.Close();
                    label131.Text = Math.Round(UVYKAlDigAvans, 2).ToString();

                    double UVYKAlinanAvanslar = (UVYKAlSipAvans + UVYKAlDigAvans);
                    label234.Text = Math.Round(UVYKAlinanAvanslar, 2).ToString();
                    //Al�nan Avanslar
                    //Bor� ve Gider Kar��l�klar�
                    string UVYKK�dTazKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 472 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKK�dTazKars;
                    SqlCommand komut472 = new SqlCommand(UVYKK�dTazKarsSorgu, baglanti);
                    baglanti.Open();
                    UVYKK�dTazKars = (double)komut472.ExecuteScalar();
                    baglanti.Close();
                    label193.Text = Math.Round(UVYKK�dTazKars, 2).ToString();

                    string UVYKDigBorcveGidKarsSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 479 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKDigBorcveGidKars;
                    SqlCommand komut479 = new SqlCommand(UVYKDigBorcveGidKarsSorgu, baglanti);
                    baglanti.Open();
                    UVYKDigBorcveGidKars = (double)komut479.ExecuteScalar();
                    baglanti.Close();
                    label192.Text = Math.Round(UVYKDigBorcveGidKars, 2).ToString();

                    double UVYKBorcveGiderKars = (UVYKK�dTazKars + UVYKDigBorcveGidKars);
                    label231.Text = Math.Round(UVYKBorcveGiderKars, 2).ToString();
                    //Bor� ve Gider kar��l�klar�
                    //Gelecek Aylara Ait Gelirler ve Giderler Tahakkuklar�
                    string UVYKGelY�lAitGidSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 480 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKGelY�lAitGid;
                    SqlCommand komut480 = new SqlCommand(UVYKGelY�lAitGidSorgu, baglanti);
                    baglanti.Open();
                    UVYKGelY�lAitGid = (double)komut480.ExecuteScalar();
                    baglanti.Close();
                    label190.Text = Math.Round(UVYKGelY�lAitGid, 2).ToString();

                    string UVYKGiderTaahSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 481 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKGiderTaah;
                    SqlCommand komut481 = new SqlCommand(UVYKGiderTaahSorgu, baglanti);
                    baglanti.Open();
                    UVYKGiderTaah = (double)komut481.ExecuteScalar();
                    baglanti.Close();
                    label189.Text = Math.Round(UVYKGiderTaah, 2).ToString();

                    double UVYKGelAyAitGelveGidTaah = (UVYKGelY�lAitGid + UVYKGiderTaah);
                    label3.Text = Math.Round(UVYKGelAyAitGelveGidTaah, 2).ToString();
                    //Gelecek Aylara Ait Gelirler ve Giderler Tahakkuklar�
                    //Di�er Uzun Vadeli Yabanc� Kaynaklar
                    string UVYKGelY�lErtTerEdKDVSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 492 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKGelY�lErtTerEdKDV;
                    SqlCommand komut492 = new SqlCommand(UVYKGelY�lErtTerEdKDVSorgu, baglanti);
                    baglanti.Open();
                    UVYKGelY�lErtTerEdKDV = (double)komut492.ExecuteScalar();
                    baglanti.Close();
                    label224.Text = Math.Round(UVYKGelY�lErtTerEdKDV, 2).ToString();

                    string UVYKTesKatPaySorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 493 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKTesKatPay;
                    SqlCommand komut493 = new SqlCommand(UVYKTesKatPaySorgu, baglanti);
                    baglanti.Open();
                    UVYKTesKatPay = (double)komut493.ExecuteScalar();
                    baglanti.Close();
                    label186.Text = Math.Round(UVYKTesKatPay, 2).ToString();

                    string UVYKDigCesUVYKSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 499 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double UVYKDigCesUVYK;
                    SqlCommand komut499 = new SqlCommand(UVYKDigCesUVYKSorgu, baglanti);
                    baglanti.Open();
                    UVYKDigCesUVYK = (double)komut499.ExecuteScalar();
                    baglanti.Close();
                    label185.Text = Math.Round(UVYKDigCesUVYK, 2).ToString();

                    double UVYKDigerUzunVadKayn = (UVYKGelY�lErtTerEdKDV + UVYKTesKatPay + UVYKDigCesUVYK);
                    label225.Text = Math.Round(UVYKDigerUzunVadKayn, 2).ToString();
                    //Di�er Uzun Vadeli Yabanc� Kaynaklar
                    double UzunVadeliYabanciKaynaklar = (UVYKMaliBorclar + UVYKTicariBorclar + UVYKDigerBorc + UVYKAlinanAvanslar + UVYKBorcveGiderKars + UVYKGelAyAitGelveGidTaah + UVYKDigerUzunVadKayn);
                    label221.Text = Math.Round(UzunVadeliYabanciKaynaklar, 2).ToString();
                    label445.Text = Math.Round(UzunVadeliYabanciKaynaklar, 2).ToString();
                    //Uzun Vadeli Yabanc� Kaynaklar

                    //�zkaynaklar
                    //�denmi� Sermaye
                    string OSermayeSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 500 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OSermaye;
                    SqlCommand komut500 = new SqlCommand(OSermayeSorgu, baglanti);
                    baglanti.Open();
                    OSermaye = (double)komut500.ExecuteScalar();
                    baglanti.Close();
                    label180.Text = Math.Round(OSermaye, 2).ToString();

                    string OOdenmemisSermayeSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 501 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OOdenmemisSermaye;
                    SqlCommand komut501 = new SqlCommand(OOdenmemisSermayeSorgu, baglanti);
                    baglanti.Open();
                    OOdenmemisSermaye = (double)komut501.ExecuteScalar();
                    baglanti.Close();
                    label179.Text = Math.Round(OOdenmemisSermaye, 2).ToString();

                    string OSermDuzOlmluFarkSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 502 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OSermDuzOlmluFark;
                    SqlCommand komut502 = new SqlCommand(OSermDuzOlmluFarkSorgu, baglanti);
                    baglanti.Open();
                    OSermDuzOlmluFark = (double)komut502.ExecuteScalar();
                    baglanti.Close();
                    label178.Text = Math.Round(OSermDuzOlmluFark, 2).ToString();

                    string OSermDuzOlmsuzFarkSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 503 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OSermDuzOlmsuzFark;
                    SqlCommand komut503 = new SqlCommand(OSermDuzOlmsuzFarkSorgu, baglanti);
                    baglanti.Open();
                    OSermDuzOlmsuzFark = (double)komut503.ExecuteScalar();
                    baglanti.Close();
                    label178.Text = Math.Round(OSermDuzOlmsuzFark, 2).ToString();


                    double OOdenmi�Sermaye = (OSermaye + OOdenmemisSermaye + OSermDuzOlmluFark + OSermDuzOlmsuzFark);
                    label219.Text = Math.Round(OOdenmi�Sermaye, 2).ToString();
                    //�denmi� Sermaye
                    //Sermaye Yedekleri
                    string OMDVYenDegArtSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 522 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OMDVYenDegArt;
                    SqlCommand komut522 = new SqlCommand(OMDVYenDegArtSorgu, baglanti);
                    baglanti.Open();
                    OMDVYenDegArt = (double)komut522.ExecuteScalar();
                    baglanti.Close();
                    label175.Text = Math.Round(OMDVYenDegArt, 2).ToString();

                    string ODigSermYedSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 529 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double ODigSermYed;
                    SqlCommand komut529 = new SqlCommand(ODigSermYedSorgu, baglanti);
                    baglanti.Open();
                    ODigSermYed = (double)komut529.ExecuteScalar();
                    baglanti.Close();
                    label174.Text = Math.Round(ODigSermYed, 2).ToString();
                    label173.Text = Math.Round(ODigSermYed, 2).ToString();

                    double OSermayeYedekleri = (OMDVYenDegArt + ODigSermYed);
                    label214.Text = Math.Round(OSermayeYedekleri, 2).ToString();
                    //Sermaye Yedekleri
                    //K�r Yedekleri
                    string OYasalYedekSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 540 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OYasalYedek;
                    SqlCommand komut540 = new SqlCommand(OYasalYedekSorgu, baglanti);
                    baglanti.Open();
                    OYasalYedek = (double)komut500.ExecuteScalar();
                    baglanti.Close();
                    label171.Text = Math.Round(OYasalYedek, 2).ToString();

                    string ODigKarYedekSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 548 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double ODigKarYedek;
                    SqlCommand komut548 = new SqlCommand(ODigKarYedekSorgu, baglanti);
                    baglanti.Open();
                    ODigKarYedek = (double)komut548.ExecuteScalar();
                    baglanti.Close();
                    label170.Text = Math.Round(ODigKarYedek, 2).ToString();

                    string OOzelFonSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 549 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OOzelFon;
                    SqlCommand komut549 = new SqlCommand(OOzelFonSorgu, baglanti);
                    baglanti.Open();
                    OOzelFon = (double)komut549.ExecuteScalar();
                    baglanti.Close();
                    label169.Text = Math.Round(OOzelFon, 2).ToString();

                    double OKarYedekleri = (OYasalYedek + ODigKarYedek + OOzelFon);
                    label210.Text = Math.Round(OKarYedekleri, 2).ToString();
                    //K�r Yedekleri
                    //Ge�mi� Y�llar K�rlar�
                    string OGecY�lKarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 570 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OGecY�lKar;
                    SqlCommand komut570 = new SqlCommand(OGecY�lKarSorgu, baglanti);
                    baglanti.Open();
                    OGecY�lKar = (double)komut570.ExecuteScalar();
                    baglanti.Close();
                    label167.Text = Math.Round(OGecY�lKar, 2).ToString();

                    double OGecmisY�lKar = (OGecY�lKar);
                    label206.Text = Math.Round(OGecmisY�lKar, 2).ToString();
                    //Ge�mi� Y�llar K�rlar�
                    //Ge�mi� Y�llar Zararlar�
                    string OGecY�lZararSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 580 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double OGecY�lZarar;
                    SqlCommand komut580 = new SqlCommand(OGecY�lZararSorgu, baglanti);
                    baglanti.Open();
                    OGecY�lZarar = (double)komut580.ExecuteScalar();
                    baglanti.Close();
                    label165.Text = Math.Round(OGecY�lZarar, 2).ToString();

                    double OGecmisY�lZarar = (OGecY�lZarar);
                    label204.Text = Math.Round(OGecmisY�lZarar, 2).ToString();
                    //Ge�mi� Y�llar Zararlar�
                    //D�nem Net K�r� (Zarar�)
                    string ODonNetKarSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 590 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double ODonNetKar;
                    SqlCommand komut590 = new SqlCommand(ODonNetKarSorgu, baglanti);
                    baglanti.Open();
                    ODonNetKar = (double)komut590.ExecuteScalar();
                    baglanti.Close();
                    label163.Text = Math.Round(ODonNetKar, 2).ToString();

                    string ODonNetZararSorgu = "SELECT ISNULL(SUM(DEBIT),0) FROM [LOGO_DB].[dbo].[LG_500_01_EMFLINE] WHERE KEBIRCODE = 591 and (DATE_ BETWEEN '" + STimeMzn.Value.ToString("yyyy-MM-dd") + "' and '" + FTimeMzn.Value.ToString("yyyy-MM-dd") + "')";
                    double ODonNetZarar;
                    SqlCommand komut591 = new SqlCommand(ODonNetZararSorgu, baglanti);
                    baglanti.Open();
                    ODonNetZarar = (double)komut591.ExecuteScalar();
                    baglanti.Close();
                    label192.Text = Math.Round(ODonNetZarar, 2).ToString();


                    double ODonNetKarZarar = (ODonNetKar + ODonNetZarar);
                    label202.Text = Math.Round(ODonNetKarZarar, 2).ToString();
                    //D�nem Net K�r� (Zarar�)
                    double Ozkaynaklar = (OOdenmi�Sermaye + OSermayeYedekleri + OKarYedekleri + OGecmisY�lKar + OGecmisY�lZarar + ODonNetKarZarar);
                    label183.Text = Math.Round(Ozkaynaklar, 2).ToString();
                    double OzkaynaklarTop = (OSermaye + OOdenmemisSermaye + OSermDuzOlmluFark + OSermDuzOlmsuzFark + OMDVYenDegArt + ODigSermYed + OYasalYedek + ODigKarYedek + OOzelFon + OGecY�lKar + ODonNetKar + ODonNetZarar);
                    label413.Text = Math.Round(OzkaynaklarTop, 2).ToString();
                    //�zkaynaklar
                    double PasifVarl�klarTop = (KisaVadeliYabanciKaynaklar + UzunVadeliYabanciKaynaklar + OzkaynaklarTop);
                    label391.Text = Math.Round(PasifVarl�klarTop, 2).ToString();
                    //Pasif (Kaynaklar)

                    double TumDegerToplam = (AktifVarl�klarTop + PasifVarl�klarTop);
                    label582.Text = (Math.Round(TumDegerToplam, 2) + "\u20ba").ToString();
                    label582.Location = new System.Drawing.Point(535, 63);

                }
                catch (Exception ex)
                {
                    sqlbag.BackColor = System.Drawing.Color.Red;
                    MessageBox.Show("Ba�lant� hatas�: " + ex.Message);
                }
            }
        }

        public void VeriGetir()
        {

            //string baglantiCumlesi = "Data Source=OFK;Initial Catalog=LOGO_DB;Persist Security Info=True;User ID=SA;Password=kurt135710";
            //string baglantiCumlesi = textBox1.Text;
            //System.Data.DataTable dt = new System.Data.DataTable();
            //SqlConnection baglanti = new SqlConnection(baglantiCumlesi);


            //string baglantiCumlesi = "Data Source=OFK;Initial Catalog=LOGO_DB;Persist Security Info=True;User ID=SA;Password=kurt135710";
            //System.Data.DataTable dt = new System.Data.DataTable();
            //SqlConnection baglanti = new SqlConnection(baglantiCumlesi);




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    ParolaTextBox.PasswordChar = '\0';
                }
                else
                {
                    ParolaTextBox.PasswordChar = '*';
                }
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}


