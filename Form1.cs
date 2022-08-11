using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace PdfView
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files(*.pdf)|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName.ToString();
                textBox2.Text = path;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*SqlDataReader dados;
            clsConexao conec = new clsConexao();
            dados = conec.Consulta("SELECT num_NCM FROM tbl_TIPI");*/

            //Converte todo o PDF selecionado em texto.
            PDDocument doc = PDDocument.load(textBox2.Text);
            PDFTextStripper stripper = new PDFTextStripper();
            richTextBox2.Text = (stripper.getText(doc));

            //Define as strings(Texto completo, palavra de início, palavra de fim).
            string _completo = richTextBox2.Text;
            string _pos_ini = "ALÍQUOTA";
            string _pos_final = "PRODUTOS";
            string _texto = stringBetween(_completo, _pos_ini, _pos_final);
            textBox1.Text = _texto;
            //Cria uma substring a partir da string que criamos para pegar o intervalo de texto entre as palavras escolhidas.
            string stringBetween(string Source, string Start, string End)
            {
                string result = textBox1.Text;
                if (Source.Contains(Start) && Source.Contains(End))
                {
                    int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
                    int EndIndex = Source.IndexOf(End, StartIndex);
                    //Resultado da substring, Define o inicio e pega o intervalo até o fim.
                    result = Source.Substring(StartIndex, EndIndex - StartIndex);
                    return result;
                   
                }
                return result;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.Filter = "RTF File|*.rtf";
            if(saveFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void Inserir_Click(object sender, EventArgs e)
        {
            //int[] paginas = new int[] { 6,86 };
            PdfReader pdfReader = new PdfReader(textBox2.Text);
            Document document = new Document();

            if (pdfReader.NumberOfPages > 0)
            {
                //foreach (var item in paginas)
                for (int i = 6; i <= 86; i++)
                {
                    PdfCopy pdfCopy = new PdfCopy(document, new FileStream(Path.Combine(@"C:\Users\Due\Desktop\TIPI 01.08\Extraidos", string.Format("pagina_{0}.pdf", i)), FileMode.Create));
                    document.Open();
                    pdfCopy.AddPage(pdfCopy.GetImportedPage(pdfReader, i));
                }

                document.Close();
            }
            else
                return;




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


/* Código referente ao botão de converter, se o atual der problema tenta esse!
 * 
 * int _pos_ini = richTextBox2.Text.IndexOf("ALÍQUOTA"); //começa
 int _pos_final = richTextBox2.Text.IndexOf("PRODUTOS"); //termina         
 if(_pos_final > 0) && (_pos_final > 0)
 {
     string _buffer = richTextBox2.Text.Substring(_pos_final, richTextBox2.TextLength - _pos_final);
     richTextBox2.Text = _buffer;

 }*/