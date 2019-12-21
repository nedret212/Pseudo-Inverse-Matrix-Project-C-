using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        double[,] matris = new double[5, 5];
        double[,] transpoz = new double[5, 5];
        double[,] AxAT = new double[5, 5];
        double[,] AxATters = new double[5, 5];
        double[,] pseudo_inverse = new double[5, 5];

        int toplama_sayisi=0;
        int carpma_sayisi = 0;

        double[] tekil_dizi = new double[25];
        int tekil = 0;

        int satir = 0;
        int sutun = 0;
        int kucuk = 0;
        int i, j, k, l;

        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            satir=Convert.ToInt32(textBox1.Text);
            sutun = Convert.ToInt32(textBox2.Text);
            dataGridView1.RowCount = satir;
            dataGridView1.ColumnCount = sutun;

            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 30;
            }
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void axat1()
        {
            double satir_toplam = 0;
            //matris satirinin transpozunun satirindan az olma durumu 
            if (satir < sutun)
            {
                kucuk = satir;
                for (i = 0; i < satir; i++)
                {
                    for (j = 0; j < satir; j++)
                    {
                        for (k = 0; k < sutun; k++)
                        {
                            satir_toplam += matris[i, k] * transpoz[k, j];
                            carpma_sayisi++;
                            toplama_sayisi++;
                        }
                        tekil_dizi[tekil] = satir_toplam;
                        tekil++;
                        satir_toplam = 0;
                    }
                }
                //tekil diziden AxAT dizisine aktarma
                tekil = 0;
                for (i = 0; i < satir; i++)
                {
                    for (j = 0; j < satir; j++)
                    {
                        AxAT[i, j] = tekil_dizi[tekil];
                        tekil++;
                    }
                }

                dataGridView3.RowCount = satir ;
                dataGridView3.ColumnCount = satir;

                for (i = 0; i < satir; i++)
                    for (j = 0; j < satir; j++)
                       dataGridView3.Rows[i].Cells[j].Value = AxAT[i, j];
                    
            }
            //matris satirinin transpozunun satirindan cok olma durumu 
            else if (sutun <= satir)
            {
                kucuk = sutun;
                for (i = 0; i < sutun; i++)
                {
                    for (j = 0; j < sutun; j++)
                    {
                        for (k = 0; k < satir; k++)
                        {
                            satir_toplam += transpoz[i, k] * matris[k, j];
                            toplama_sayisi++;
                            carpma_sayisi++;
                        }
                        tekil_dizi[tekil] = satir_toplam;
                        tekil++;
                        satir_toplam = 0;
                    }
                }
                //tekil diziden axat dizisine aktarma
                tekil = 0;
                for (i=0;i<sutun;i++)
                {
                    for(j=0;j<sutun;j++)
                    {
                        AxAT[i, j] = tekil_dizi[tekil];
                        tekil++;
                    }
                }
                dataGridView3.RowCount = sutun;
                dataGridView3.ColumnCount = sutun;
                for (i = 0; i < sutun; i++)
                {
                    for (j = 0; j < sutun; j++)
                    {
                        dataGridView3.Rows[i].Cells[j].Value = AxAT[i, j];
                    }
                }
            }
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            toplama_sayisi = 0;
            carpma_sayisi = 0;

            Random rastgele = new Random();
            int sayi1 = rastgele.Next(1,5);
            int sayi2 = rastgele.Next(1, 5);

            if (sayi2 == sayi1)
                sayi2 = rastgele.Next(1, 5);

            satir = sayi1;
            sutun = sayi2;
            double deger;

            dataGridView1.RowCount = satir;
            dataGridView1.ColumnCount = sutun;

            for (i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].Width = 30;

            for(i=0;i<satir;i++)
            {
                for(j=0;j<sutun;j++)
                {
                    deger = rastgele.Next(1, 9);
                    matris[i, j] = deger;
                }
            }

            for (i = 0; i < satir; i++)
                for (j = 0; j < sutun; j++)
                    dataGridView1.Rows[i].Cells[j].Value = matris[i, j];

            
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void axaTdet1()
        {
            double[,] axatDet = new double[kucuk, kucuk];
            double carpim = 1;
            double carpim2 = 1;
            double[] tekil = new double[(kucuk - 1) * (kucuk - 1)];
            int tsayac = 0;
            double determinant_sonuc = 0;

            if (kucuk == 2)
            {
                double[,] ek_matris2 = new double[2, 2];
                double determinant2;
                carpim = AxAT[0, 0] * AxAT[1, 1];
                carpim2 = AxAT[0, 1] * AxAT[1, 0];

                carpma_sayisi += 4;
                toplama_sayisi+=2;

                determinant2 = carpim - carpim2;

                ek_matris2[0, 0] = AxAT[1, 1];
                ek_matris2[1, 1] = AxAT[0, 0];
                ek_matris2[0, 1] = AxAT[0, 1] * -1;
                ek_matris2[1, 0] = AxAT[1, 0] * -1;

                for(i=0;i<kucuk;i++)
                {
                    for(j=0;j<kucuk;j++)
                    {
                        AxATters[i, j] = (1 / determinant2) * ek_matris2[i, j];
                        carpma_sayisi += 2;
                    }
                }
            }
            else //olusan matris 2x2 degilse
            {
                if (kucuk == 1)
                {
                    axatDet[0, 0] = AxAT[0, 0];
                }

                else if (kucuk == 3)//3x3 kare matris determinantı
                {
                    for (i = 0; i < kucuk; i++)
                    {
                        for (j = 0; j < kucuk; j++)
                        {
                            if (i == j)
                            {
                                for (k = 0; k < kucuk; k++)
                                {
                                    for (l = 0; l < kucuk; l++)
                                    {
                                        if (k != i && l != j)
                                        {
                                            if (k == l)
                                            {
                                                carpim *= AxAT[k, l];
                                                carpma_sayisi++;
                                            }

                                            else if (k != l)
                                            {
                                                carpim2 *= AxAT[k, l];
                                                carpma_sayisi++;
                                            }
                                        }
                                    }
                                }
                                axatDet[i, j] = carpim - carpim2;
                                carpim = 1;
                                carpim2 = 1;

                                toplama_sayisi++;
                            }
                            else if (i != j)
                            {
                                for (k = 0; k < kucuk; k++)
                                {
                                    for (l = 0; l < kucuk; l++)
                                    {
                                        if (k != i && l != j)
                                        {
                                            tekil[tsayac] = AxAT[k, l];
                                            tsayac++;
                                        }
                                    }
                                }
                                carpim = tekil[0] * tekil[3];
                                carpim2 = tekil[1] * tekil[2];
                                axatDet[i, j] = carpim - carpim2;
                                carpim = 1;
                                carpim2 = 1;

                                carpma_sayisi += 2;
                                toplama_sayisi++;
                            }
                            tsayac = 0;
                        }
                    }
                }
                else if (kucuk == 4)//4x4 kare matris determinant alma islemi
                {
                    double[] tekil_matris = new double[(kucuk - 1) * (kucuk - 1)];
                    int t_sayac = 0;

                    for (i = 0; i < kucuk; i++)
                    {
                        for (j = 0; j < kucuk; j++)
                        {
                            for (k = 0; k < kucuk; k++)
                            {
                                for (l = 0; l < kucuk; l++)
                                {
                                    if (k != i && l != j)
                                    {
                                        tekil_matris[t_sayac] = AxAT[k, l];
                                        t_sayac++;
                                    }
                                }
                            }
                            carpim = (tekil_matris[0] * tekil_matris[4] * tekil_matris[8]) +
                                     (tekil_matris[3] * tekil_matris[7] * tekil_matris[2]) +
                                     (tekil_matris[6] * tekil_matris[1] * tekil_matris[5]);

                            carpim2 = (tekil_matris[2] * tekil_matris[4] * tekil_matris[6]) +
                                     (tekil_matris[5] * tekil_matris[7] * tekil_matris[0]) +
                                     (tekil_matris[8] * tekil_matris[1] * tekil_matris[3]);

                            axatDet[i, j] = carpim - carpim2;
                            carpim = 1;
                            carpim2 = 1;
                            t_sayac = 0;

                            carpma_sayisi += 12;
                            toplama_sayisi++;
                        }
                    }
                }
                dataGridView6.RowCount = kucuk;
                dataGridView6.ColumnCount = kucuk;

                for (i = 0; i < kucuk; i++)
                    for (j = 0; j < kucuk; j++)
                        dataGridView6.Rows[i].Cells[j].Value = axatDet[i, j];

                for (i = 0; i < dataGridView6.Columns.Count; i++)
                    dataGridView6.Columns[i].Width = 30;

                //kofaktor islemleri
                double[,] kofaktor = new double[kucuk, kucuk];

                for (i = 0; i < kucuk; i++)
                {
                    for (j = 0; j < kucuk; j++)
                    {
                        if ((i + j) % 2 == 0)
                            kofaktor[i, j] = 1;

                        else if ((i + j) % 2 == 1)
                            kofaktor[i, j] = -1;
                    }
                }
                //kofaktor matrisini datagridview'e yazdir
                dataGridView7.RowCount = kucuk;
                dataGridView7.ColumnCount = kucuk;

                for (i = 0; i < kucuk; i++)
                    for (j = 0; j < kucuk; j++)
                        dataGridView7.Rows[i].Cells[j].Value = kofaktor[i, j];

                for (i = 0; i < dataGridView7.Columns.Count; i++)
                    dataGridView7.Columns[i].Width = 30;

                //ek matris olusturma
                double[,] ek_matris = new double[kucuk, kucuk];

                //kofaktorun transpozunu ek matrise aktar
                for (i = 0; i < kucuk; i++)
                {
                    for (j = 0; j < kucuk; j++)
                    {
                        kofaktor[i, j] = kofaktor[i, j] * axatDet[i, j];
                        ek_matris[j, i] = kofaktor[i, j];
                    }
                }
                
                // det * kofaktor matrisini datagridview'e yazdir
                dataGridView9.RowCount = kucuk;
                dataGridView9.ColumnCount = kucuk;

                for (i = 0; i < kucuk; i++)
                    for (j = 0; j < kucuk; j++)
                        dataGridView9.Rows[i].Cells[j].Value = kofaktor[i, j];

                for (i = 0; i < dataGridView9.Columns.Count; i++)
                    dataGridView9.Columns[i].Width = 30;

                //Ek matrisi datagridview'e yazdir
                dataGridView8.RowCount = kucuk;
                dataGridView8.ColumnCount = kucuk;

                for (i = 0; i < kucuk; i++)
                    for (j = 0; j < kucuk; j++)
                        dataGridView8.Rows[i].Cells[j].Value = ek_matris[i, j];

                for (i = 0; i < dataGridView8.Columns.Count; i++)
                    dataGridView8.Columns[i].Width = 30;


                for (i = 0; i < kucuk; i++)
                {
                    determinant_sonuc += AxAT[0, i] * kofaktor[0, i];
                    carpma_sayisi++;
                    toplama_sayisi++;
                }

                string a = "";
                a = determinant_sonuc.ToString();
                label7.Text = a;

                for (i = 0; i < kucuk; i++)
                {
                    for (j = 0; j < kucuk; j++)
                    {
                        AxATters[i, j] = (1 / determinant_sonuc) * ek_matris[i, j];
                        carpma_sayisi++;
                    }
                }
            }
            dataGridView4.RowCount = kucuk;
            dataGridView4.ColumnCount = kucuk;
            
            for (i = 0; i < kucuk; i++)
                for (j = 0; j < kucuk; j++)
                    dataGridView4.Rows[i].Cells[j].Value = AxATters[i, j];
               
            for (i = 0; i < dataGridView4.Columns.Count; i++)
                dataGridView4.Columns[i].Width = 50;
            
        }
        public void axatTers1()
        {
            axaTdet1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            toplama_sayisi = 0;
            carpma_sayisi = 0;
            //gridviewi matrise aktarır
            for (i = 0; i < satir; i++)
                for (j = 0; j < sutun; j++)
                    matris[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                
            //transpoz alır
            for (i=0;i<satir;i++)
            {
                for(j=0;j<sutun;j++)
                {
                    transpoz[j, i] = matris[i, j];
                }
            }
            dataGridView2.RowCount = sutun;
            dataGridView2.ColumnCount = satir;

            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].Width = 30;
            }

            //transpozu yazdir
            for (i = 0; i < sutun; i++)
            {
                for (j = 0; j < satir; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = transpoz[i, j];
                }
            }

            axat1(); // A * ATranspoz fonksiyonunu cagirir
            for (i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView3.Columns[i].Width = 30;
            }
            axatTers1();

            // At x (AxAT)tersi islemleri,  SOZDE TERS ALMA ISLEMI___________________________________________
            double pseudo_toplam = 0;

            if (sutun > kucuk) // orn: 2x4 * 2x2
            {   
                //transpoz x ters kare matris
                for(i=0;i<sutun;i++)
                {
                    for(j=0;j<kucuk;j++)
                    {
                       for(k=0;k<kucuk;k++)
                        {
                            pseudo_toplam += transpoz[i, k] * AxATters[k, j];
                            toplama_sayisi++;
                            carpma_sayisi++;
                        }
                        pseudo_inverse[i, j] = pseudo_toplam;
                        pseudo_toplam = 0;
                    }
                }

                //datagridview de yazdir
                dataGridView5.RowCount = sutun;
                dataGridView5.ColumnCount = satir;

                for (i = 0; i < dataGridView5.Columns.Count; i++)
                    dataGridView5.Columns[i].Width = 50;

                for (i=0;i<sutun;i++)
                    for (j = 0; j < satir; j++)
                        dataGridView5.Rows[i].Cells[j].Value = pseudo_inverse[i, j];

            }

            else if(sutun==kucuk) // orn: 4x3 * 3x3 
            { 
                if(satir>kucuk)
                {   //ters kare matris  x transpoz
                    for(i=0;i<satir;i++)
                    {
                        for(j=0;j<kucuk;j++)
                        {
                            for(k=0;k<kucuk;k++)
                            {
                                pseudo_toplam += AxATters[j, k] * transpoz[k, i];
                                toplama_sayisi++;
                                carpma_sayisi++;
                            }
                            pseudo_inverse[j, i] = pseudo_toplam;
                            pseudo_toplam = 0;
                        }
                    }

                    //datagridview de yazdir
                    dataGridView5.RowCount = sutun;
                    dataGridView5.ColumnCount = satir;

                    for (i = 0; i < dataGridView5.Columns.Count; i++)
                        dataGridView5.Columns[i].Width = 50;

                    for (i = 0; i < sutun; i++)
                        for (j = 0; j < satir; j++)
                            dataGridView5.Rows[i].Cells[j].Value = pseudo_inverse[i, j];

                    
                }
            }
            string toplama = toplama_sayisi.ToString();
            label19.Text = toplama;
            string carpma = carpma_sayisi.ToString();
            label20.Text = carpma;
        }
    }
}
