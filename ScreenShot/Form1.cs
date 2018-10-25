using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Bitmap Screenshot()
        {
            // Ekran resmi alınmadan önce formun kaybolmasını sağlıyoruz.
            this.Opacity = 0;

            // SS alan kodlar
            Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            // SS alan kodlar

            this.Opacity = 1;
            // Ekran resmi alınmadan önce formun görünmesini sağlıyoruz.
            return Screenshot;
            // Ekran resmini geri dönüş yapıyoruz.
        }
        string KayitYolu = @"C:\Ekran_Resimleri";
        string ResimAdi()
        {
            return "SS_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_") + ".jpg";
            // Örnek Resim Adı : SS_19.06.2018_12_48_50.jpg 
            // Saniyeye kadar aldıkki resim adları çakışmasın. Çakışma olması durumda eskiyi siler. Üzerine yazar.
        }
        void Kaydet(string resimadi)
        {
            // C dizinine bir klasör açıyoruz. 
            // Klasör varsa hiçbir işlem yapmayacak
            // Klasör yoksa klasör oluşturacak.
            if (!File.Exists(KayitYolu))
                Directory.CreateDirectory(KayitYolu);

            // Aldığımız resmi kayıt ediyoruz.
            Screenshot().Save(KayitYolu + "\\" + resimadi + "", ImageFormat.Jpeg);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Home)
                Kaydet(ResimAdi());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Kaydet(ResimAdi());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}
