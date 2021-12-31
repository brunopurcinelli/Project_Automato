using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Automatos.Classes
{
    class IOFileStreamAutomato
    {
        #region Variáveis

        #endregion

        #region OpenFile
        public void openfile(string filePath)
        {
            string s = "";
            try
            {
                FileInfo fi = new FileInfo(@filePath);

                

                StreamReader sr = fi.OpenText();
                s = sr.ReadLine();
                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region SaveFile
        public void saveFile(string filePath)
        {
            //Escreve em txt
            //Int64 i;
            try
            {
                StreamWriter valor = new StreamWriter(@filePath, true, Encoding.ASCII);

                valor.Write("Estou Digitando;");
                valor.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("OK");
            }
        }
        #endregion
    }
}
