using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje13
{
    public partial class Form1 : Form
    {
        double uzunluk, toplam;
        double sonuclar;
        int[] carpanlar = {5, 7, 2, -5, -7, -2 };
        string degisim;
		public Form1(){
            InitializeComponent();
        }

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e){
            toplam = 0;
            sonuclar = 0;
            dgv.Rows.Clear();
            degisim = textBox1.Text.Replace(".","");
            degisim = degisim.Replace(",", "");
            uzunluk = degisim.Length;
            string sayilar  = degisim;
            int[] sayiArray = new int[sayilar.Length];
                for (int a = 0; a < sayilar.Length; a++) {

                    sayiArray[a] = (int)Char.GetNumericValue(sayilar[a]);
                }
            
            int mod;
            Console.WriteLine("Uzunluk: " + sayilar.Length);
            for (int i = 0; i < uzunluk; i++) {

                if (i < 6) {
                    toplam += sayiArray[i] * carpanlar[i];
                    dgv.Rows.Add(sayiArray[i], carpanlar[i], sayiArray[i] * carpanlar[i]);
                }
                else if (i > 5) {
                    mod = i % 6;
                   toplam += sayiArray[i] * carpanlar[mod];
                    dgv.Rows.Add(sayiArray[i], carpanlar[mod], sayiArray[i] * carpanlar[mod]);
                }

            }
            label3.Text = toplam.ToString();
            sonuclar = toplam/13;
            dgv.Rows.Add("", "Toplam", toplam);
            dgv.Rows.Add("","Sonuç ("+ toplam +"/13)", sonuclar.ToString("N6"));
            Console.WriteLine(sonuclar.ToString("#.000000"));
            label5.Text = sonuclar.ToString("N6");
			if (toplam % 13 == 0) {
				label6.Text = "Sayı 13'e tam bölünüyor";
			}
			else {

				label6.Text = "Sayı 13'e tam bölünmüyor";

			}
			
		}
    }
}
