using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Automatos.Forms;


namespace Automatos.Classes
{
    class ImageTransition
    {
        #region Variáveis

        private Panel Transicao = new Panel();
        private Label LabelTrans = new Label();

        public bool transLabel = false;
        private string nameTransicao;

        ComponentAutomato component;
        NewTransition trans;

        #endregion

        #region Construtor
        public ImageTransition(ComponentAutomato _component)
        {
            component = _component;
            if (component.getFindCompiler().getTypeNewTransition == TypeNewTransition.NewTransition)
            {
                if (component.getFindIndex().typeAutomato == TypeAutomato.AF)
                {
                    trans = new NewTransition();
                    trans.ShowDialog();
                    
                    if (component.typeAutomatoDesenv == TypeAutomato.AFD)
                    {
                        string value = trans.getTransTextContinuous();

                        if (value != null)
                        {
                            for (int i = 0; i < value.Length; i++)
                            {
                                if (value[i] == 'ɛ')
                                {
                                    DialogResult result = MessageBox.Show("Este Autômato se transfomará em um AFND, Deseja continuar?",
                                                                                "Info",
                                                                                MessageBoxButtons.OKCancel,
                                                                                MessageBoxIcon.Question);
                                    if (result == DialogResult.OK)
                                    {
                                        component.typeAutomatoDesenv = TypeAutomato.AFND;

                                        MessageBox.Show("Perfeito!\n" +
                                                        "Apartir de agora seu novo projeto se tornará um AFND.\n",
                                                        "Congratulations",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                                        component.getFindIndex().txtTypeAutomatoDesenv.Text = component.typeAutomatoDesenv.ToString();
                                    }
                                }
                            }
                        }
                    }

                    createImageTransition();
                    setTransBoolean(trans.getSituation());
                }
            }
            else if (component.getFindCompiler().getTypeNewTransition == TypeNewTransition.FindTransition)
            {
                if (component.getFindIndex().typeAutomato == TypeAutomato.AF)
                {
                    NewTransition transLocal = new NewTransition();//componentcomponent.typeAutomatoDesenv);
                    transLocal.setInitialize(component.getFindCompiler().getValueTransition(), component.typeAutomatoDesenv);
                    transLocal.ShowDialog();

                    setTransBoolean(transLocal.getSituation());

                    if (getStatusTrans())
                    {
                        setNameLabel(transLocal.getTransText(), transLocal.getTransTextContinuous());
                    }
                }
            }
        }
        #endregion

        #region Cria imagem
        public void createImageTransition()
        {
            setNameLabel(trans.getTransText(), trans.getTransTextContinuous());
            LabelTrans.ForeColor = Color.Black;
            LabelTrans.BackColor = Color.White;
            LabelTrans.TabIndex = 0;
            LabelTrans.AutoSize = true;
            LabelTrans.Font = new Font("Arial", 9);
        }
        #endregion
               
        #region Sets
        public void setNameLabel(string nameTrans, string nameTransContinuous)
        {
            LabelTrans.Text = nameTrans;
            LabelTrans.Name = nameTrans;
            nameTransicao = nameTransContinuous;
        }

        private void setTransBoolean(bool statusTrans)
        {
            transLabel = statusTrans;
        }
        #endregion

        #region Gets
        public bool getStatusTrans()
        {
            return transLabel;
        }
        public Label getLabelTrans()
        {
            return LabelTrans;
        }
        public string getNameTrans()
        {
            return nameTransicao;
        }
        public Panel getImageTrans()
        {
            return Transicao;
        }
        #endregion
    }
}
