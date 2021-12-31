using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automatos.Classes;
using Automatos.FormsAutomato;
using Automatos.Forms;
using System.Collections;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Automatos
{
    public partial class Index : Form
    {
        #region Variáveis

        ComponentAutomato[] component = new ComponentAutomato[10];
        
        public bool statusCreate = false;
        public bool statusTransition = false;
        public bool statusDelete = false;
        public bool statusMove = false;
        public bool createItem = false;
        public bool createInicial = false;
        public bool createFinal = false;
        public bool renameState = false;
        public int countAutomato;
        public string nameProject;
        public Label labelStateDelete;
        public bool executeCompiler = false;
        public PictureBox imageStateDelete;
        public bool AnimarStates = false;
        public bool tecladoVirtualAutomato = false;
        public bool openTecladoVirtualAutomato = false;
        public Process processTeclado;
        public bool inAnimation = false;

        TypeProject _TypeProject;
        TypeAutomato _TypeAutomato;
        public TypeProject typeProject { get { return _TypeProject; } set { _TypeProject = value; } }
        public TypeAutomato typeAutomato { get { return _TypeAutomato; } set { _TypeAutomato = value; } }

        private Point stateLocation;
        private string nameState, pathTeclado = @"C:\Users\Bruno Purcinelli\Desktop\Testes\Testes\teclado.exe";
        private int NumberStateOrigem, NumberStateDestino;
        public int numberStateOrigem { get { return NumberStateOrigem; } set { NumberStateOrigem = value; } }
        public int numberStateDestino { get { return NumberStateDestino; } set { NumberStateDestino = value; } }
        private int projects = 0;
        private bool sizeTools = false;        

        #region OpenFile
        private string filePath = "";
        IOFileStreamAutomato fileAutomato = new IOFileStreamAutomato();
        #endregion

        #endregion

        #region Construct
        public Index()
        {
            InitializeComponent();
        }
        #endregion

        #region Inicia com Novo Projeto
        
        private void initProject()
        {            
            infoNewDocument();
        }
        #endregion 

        #region Menus Superiores
        #region Menu Arquivo
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoNewDocument();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Menu Exibir 
        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTop.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusButton.Visible = statusBarToolStripMenuItem.Checked;
        }
        private void MenuItemtecladoVirtual_Click(object sender, EventArgs e)
        {
            tecladoVirtualAutomato = MenuItemtecladoVirtual.Checked;
        }
        #endregion
        #region Editar
        private void menuItemDesfazer_Click(object sender, EventArgs e)
        {
            //component[tabControl.SelectedIndex].getFindCompiler(
        }
        #endregion
        #region Menu Executar
        private void executarAplicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            executeCompilerButton();
        }
        #endregion
        #region Menu Ferramentas
        private void menuItemEstado_Click(object sender, EventArgs e)
        {
            enableToolButtons(1);
        }

        private void menuItemTransação_Click(object sender, EventArgs e)
        {
            enableToolButtons(2);
        }

        private void menuItemDeletar_Click(object sender, EventArgs e)
        {
            enableToolButtons(3);
        }
        #endregion
        #region Menu Ajuda
        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }
        #endregion
        #endregion

        #region Barra Ferramentas
        private void menuNewItem_Click(object sender, EventArgs e)
        {
            infoNewDocument();
        }        

        private void toolOpenFile_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void toolExecute_Click(object sender, EventArgs e)
        {
            executeCompilerButton();
        }

        private void toolHelp_Click(object sender, EventArgs e)
        {

        }

        private void toolAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }
        #endregion

        #region Ferramentas do Arquivo
        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Autômato Files (*.atb)|*.at";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                MessageBox.Show(filePath);
            }
        }
        private void saveFile()
        {
            if (filePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "Autômato Files (*.atb)|*.at|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    MessageBox.Show(filePath);
                }
            }
        }
        private void saveAsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Autômato Files (*.atb)|*.at|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                MessageBox.Show(filePath);
            }
        }
        #endregion

        // TODO: Salvar arquivos

        #region Executar Compilador
        private void executeCompilerButton()
        {
            if (!executeCompiler)
            {
                if (projects > 0 &&
                    component[tabControl.SelectedIndex].getFindCompiler().getExistStateInicial() &&
                    component[tabControl.SelectedIndex].getFindCompiler().getExistStatesFinais() &&
                    component[tabControl.SelectedIndex].getFindCompiler().getExistStatesFinais() &&
                    component[tabControl.SelectedIndex].getFindCompiler().getExistTransition())
                {
                    if (component[tabControl.SelectedIndex].typeAutomatoDesenv == TypeAutomato.AFD)
                    {
                        lbDefinicoes.Items.Clear();
                        lbDefinicoes.Items.Add("Definição Formalmente");
                        lbStates.Items.Clear();
                        lbValueTrans.Items.Clear();
                        lbStatesTransition.Items.Clear();
                        txtValueEntrada.Text = "";
                        lblStatusCompiler.Text = "Inativo";

                        component[tabControl.SelectedIndex].getFindCompiler().initCompiler();
                        component[tabControl.SelectedIndex].getFindCompiler().enabledLabelTransition(false);
                        splitCompiler.Panel2Collapsed = false;
                        toolClose.Enabled = false;
                        menuItemDeletar.Enabled = false;
                        menuItemEstado.Enabled = false;
                        menuItemTransação.Enabled = false;
                        menuItemMover.Enabled = false;
                        toolAutomato.Enabled = false;
                        noToolsEnabled();
                        executeCompiler = true;
                    }
                    else
                    {
                        lbDefinicoes.Items.Clear();
                        lbDefinicoes.Items.Add("Definição Formalmente");
                        lbStates.Items.Clear();
                        lbValueTrans.Items.Clear();
                        lbStatesTransition.Items.Clear();
                        txtValueEntrada.Text = "";
                        lblStatusCompiler.Text = "Inativo";
                        lbTransAFND_AFD.Items.Clear();
                        lbDefinicoes.Items.Add("Transformação AFND-AFD");

                        component[tabControl.SelectedIndex].getFindCompiler().initCompiler();
                        component[tabControl.SelectedIndex].getFindCompiler().enabledLabelTransition(false);
                        splitCompiler.Panel2Collapsed = false;
                        toolClose.Enabled = false;
                        menuItemDeletar.Enabled = false;
                        menuItemEstado.Enabled = false;
                        menuItemTransação.Enabled = false;
                        menuItemMover.Enabled = false;
                        toolAutomato.Enabled = false;
                        noToolsEnabled();
                        executeCompiler = true;
                        component[tabControl.SelectedIndex].getFindCompiler().Transformation();
                    }
                }
                else
                    MessageBox.Show("É necessário criar os estados e as transições corretamente para executar o compilador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        #endregion
        
        #region Ferramentas
        private void tabControlTool_Click(object sender, EventArgs e)
        {
            if (sizeTools)
            {
                sizeTools = false;
                splitTool.SplitterDistance = 25;
                toolClose.Location = new Point(732, -2);
            }
            else
            {
                sizeTools = true;
                splitTool.SplitterDistance = 120;
                toolClose.Location = new Point(637, -2);
            }
        }

        private void toolState_Click(object sender, EventArgs e)
        {
            enableToolButtons(1);
        }

        private void toolTrans_Click(object sender, EventArgs e)
        {
            enableToolButtons(2);
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            enableToolButtons(3);
        }

        private void toolMove_Click(object sender, EventArgs e)
        {
            enableToolButtons(4);
        }
        #endregion

        #region Botoes ContextMenuStrip
        private void toolStripInicial_Click(object sender, EventArgs e)
        {
            if (component[tabControl.SelectedIndex].setStateInicial(stateLocation, nameState, numberStateOrigem))
            {
                txtStateIncial.Text = component[tabControl.SelectedIndex].getStateInicial();
                txtStateIncial.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                txtStateIncial.ForeColor = Color.Red;
            }
            else
            {
                txtStateIncial.Text = "Nenhum";
                txtStateIncial.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                txtStateIncial.ForeColor = Color.Black;
            }
        }

        private void toolStripFinal_Click(object sender, EventArgs e)
        {
            if (component[tabControl.SelectedIndex].setStateFinal(nameState, numberStateOrigem))
            {
                txtStateFinal.Text = component[tabControl.SelectedIndex].getFindCompiler().rescueStatesFinais();
                txtStateFinal.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                txtStateFinal.ForeColor = Color.Red;
            }
            else
            {
                txtStateFinal.Text = "Nenhum";
                txtStateFinal.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                txtStateFinal.ForeColor = Color.Black;
            }
        }

        private void toolStripTransicao_Click(object sender, EventArgs e)
        {
            //component[tabControl.SelectedIndex].diagrama();
        }

        private void ToolStripDeletar_Click(object sender, EventArgs e)
        {
            enableToolButtons(3);
            if (numberStateDestino == -1)
            {
                component[tabControl.SelectedIndex].removeState(imageStateDelete, labelStateDelete, numberStateOrigem);
                component[tabControl.SelectedIndex].getFindCompiler().deletaStateArray(nameState);

                if (component[tabControl.SelectedIndex].getFindCompiler().getExistStatesFinais())
                {
                    txtStateFinal.Text = component[tabControl.SelectedIndex].getFindCompiler().rescueStatesFinais();
                    txtStateFinal.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    txtStateFinal.ForeColor = Color.Red;
                }
                else
                {
                    txtStateFinal.Text = "Nenhum";
                    txtStateFinal.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    txtStateFinal.ForeColor = Color.Black;
                }
            }
            else
            {
                component[tabControl.SelectedIndex].getFindCompiler().deleteElementMatrix(numberStateOrigem, numberStateDestino);
            }
            enableToolButtons(0);
        }

        private void toolStripRename_Click(object sender, EventArgs e)
        {
            string nameStateAntigo = nameState;
            RenameState rename = new RenameState(this);
            rename.setNameStateAtual(nameState);
            rename.ShowDialog();

            if (!component[tabControl.SelectedIndex].getFindCompiler().existsNameState(nameState))
            {
                component[tabControl.SelectedIndex].getFindCompiler().renameStatesArray(nameState, nameStateAntigo);

                component[tabControl.SelectedIndex].getImageState(numberStateOrigem).setNameState(nameState);
                component[tabControl.SelectedIndex].getImageState(numberStateOrigem).setNameLabelState(nameState);
                component[tabControl.SelectedIndex].getFindCompiler().renameStateTransitions(numberStateOrigem, nameState);

                if (component[tabControl.SelectedIndex].getFindCompiler().getNumberStateInicial() == numberStateOrigem)
                {
                    component[tabControl.SelectedIndex].getFindCompiler().setNameStateInicial(nameState);
                    txtStateIncial.Text = nameState;
                }
                if (component[tabControl.SelectedIndex].getFindCompiler().getFindExistsStateFinal(numberStateOrigem))
                {
                    component[tabControl.SelectedIndex].getFindCompiler().setNameStateFinal(numberStateOrigem, nameState);

                    txtStateFinal.Text = component[tabControl.SelectedIndex].getFindCompiler().rescueStatesFinais();
                    txtStateFinal.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    txtStateFinal.ForeColor = Color.Red;
                }
            }
        }
        #endregion        

        #region Fechar Projetos
        private void toolStripButton2_Click(object sender, EventArgs e)
        {            
            if (tabControl.TabPages.Count > 0)
            {
                DialogResult result = MessageBox.Show("Deseja fechar o projeto sem salvar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    tabControl.TabPages.Remove(tabControl.SelectedTab);

                    projects--;

                    if (tabControl.TabPages.Count == 0)
                    {
                        projects = 0;
                        toolClose.Enabled = false;
                        toolAutomato.Enabled = false;                        
                        menuItemDeletar.Enabled = false;
                        menuItemEstado.Enabled = false;
                        menuItemTransação.Enabled = false;
                        menuItemMover.Enabled = false;

                        txtNroOpenProject.ForeColor = Color.Black;

                        txtStateAtual.Text = "Nenhum";
                        txtStateAtual.ForeColor = Color.Black;
                        txtStateAtual.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

                        txtStateIncial.Text = "Nenhum";
                        txtStateIncial.ForeColor = Color.Black;
                        txtStateAtual.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

                        txtStateFinal.Text = "Nenhum";
                        txtStateFinal.ForeColor = Color.Black;
                        txtStateAtual.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                        txtTypeAutomatoDesenv.Text = "Nenhum";
                        enableToolButtons(0);
                    }
                }
            }
            
            txtNroOpenProject.Text = "" + projects;            
        }
        #endregion
        
        #region Compilar
        private void compilar(int _typeCompiler)
        {
            /*------------------------------------------.
            | Índice:  {0} = Compilar Total             |
            |          {1} = Animar Total               |
            |          {2} = Animar Passo a Passo       |
            '------------------------------------------*/
            if (txtValueEntrada.Text != "")
            {
                if (_typeCompiler == 0)
                {
                    component[tabControl.SelectedIndex].getFindCompiler().compilar();
                }
                else if (_typeCompiler == 1)
                {
                    timerAnimation.Enabled = true;
                    timerAnimation.Interval = 2000;
                    timerAnimation.Enabled = false;
                }
                else if (_typeCompiler == 2)
                {                        
                    component[tabControl.SelectedIndex].getFindCompiler().animarCompilador();
                    inAnimation = true;
                }
            }
            else
                MessageBox.Show("A entrada está invalida. \nVerifique e compile novamente", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Ferramentas Compilador
        private void compiladorCompilar_Click(object sender, EventArgs e)
        {
            
            bool approve = false;

            component[tabControl.SelectedIndex].getFindCompiler().cancelaCompiler();
            if (!component[tabControl.SelectedIndex].getFindCompiler().validateTxtValues(txtValueEntrada.Text))
            {
                imageApprove.Image = Properties.Resources.erro;
                approve = false;
            }
            else
            {
                imageApprove.Image = Properties.Resources.ok;
                approve = true;
            }

            if (!approve)
            {
                MessageBox.Show("A entrada possui algum caracter que possa prejudicar o funcionamento do Automato.",
                                "Info",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2,
                                MessageBoxOptions.ServiceNotification);               
            }

            component[tabControl.SelectedIndex].getFindCompiler().anime = false;
            component[tabControl.SelectedIndex].getFindCompiler().compiler = true;

            btAnimarPassoAPasso.Enabled = false;
            btFechar.Enabled = false;

            compilar(0);
        }

        private void compiladorPassoPasso_Click(object sender, EventArgs e)
        {
            bool approve = false;

            if (!inAnimation)
            {
                if (!component[tabControl.SelectedIndex].getFindCompiler().validateTxtValues(txtValueEntrada.Text))
                {
                    imageApprove.Image = Properties.Resources.erro;
                    approve = false;
                }
                else
                {
                    imageApprove.Image = Properties.Resources.ok;
                    approve = true;
                }

                if (!approve)
                {
                    MessageBox.Show("A entrada possui algum caracter que possa prejudicar o funcionamento do Automato.",
                                    "Info",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.ServiceNotification);
                }
            }
            txtValueEntrada.Enabled = false;
            component[tabControl.SelectedIndex].getFindCompiler().anime = true;
            component[tabControl.SelectedIndex].getFindCompiler().compiler = false;
            
            btCompilar.Enabled = false;
            btFechar.Enabled = false;
            
            compilar(2);
        }       

        private void compiladorCancelar_Click(object sender, EventArgs e)
        {
            lbStates.Items.Clear();
            lbValueTrans.Items.Clear();
            lbStatesTransition.Items.Clear();
            component[tabControl.SelectedIndex].getFindCompiler().cancelaCompiler();

            txtValueEntrada.Enabled = true;
            btAnimarPassoAPasso.Enabled = true;
            btCompilar.Enabled = true;
            btFechar.Enabled = true;
            txtValueEntrada.Enabled = true;
        }

        private void compiladorFechar_Click(object sender, EventArgs e)
        {
            if (executeCompiler)
            {
                component[tabControl.SelectedIndex].getFindCompiler().enabledLabelTransition(true);
                component[tabControl.SelectedIndex].getFindCompiler().cancelaCompiler();
                splitCompiler.Panel2Collapsed = true;
                toolClose.Enabled = true;
                menuItemDeletar.Enabled = true;
                menuItemEstado.Enabled = true;
                menuItemTransação.Enabled = true;
                toolAutomato.Enabled = true;
                menuItemMover.Enabled = true;
                executeCompiler = false;

                if (tecladoVirtualAutomato && openTecladoVirtualAutomato)
                    processTeclado.CloseMainWindow();
            }
        }
        
        private void txtValueEntrada_Click(object sender, EventArgs e)
        {
            if (tecladoVirtualAutomato && !openTecladoVirtualAutomato)
            {
                processTeclado = Process.Start(pathTeclado);
                openTecladoVirtualAutomato = true;
            }
        }
        #endregion

        #region Path TecladoVirtual
        public string setPath { get { return pathTeclado; } }
        #endregion

        #region Form Closing
        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair da Aplicação sem salvar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region New Document
        private void infoNewDocument()
        {
            bool ret = false;

            if (projects > 0)
            {
                DialogResult result = MessageBox.Show("Deseja fechar o(s) Projeto(s)?",
                                                      "Info",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Question,
                                                      MessageBoxDefaultButton.Button2,
                                                      MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.OK)
                {
                    tabControl.TabPages.Clear();                    
                    projects = 0;
                    ret = true;
                }
                else
                {
                    ret = true;
                }
            }
            else
            {
                ret = true;
            }

            if (ret)
            {
                createNewDocument();
            }
        }
        private void createNewDocument()
        {            
            NewProject newProject = new NewProject(this);
            newProject.ShowDialog();

            if (createItem)
            {
                nameProject = nameProject + " " + Convert.ToInt32(projects);

                component[projects] = new ComponentAutomato(this);

                // Criar um indice com todos os projetos para poder gerar o compilador dentro do compiler do component

                tabControl.TabPages.Add(component[projects].getTabPage());
                projects++;
                txtNroOpenProject.Text = "" + projects;
                txtNroOpenProject.ForeColor = Color.Red;
            }

            if (projects > 0)
            {
                toolClose.Enabled = true;
                menuItemDeletar.Enabled = true;
                menuItemEstado.Enabled = true;
                menuItemTransação.Enabled = true;
                menuItemMover.Enabled = true;
            }
            else
            {
                toolClose.Enabled = false;
                menuItemDeletar.Enabled = false;
                menuItemEstado.Enabled = false;
                menuItemTransação.Enabled = false;
                menuItemMover.Enabled = false;
            }

        }
        #endregion

        #region Botões Automato
        public void enableToolButtons(int botao)
        {
            switch (botao)
            {
                case 0:
                    noToolsEnabled();
                    break;
                case 1:
                    if (!statusCreate)
                    {
                        noToolsEnabled();
                        statusCreate = true;
                        toolFerramenta.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                        toolFerramenta.ForeColor = Color.Green;
                        toolFerramenta.Text = "Estado"; 
                    }
                    else
                        noToolsEnabled();
                    break;
                case 2:
                    if (!statusTransition)
                    {
                        noToolsEnabled();
                        statusTransition = true;
                        toolFerramenta.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                        toolFerramenta.ForeColor = Color.Black;
                        toolFerramenta.Text = "Transição"; 
                    }
                    else
                        noToolsEnabled();
                    break;
                case 3:
                    if (!statusDelete)
                    {
                        noToolsEnabled();
                        statusDelete = true;
                        toolFerramenta.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                        toolFerramenta.ForeColor = Color.Red;
                        toolFerramenta.Text = "Apagar";
                    }
                    else
                        noToolsEnabled();
                    break;
                case 4:
                    if (!statusMove)
                    {                         
                        noToolsEnabled();
                        statusMove = true;
                        toolFerramenta.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                        toolFerramenta.ForeColor = Color.Red;
                        toolFerramenta.Text = "Mover";
                    }
                    else
                        noToolsEnabled();
                    break;
            }
        }
        private void noToolsEnabled()
        {
            statusCreate                = false;
            statusTransition            = false;
            statusDelete                = false;
            statusMove                  = false;
            toolFerramenta.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            toolFerramenta.ForeColor    = Color.Black;
            toolFerramenta.Text         = "Nenhuma";
        }
        #endregion

        #region Gets
        #region GetButton
        public int getButtonAutomato()
        {
            if (statusCreate)
                return 1;
            if (statusTransition)
                return 2;
            if (statusDelete)
                return 3;
            if (statusMove)
                return 4;

            return 0;
        }
        #endregion
        #endregion

        #region Sets
        public void setStateLocation(Point _automato)
        {
            stateLocation = _automato;
        }
        public void setNameState(string _NameState)
        {
            nameState = _NameState;
        }
        /*
        public void setNumberState(int _numberState)
        {
            numberState = _numberState;
        }
        */
        #endregion                

        #region Status Do compilador Click

        private void lblStatusCompiler_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblStatusCompiler.Text);
        }

        #endregion

        
    }
}
