using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Craps
{
    public partial class Craps : Form
    {
        public Craps()
        {
            InitializeComponent();
        }
        int[] AtilanZarlar = new int[1];
        int i = 0;
        bool durum = false;
        private void btnzar_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int zar1 = rastgele.Next(1, 7);
            int zar2 = rastgele.Next(1, 7);
            int toplam = zar1 + zar2;

            if (durum==true)
            {
                listBox1.Items.Clear();
                durum = false;
            }
            if (toplam==7 || toplam==11)
            {
                lbldurum.Text = "Tebrikler, Kazandınız";
                lblsayi.Text = toplam.ToString();
                Array.Resize(ref AtilanZarlar, 1);
                i = 0;
                listBox1.Items.Clear();
            }
            else if (toplam==2 || toplam==3 || toplam==12)
            {
                lbldurum.Text = "Kaybettiniz";
                lblsayi.Text = toplam.ToString();
                Array.Resize(ref AtilanZarlar, 1);
                i = 0;
                listBox1.Items.Clear();
               
            }
            else//,4,5,6,8,9,10
            {               
                if (Array.IndexOf(AtilanZarlar, toplam) == -1)
                {
                    AtilanZarlar[i] = toplam;
                    listBox1.Items.Add(AtilanZarlar[i]);
                    i++;
                    Array.Resize(ref AtilanZarlar, AtilanZarlar.Length + 1);
                    lbldurum.Text = "Sonuç belli değil,tekrar zar atınız";
                    lblsayi.Text = toplam.ToString();
                }
                else
                {
                    lbldurum.Text = "Tebrikler, Kazandınız";
                    lblsayi.Text = toplam.ToString();
                    listBox1.Items.Add(toplam);
                    Array.Resize(ref AtilanZarlar, 1);
                    i = 0;
                    durum = true;
                }
            }
        }
    }
}
