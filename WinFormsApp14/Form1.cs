using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace WinFormsApp14
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private List<int> generatedNumbers = new List<int>(); // สร้าง List เพื่อเก็บตัวเลขที่สุ่มได้

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //button generate
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
            GenerateRandomNumber();

        }
        // Button reset
        private void button2_Click(object sender, EventArgs e)
        {
            generatedNumbers.Clear();
            richTextBox1.Clear();
            // รีเซ็ตค่าใน DataGridView
            dataGridView1.Rows.Clear();

        }
        private void GenerateRandomNumber()
        {

            richTextBox1.Clear();
            // สุ่มตัวเลข 0-60000
            int randomNumber = random.Next(0, 10);

            // เช็คว่าตัวเลขที่สุ่มมีอยู่ใน List แล้วหรือไม่
            if (generatedNumbers.Contains(randomNumber))
            {
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.AppendText("NG ");
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.AppendText(randomNumber.ToString() + " ");
                generatedNumbers.Add(randomNumber);
            }
            else
            {
                richTextBox1.SelectionColor = Color.Green;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.AppendText(randomNumber.ToString() + " ");
                // เพิ่มตัวเลขที่สุ่มได้ลงใน List
                generatedNumbers.Add(randomNumber);
            }
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {

            // ลบแถวทั้งหมดใน DataGridView
            dataGridView1.Rows.Clear();

            // นับจำนวนตัวเลขทั้งหมดใน List
            int count = generatedNumbers.Count;

           

            // เพิ่มแถวใน DataGridView สำหรับตัวเลขที่ต้องแสดง
            for (int i = 0; i < generatedNumbers.Count; i++)
            {


                //สำหรับโชวค่า NG เมื่อมีตัวซ้ำกัน(ยกเว้นตัวแรก จะไม่ขึ้น NG ) เช่น 1 2 3 1(NG)
                int currentNumber = generatedNumbers[i];
                bool isDuplicate = generatedNumbers.IndexOf(currentNumber) < i; //ใช้ IndexOf เพื่อหาตำแหน่งแรกที่ currentNumber ปรากฏใน generatedNumbers. ถ้าตำแหน่งที่พบน้อยกว่า i, นั่นหมายความว่า currentNumber มีค่าที่ซ้ำกับตัวเลขที่อยู่ในรอบแรกของลูป, และ isDuplicate จะถูกตั้งค่าเป็น true.

                // เพิ่มแถวใน DataGridView
                dataGridView1.Rows.Add(i, currentNumber, isDuplicate ? "NG" : "");

                /* สำหรับโชวค่า NG เมื่อมีตัวซ้ำกัน เช่น 1(NG) 2 3 1(NG)
                int currentNumber = generatedNumbers[i];
                int ngCount = generatedNumbers.FindAll(n => n == currentNumber).Count;
                // เพิ่มแถวใน DataGridView
                dataGridView1.Rows.Add(i, currentNumber, ngCount > 1 ? "NG" : "");
                */
            }
            // ตั้งค่าเลื่อน ScrollBar ไปยังค่าล่าสุด
            if (dataGridView1.Rows.Count > 0)
            {
                int lastIndex = dataGridView1.Rows.Count - 1;
                dataGridView1.FirstDisplayedScrollingRowIndex = lastIndex;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}