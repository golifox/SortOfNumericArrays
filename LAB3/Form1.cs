using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Form1 : Form
    {
        #region Функции при начальном запуске программы (настройка графиков и таблиц)
        public Form1()
        {
            InitializeComponent();
            //произведем программную настройку чартов для дальнейшего выведения графиков
            setupchart(chart1);
            setupchart(chart2);
            setupchart(chart3);
            setupchart(chart4);
            setupchart(chart5);
            setupdoublechart(chart6, "ВысЦ","ВыбР");
            setupdoublechart(chart7,"Быстр","ВыбЦ");
        }

        public void setupdoublechart(System.Windows.Forms.DataVisualization.Charting.Chart chrt, string fname, string sname) //функция для настройки графика сравнения (4 графика на одном)
        {
            chrt.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chrt.Series[0].BorderWidth = 3;
            chrt.Series[0].Color = Color.Red;
            chrt.Series[0].LegendText = "Сравнения "+fname;

            chrt.Series[1].LegendText = "Обмены "+fname;
            chrt.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chrt.Series[1].BorderWidth = 3;
            chrt.Series[1].Color = Color.Blue;


            chrt.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chrt.Series[2].BorderWidth = 3;
            chrt.Series[2].Color = Color.Green;
            chrt.Series[2].LegendText = "Сравнения " + sname;

            chrt.Series[3].LegendText = "Обмены " + sname;
            chrt.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chrt.Series[3].BorderWidth = 3;
            chrt.Series[3].Color = Color.Black;

        }
        public void setupchart(System.Windows.Forms.DataVisualization.Charting.Chart chrt) //функция настройки обычного графика (2 графика на одном)
        {
            chrt.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chrt.Series[0].BorderWidth = 3;
            chrt.Series[0].Color = Color.Red;
            chrt.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chrt.Series[1].BorderWidth = 3;
            chrt.Series[1].Color = Color.Blue;
            chrt.Series[0].LegendText = "Сравнения";
            chrt.Series[1].LegendText = "Обмены";
        }

        #endregion

        #region Функции для вывода данных в TextBox или DataGrid
        public void output_textBox(System.Windows.Forms.TextBox tb, int[] out_a, int n) //вывод массива в textBox
        {
            for (int i = 0; i < n; i++)
            { tb.Text += out_a[i] + " "; }
           tb.Text += Environment.NewLine;
        }
        public void output_dataGridView(int count, int sr, int obm, int vid_sort)//вывод в таблицу кол-ва сравнений и обменов
        {
            dataGridView1.Rows[count].Cells[vid_sort].Value = sr;
            dataGridView2.Rows[count].Cells[vid_sort].Value = obm;
        }
        #endregion

        #region Обработки кнопок старт и очистить
        private void Button1_Click(object sender, EventArgs e) //обработчик нажатия кнопки старт
        {

            button1.Enabled = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Размер";
            dataGridView1.Columns[1].HeaderText = "Выбор";
            dataGridView1.Columns[2].HeaderText = "Вставки";
            dataGridView1.Columns[3].HeaderText = "Пузырек";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].HeaderText = "Размер";
            dataGridView2.Columns[1].HeaderText = "Выбор";
            dataGridView2.Columns[2].HeaderText = "Вставки";
            dataGridView2.Columns[3].HeaderText = "Пузырек";
            ///////////////// 
            dataGridView3.ColumnCount = 5;
            dataGridView3.Columns[0].HeaderText = "Размер";
            dataGridView3.Columns[1].HeaderText = "ВыбР - сравнения";
            dataGridView3.Columns[2].HeaderText = "ВыбР - обмены";
            dataGridView3.Columns[3].HeaderText = "Быстр - сравнения";
            dataGridView3.Columns[4].HeaderText = "Быстр - обмены";
            dataGridView3.ColumnCount = 5;
            /////////////
            dataGridView1.ColumnCount = 4;
            dataGridView2.ColumnCount = 4;

            if (numericUpDown4.Value < numericUpDown5.Value)
            {
                errLabel.Text = "Минимальное значение не может быть больше максимального!";
                return;
            }
            int count = 0, n, sr = 0, obm = 0;
            ArraySort sort_select = new ArraySort();
            ArraySort sort_insert = new ArraySort();
            ArraySort sort_bubble = new ArraySort();

            ////////
            ArraySort rsort = new ArraySort();
            ArraySort qsort = new ArraySort();
            //////////

            for (n = Convert.ToInt32(numericUpDown1.Value); n <= Convert.ToInt32(numericUpDown2.Value); n += Convert.ToInt32(numericUpDown3.Value))
            {
                int[] base_a = new int[n];
                Random rand = new Random();
                for (int j = 0; j < n; j++)
                {
                    base_a[j] = rand.Next(Convert.ToInt32(numericUpDown5.Value),
                   Convert.ToInt32(numericUpDown4.Value));
                }

                textBox1.Text += "Исходный массив " + Environment.NewLine;
                output_textBox(textBox1, base_a, n);
                textBox2.Text += "Исходный массив " + Environment.NewLine;
                output_textBox(textBox2, base_a, n);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[count].Cells[0].Value = n;
                dataGridView2.Rows.Add();
                dataGridView2.Rows[count].Cells[0].Value = n;

                ////////
                dataGridView3.Rows.Add();
                dataGridView3.Rows[count].Cells[0].Value = n;
                //////////


                sort_select.a = (int[])base_a.Clone();
                sr = 0; obm = 0;
                sort_select.SelectSort(sort_select.a, ref sr, ref obm);
                textBox1.Text += "Сортировка выбором " + Environment.NewLine;
                output_textBox(textBox1, sort_select.a, n);
                output_dataGridView(count, sr, obm, 1);
                chart1.Series[0].Points.AddXY(n, sr);
                chart1.Series[1].Points.AddXY(n, obm);

                chart7.Series[2].Points.AddXY(n, sr);
                chart7.Series[3].Points.AddXY(n, obm);

                sort_insert.a = (int[])base_a.Clone();
                sr = 0; obm = 0;
                sort_insert.InsertSort(sort_insert.a, ref sr, ref obm);
                textBox1.Text += "Сортировка вставками " + Environment.NewLine;
                output_textBox(textBox1, sort_insert.a, n);
                output_dataGridView(count, sr, obm, 2);
                chart2.Series[0].Points.AddXY(n, sr);
                chart2.Series[1].Points.AddXY(n, obm);

                chart6.Series[0].Points.AddXY(n, sr);
                chart6.Series[1].Points.AddXY(n, obm);


                sort_bubble.a = (int[])base_a.Clone();
                sr = 0; obm = 0;
                sort_bubble.BubbleSort(sort_bubble.a, ref sr, ref obm);
                textBox1.Text += "Сортировка пузырьком " + Environment.NewLine;
                output_textBox(textBox1, sort_bubble.a, n);
                output_dataGridView(count, sr, obm, 3);
                chart3.Series[0].Points.AddXY(n, sr);
                chart3.Series[1].Points.AddXY(n, obm);

               

                //рекурсивная сортировка выбором
                rsort.a= (int[])base_a.Clone();
                sr = 0; obm = 0;
                rsort.RSort(rsort.a, ref sr, ref obm);
                textBox2.Text += "Рекурсивная сортировка выбором " + Environment.NewLine;
                output_textBox(textBox2, rsort.a, n);
                dataGridView3.Rows[count].Cells[1].Value = sr;
                dataGridView3.Rows[count].Cells[2].Value = obm;
                chart4.Series[0].Points.AddXY(n, sr);
                chart4.Series[1].Points.AddXY(n, obm);

                chart6.Series[2].Points.AddXY(n, sr);
                chart6.Series[3].Points.AddXY(n, obm);

                //быстрая сортировка
                qsort.a= (int[])base_a.Clone();
                sr = 0; obm = 0;
                qsort.RSort(qsort.a, ref sr, ref obm);
                textBox2.Text += "Быстрая сортировка " + Environment.NewLine;
                output_textBox(textBox2, qsort.a, n);
                dataGridView3.Rows[count].Cells[3].Value = sr;
                dataGridView3.Rows[count].Cells[4].Value = obm;
                chart5.Series[0].Points.AddXY(n, sr);
                chart5.Series[1].Points.AddXY(n, obm);

                chart7.Series[0].Points.AddXY(n, sr);
                chart7.Series[1].Points.AddXY(n, obm);

                count++;
                textBox1.Text += "=====================================================================================================================================" + Environment.NewLine; 
                textBox2.Text += "=====================================================================================================================================" + Environment.NewLine;
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Enabled = true;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart3.Series[1].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart4.Series[1].Points.Clear();
            chart5.Series[0].Points.Clear();
            chart5.Series[1].Points.Clear();
            chart6.Series[0].Points.Clear();
            chart6.Series[1].Points.Clear();
            chart6.Series[2].Points.Clear();
            chart6.Series[3].Points.Clear();
            chart7.Series[0].Points.Clear();
            chart7.Series[1].Points.Clear();
            chart7.Series[2].Points.Clear();
            chart7.Series[3].Points.Clear();
        }

        #endregion

        #region Функции сохранения графиков в файл 
        private void savegraph(System.Windows.Forms.DataVisualization.Charting.Chart chrt, string FileName)//функция для сохранения графика в файл агрументы:график чарт, имя файла, предложенное для сохранения
        {
            using (SaveFileDialog saveGr = new SaveFileDialog())
            {
                saveGr.Title = "Сохранить график как ...";
                saveGr.Filter = "*.jpg|*.jpg";
                saveGr.AddExtension = true;
                saveGr.FileName = FileName;
                if (saveGr.ShowDialog() ==
                System.Windows.Forms.DialogResult.OK)
                {
                    chrt.SaveImage(saveGr.FileName,
                    System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }

        private void СохранитьВсеГрафикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            СохранитьГрафикСортировкиToolStripMenuItem_Click(sender, e);
            СохранитьГрафикСортировкиToolStripMenuItem1_Click(sender, e);
            СохранитьГрафикСортировкиПузырькомToolStripMenuItem_Click(sender, e);
        }

        private void СохранитьГрафикСортировкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegraph(chart2, "Insert");
        }

        private void СохранитьГрафикСортировкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            savegraph(chart1, "Select");
        }

        private void СохранитьГрафикСортировкиПузырькомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegraph(chart3, "Bubble");
        }

        private void ЦикламиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
            tabControl1.Visible = true;
        }

        private void РекурсивнымиФункциямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = true;
            tabControl1.Visible = false;
        }

        private void СохранитьГрафикРекурсСортВыборомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegraph(chart4, "Select(recurs)");
        }

        private void СохранитьГрафикБыстройСортировкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegraph(chart5, "QuickSort");
        }

        private void СохранитьГрафикСравненийВсЦВыбРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegraph(chart6, "Insert(cycles)-Select(recurs)");
        }

        private void СохранитьГрафикСравненийБыстрВыбЦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savegraph(chart7, "QuickSort-Select(cycles)");
        }

        private void СохранитьВсеГрафикиличноеЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            СохранитьГрафикРекурсСортВыборомToolStripMenuItem_Click(sender,  e);
            СохранитьГрафикБыстройСортировкиToolStripMenuItem_Click(sender,  e);
            СохранитьГрафикСравненийВсЦВыбРToolStripMenuItem_Click(sender, e);
            СохранитьГрафикСравненийБыстрВыбЦToolStripMenuItem_Click(sender, e);
        }

        private void СохранитьВсеГрафикиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            СохранитьВсеГрафикиToolStripMenuItem_Click(sender, e);
            СохранитьВсеГрафикиличноеЗаданиеToolStripMenuItem_Click(sender, e);
        }
        #endregion

        #region Функция обработчиков кнопок Выход и справка
        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help help = new help();
            help.ShowDialog();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы? ", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}
