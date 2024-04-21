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

namespace texteditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionLength > 0)
            {

                Font currentFont = richTextBox1.SelectionFont;


                if (currentFont == null)
                {
                    currentFont = richTextBox1.Font;
                }


                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;


                richTextBox1.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {

                Font currentFont = richTextBox1.SelectionFont;


                if (currentFont == null)
                {
                    currentFont = richTextBox1.Font;
                }


                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;


                richTextBox1.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionLength > 0)
            {

                Font currentFont = richTextBox1.SelectionFont;


                if (currentFont == null)
                {
                    currentFont = richTextBox1.Font;
                }


                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;


                richTextBox1.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string fileName = saveFileDialog.FileName;
                    string fileContent = "";
                    label1.Text = fileName;
                    if (fileContent != null)
                    {
                        CreateTextFile(fileName, fileContent);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string fileName = openFileDialog.FileName;
                    label1.Text = fileName;
                    try
                    {
                        string fileContent = File.ReadAllText(fileName);
                        richTextBox1.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading file: " + ex.Message);
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string fileName = saveFileDialog.FileName;
                    label1.Text = fileName;
                    try
                    {
                        richTextBox1.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                        MessageBox.Show("File saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message);
                    }
                }
            }
        }




        private void CreateTextFile(string fileName, string content)
        {
            try
            {

                File.WriteAllText(fileName, content);
                MessageBox.Show("File created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating file: " + ex.Message);
            }
        }
    }
}
