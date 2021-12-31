using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Automatos.Classes
{
    class ComponentAutomato
    {
        #region Variáveis

        Index index;
        State state = new State();
        ImageAutomato[] imageAutomato = new ImageAutomato[50];

        private TabPage tabPageProject = new TabPage();
        private PictureBox pictureBox_ProjectAuto = new PictureBox();
        private Panel panelLinguagem = new Panel();
        private Bitmap bmp;
        public int X, Y;

        #endregion

        #region Contruct
        public ComponentAutomato(Index _index)
        {
            index = _index;
            Initialize();
        }
        #endregion

        #region Criação de Guias
        private void Initialize()
        {
            tabPageProject.Name = "tab" + index.nameProject;
            tabPageProject.BorderStyle = BorderStyle.Fixed3D;
            tabPageProject.BackColor = Color.White;
            tabPageProject.Text = index.nameProject;
            tabPageProject.Size = new Size(1000, 1000);
            tabPageProject.AutoScroll = true;

            containerTab();
            //compiler = new Compiler(this);
        }
        private void containerTab()
        {
            if (index.typeProject == TypeProject.Automato)
            {
                pAutomato(index.nameProject);
            }
            else if (index.typeProject == TypeProject.Gramatica)
            {
                pGramatica(index.nameProject);
            }
            else if (index.typeProject == TypeProject.Linguagem)
            {
                pLinguagem(index.nameProject);
            }
        }
        #endregion

        #region PictureBox Automato
        private void pAutomato(string name)
        {
            pictureBox_ProjectAuto.Name = "panel" + name;
            pictureBox_ProjectAuto.Size = new Size(1000, 1000);
            pictureBox_ProjectAuto.Dock = DockStyle.Fill;
            pictureBox_ProjectAuto.BackColor = Color.White;
            pictureBox_ProjectAuto.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_ProjectAuto.TabIndex = 1;
            bmp = new Bitmap(pictureBox_ProjectAuto.Width, pictureBox_ProjectAuto.Height);
            pictureBox_ProjectAuto.MouseMove += new MouseEventHandler(pictureBox_ProjectAuto_MouseMove);
            pictureBox_ProjectAuto.MouseDown += new MouseEventHandler(pictureBox_ProjectAuto_MouseDown);
            pictureBox_ProjectAuto.MouseUp += new MouseEventHandler(pictureBox_ProjectAuto_MouseUp);

            tabPageProject.Controls.Add(pictureBox_ProjectAuto);

            index.toolAutomato.Enabled = true;
        }

        //Painel Gramatica
        private void pGramatica(string name)
        {
            PanelGramatica gram = new PanelGramatica();
            gram.initializePanelGramatica(name);
            tabPageProject.Controls.Add(gram.getPanelGramatica());

            index.toolAutomato.Enabled = false;
        }

        //Painel Linguagem
        private void pLinguagem(string name)
        {
            panelLinguagem.Name = "panel" + name;
            panelLinguagem.Dock = DockStyle.Fill;
            panelLinguagem.BackColor = Color.White;
            panelLinguagem.BorderStyle = BorderStyle.Fixed3D;
            panelLinguagem.TabIndex = 1;

            tabPageProject.Controls.Add(panelLinguagem);
        }
        #endregion

        #region Eventos

        #region Mouse Move PictureBox Imagem
        void pictureBox_ProjectAuto_MouseMove(object sender, MouseEventArgs e)
        {            
            index.txtMouse.Text = e.Location.ToString();
        }
        #endregion

        #region Mouse Down/Up Picturebox Imagem

        void pictureBox_ProjectAuto_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;

            if (index.statusCreate)
            {
                int count;
                count = state.getcontador();
                if (count < 50)
                {
                    imageAutomato[count] = new ImageAutomato(this);

                    imageAutomato[count].createImageState(X, Y, state.createAutomato());

                    pictureBox_ProjectAuto.Controls.Add(imageAutomato[count].getLabelState());
                    pictureBox_ProjectAuto.Controls.Add(imageAutomato[count].getImageState());
                }
                else
                    MessageBox.Show("O limite de estados foi atingido, por favor verifique o autômato e remova os estados que não são utilizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void pictureBox_ProjectAuto_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        
        #endregion

        #endregion

        #region Gets
        //-----TabPage Referente ao tipo de Projeto-----\\
        public TabPage getTabPage()
        {
            return tabPageProject;
        }
        public TypeAutomato getIndexTypeAutomato()
        {
            return index.typeAutomato;
        }
        public Index getFindIndex()
        {
            return index;
        }
        /*
        private Compiler getFindCompiler()
        {
            return compiler;
        }
        */
        #endregion  
    }
}
