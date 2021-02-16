using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PointCloudToOBJ
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			textBox1.Text = "0.02";
		}


		private void button1_Click(object sender, EventArgs e) //Копка открытия файла облака точек
		{	

			OFD_OpenPC.Filter = "XYZ RGB files (*.txt)|*.txt";
			if (OFD_OpenPC.ShowDialog() == DialogResult.Cancel) return;
		}

		private void OFD_OpenPC_FileOk(object sender, CancelEventArgs e) //Операция открытия файла облака точек
		{

		}

		private void button2_Click(object sender, EventArgs e) //Кнопка выбора место сохранения файла
		{
			SFD_SaveOBJ.Filter = "Wavefront Technologies OBJ file (*.obj)|*.obj";
			
			if (SFD_SaveOBJ.ShowDialog() == DialogResult.Cancel) return;
			else if (SFD_SaveOBJ.CheckPathExists == true) Path.ChangeExtension(SFD_SaveOBJ.FileName, ".obj");
		}

		private void SFD_SaveOBJ_FileOk(object sender, CancelEventArgs e) //Операция сохранения файла OBJ
		{

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e) //Вариант в кубы
		{

		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e) //Вариант в октаэдры
		{

		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e) //Вариант в тетраэддры
		{

		}

		private void button4_Click(object sender, EventArgs e) //Кнопка запуска предварительного анализа - какой вес будет у файла
		{

		}

		private void button3_Click(object sender, EventArgs e) //Главная кнопка запуска процесса
		{
			if (radioButton1.Checked == true) Actions.TypeOfTranslation = 1;
			else if (radioButton2.Checked == true) Actions.TypeOfTranslation = 2;
			else if (radioButton3.Checked == true) Actions.TypeOfTranslation = 3;

			Actions.ConvertToOBJ(OFD_OpenPC.FileName, SFD_SaveOBJ.FileName, Convert.ToDouble(textBox1.Text));
		}

		private void textBox1_TextChanged(object sender, EventArgs e) //Поле точности
		{

		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e) //Меню выбора языка
		{

		}

		private void russianToolStripMenuItem_Click(object sender, EventArgs e) //опция включения русского языка
		{
			groupBox1.Text = "Выбор файла и места сохранения";
			groupBox2.Text = "Панель действий";
			groupBox3.Text = "Варианты ковертации точек";
			radioButton1.Text = "Преобразование в кубы";
			radioButton2.Text = "Преобразование в октаэдры";
			radioButton3.Text = "Преобразование в тетраэдры";
			label1.Text = "Выберите файл для конвертации";
			label2.Text = "Выберите место сохранения";
			label3.Text = "Запустить процесс";
			label5.Text = "Размер частиц Mesh (м):";
			button1.Text = "Открыть";
			button1.Text = "Сохранить";
			button1.Text = "Старт";
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e) //Опция включения анг языка
		{
			groupBox1.Text = "Select input file and save path";
			groupBox2.Text = "Options panel";
			groupBox3.Text = "Variants of poins transformation";
			radioButton1.Text = "Transform to cube";
			radioButton2.Text = "Transform to octahedron";
			radioButton3.Text = "Transform to tetrahedron";
			label1.Text = "Select input point cloud";
			label2.Text = "Select saving file's name";
			label3.Text = "Start a process";
			label5.Text = "Size of mesh values (m):";
			button1.Text = "Open";
			button2.Text = "Save";
			button3.Text = "Start";
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}
	}
}