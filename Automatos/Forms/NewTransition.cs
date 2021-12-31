using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Automatos.Classes;
using System.Diagnostics;

namespace Automatos.Forms
{
    public partial class NewTransition : Form
    {
        #region Variáveis

        private bool createTransition = true;
        private string transText;
        private string transTextContinuous;
        private int countChar = 0;
        private ArrayList valueTrans = new ArrayList();
        private const string transicaoVazia = "Ɛ";
        
        #endregion

        #region Construtor
        public NewTransition()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btInsertTrans_Click(object sender, EventArgs e)
        {
            insertCaracter();
        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            bool enabled = false;
            if (countChar != 0 && lbTransitions.SelectedItem != null)
            {
                string item = lbTransitions.SelectedItem.ToString();

                for (int i = 0; i < valueTrans.Count; i++)
                {
                    if (valueTrans[i].ToString() == item)
                    {
                        if (valueTrans[i].ToString() == "ɛ")
                            enabled = true;

                        toolStripInserir.Enabled = enabled;
                        toolStripVazio.Enabled = enabled;

                        valueTrans.Remove(valueTrans[i]);
                        lbTransitions.Items.Remove(lbTransitions.SelectedItem);
                        countChar--;
                    }
                }
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            if (countChar != 0)
            {
                for (int i = 0; i < valueTrans.Count; i++)
                {
                    transText += valueTrans[i] + ", ";
                    transTextContinuous += valueTrans[i];
                }

                transText = transText.Remove(transText.Length - 2);
                transText = transText.ToLower();
                transTextContinuous = transTextContinuous.ToLower();

                Dispose();
            }
            else
            {
                DialogResult result = MessageBox.Show("Deseja sair sem criar a Transição?",
                                                      "Warning",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning,
                                                      MessageBoxDefaultButton.Button2,
                                                      MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.Yes)
                {
                    createTransition = false;
                    //process.CloseMainWindow();
                    Dispose();
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            createTransition = false;
            Dispose();
        }
        #endregion

        #region FormClosing
        private void NewTransition_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region Sets
        public void setInitialize(string transTextLocal, TypeAutomato _typeAutomato)
        {
            bool enabled = true;
            valueTrans.Clear();

            foreach (char value in transTextLocal.ToCharArray())
                valueTrans.Add(value);

            for (int i = 0; i < valueTrans.Count; i++)
            {
                lbTransitions.Items.Add(valueTrans[i]);
                countChar++;
                if (valueTrans[i].ToString() == "ɛ")
                    enabled = false;
            }

            if (_typeAutomato == TypeAutomato.AFND)
            {
                toolStripVazio.Enabled = true;
            }
            else
            {
                toolStripVazio.Enabled = false;
            }            

            createTransition = true;

            txtTransValue.Text = "";


            toolStripInserir.Enabled = enabled;
            toolStripVazio.Enabled = enabled;
        }
        #endregion
        
        #region Gets
        public string getTransText()
        {
            return transText;
        }
        public string getTransTextContinuous()
        {
            return transTextContinuous;
        }
        public ArrayList getValueTrans()
        {
            return valueTrans;
        }
        public bool getSituation()
        {
            return createTransition;
        }
        #endregion

        #region Valor Transição Vazia
        private void toolStripVazio_Click(object sender, EventArgs e)
        {
            txtTransValue.Text = transicaoVazia;
            insertCaracter();
            for (int i = 0; i < valueTrans.Count; i++)
            {
                transText += valueTrans[i] + ", ";
                transTextContinuous += valueTrans[i];
            }

            transText = transText.Remove(transText.Length - 2);
            transText = transText.ToLower();
            transTextContinuous = transTextContinuous.ToLower();

            Dispose();
        }
        #endregion       
                       
        #region Teclado 
        private void txtTransValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                insertCaracter();
            }
        }
        #endregion

        #region InsertCaracter
        private void insertCaracter()
        {
            string valueTransLocal;
            bool validateWrite = true;

            valueTransLocal = txtTransValue.Text;

            if (valueTransLocal != "")
            {
                for (int i = 0; i < valueTrans.Count; i++)
                {
                    if (valueTrans[i].ToString() == valueTransLocal)
                    {
                        MessageBox.Show("Este caracter já contém na transição", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        validateWrite = false;
                        break;
                    }
                }

                if (validateWrite)
                {
                    valueTransLocal = txtTransValue.Text;

                    if (valueTransLocal == "Ɛ")
                    {
                        valueTransLocal = valueTransLocal.ToUpper();
                    }
                    else
                    {
                        valueTransLocal = valueTransLocal.ToLower();
                    }
                    valueTrans.Add(valueTransLocal);
                    lbTransitions.Items.Add(valueTransLocal);
                    countChar++;

                    createTransition = true;
                }
                txtTransValue.Text = "";
            }
            else
                MessageBox.Show("Por favor, inserir caracteres diferentes de vazio", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
    }        
}
