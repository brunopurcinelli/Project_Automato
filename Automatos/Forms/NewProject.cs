using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automatos.FormsAutomato
{
    public partial class NewProject : Form
    {
        #region Variaveis

        Index index;
        private TypeProject projectType = new TypeProject();
        private TypeAutomato automatoType = new TypeAutomato();
        private string nameProject;

        #endregion

        #region Contruct
        public NewProject(Index _index)
        {
            InitializeComponent();
            index = _index;
            treeIniciar.ExpandAll();
        }
        #endregion

        #region Botões NewProject Ok/Cancel

        private void btOk_Click(object sender, EventArgs e)
        {
            closeForm(1);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            closeForm();   
        }
        
        #endregion

        #region Form Closing
        private void NewProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region Selecionar Nós da Tree
        private void treeIniciar_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectTypePanel(e);
        }
        private void treeIniciar_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectTypePanel(e);
            closeForm(1);
        }

        private void selectTypePanel(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "NodeAllTemplates")
            {
                txtInfo.Text = "Selecione um Modelo...";
                infoImage.Image = null;
            }
            else
            {
                projectType = TypeProject.None;
                automatoType = TypeAutomato.None;
                NameProject projName = new NameProject();

                if (e.Node.Name == "NodeAF")
                {
                    txtInfo.Text = "Criar um Autômato Finito Deterministico";
                    infoImage.Image = Properties.Resources.AFD1;

                    projectType = TypeProject.Automato;
                    automatoType = TypeAutomato.AF;
                }
                else if (e.Node.Name == "NodeAP")
                {
                    txtInfo.Text = "Criar um Autômato de Pilha";
                    infoImage.Image = Properties.Resources.pilha;

                    projectType = TypeProject.Automato;
                    automatoType = TypeAutomato.AP;
                }

                nameProject = projName.setTypeProject(projectType, automatoType);
                projectName.Text = nameProject;
            }
        }
        
        #endregion

        #region CloseForm
        private void closeForm(int _botao = 0)
        {
            if (_botao == 1)
            {
                if (projectName.Text != "")
                {
                    index.typeProject = projectType;
                    index.typeAutomato = automatoType;                    
                    index.nameProject = projectName.Text;
                    index.createItem = true;

                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Digite o nome do Projeto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                index.typeProject = TypeProject.None;
                index.typeAutomato = TypeAutomato.None;
                index.nameProject = "";
                index.createItem = false;

                this.Dispose();
            }
            
        }
        #endregion
    }
}
