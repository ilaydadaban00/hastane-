using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_otomasyon_n96
{
    public partial class Form1 : Form
    {
        BindingList<Hasta> hastalar = new BindingList<Hasta>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string adSoyad = txtAd.Text;
            string telefon = txtTelefon.Text;
            string polinik = cmbPolikinlik.Text;
            bool sigorta = cbSigorta.Checked;
            DateTime tarih = DateTime.Now;

            Hasta hasta1 = new Hasta(id, adSoyad, telefon, polinik, sigorta, tarih);

            hastalar.Add(hasta1);

            // dataGridView1.DataSource = hastalar.ToList();
            txtAd.Clear();
            txtId.Clear();
            txtTelefon.Clear();
            cbSigorta.Checked = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;
                hasta.AdSoyad=txtAd.Text;
                hasta.Telefon=txtTelefon.Text;
                hasta.Poliklinik=cmbPolikinlik.Text;
                hasta.Sigorta = cbSigorta.Checked;
                hasta.KayitTarih = dateTimePicker1.Value;

                dataGridView1.Refresh();//datagriwi surekli yeniliyor...
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hasta hasta1 = new Hasta(1, "ilayda daban", "5465465464", "göz", false, new DateTime(2023, 11, 06));
            Hasta hasta2 = new Hasta(2, "melek erisgin", "54645452415", "kbb", true, new DateTime(2023, 11, 25));
            Hasta hasta3 = new Hasta(3, "melisa tugtekin", "546553", "beyin", false, new DateTime(2023, 11, 16));
            Hasta hasta4 = new Hasta(4, "nisa yılbur", "546535264", "beyin", true, new DateTime(2023, 10, 06));
            Hasta hasta5 = new Hasta(5, "kübra tas", "546553544564", "göz", false, new DateTime(2023, 12, 07));

            hastalar.Add(hasta1);
            hastalar.Add(hasta2);
            hastalar.Add(hasta3);
            hastalar.Add(hasta4);
            hastalar.Add(hasta5);
            dataGridView1.DataSource = hastalar;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = hasta.Id.ToString();
                txtAd.Text = hasta.AdSoyad;
                txtTelefon.Text = hasta.Telefon;
                cmbPolikinlik.Text = hasta.Poliklinik;
                cbSigorta.Checked = hasta.Sigorta;
                dateTimePicker1.Value = hasta.KayitTarih;


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hasta = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;

                DialogResult sonuc= MessageBox.Show(hasta.AdSoyad+"silinsin mi?", "kayıt silme",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if (sonuc == DialogResult.Yes)
                {
                    hastalar.Remove(hasta);
                }
            }

        }
    }
}
