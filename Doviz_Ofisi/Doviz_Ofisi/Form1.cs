using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDosya=new XmlDocument();
            xmlDosya.Load(bugun);

            string dolarAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAl.Text = dolarAlis;

            string dolarSatis=xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSat.Text = dolarSatis;

            string euroAlis= xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAl.Text = euroAlis;
            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSat.Text = euroSatis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtKur.Text=lblDolarAl.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSat.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtKur.Text=lblEuroAl.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtKur.Text=lblEuroSat.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur=Convert.ToDouble(txtKur.Text);
            miktar=Convert.ToDouble(txtMiktar.Text);
            tutar = kur * miktar;
            txtTutar.Text =tutar.ToString();
        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text = txtKur.Text.Replace(".",",");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double kur=Convert.ToDouble(txtKur.Text);
            int tutar = Convert.ToInt32(txtTutar.Text);
            int miktar=Convert.ToInt32( tutar/kur);
            txtMiktar.Text=miktar.ToString();

            txtKalan.Text = (tutar - (miktar * kur)).ToString();
        }
    }
}
