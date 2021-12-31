using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using Automatos.Forms;

namespace Automatos.Classes
{
    class ComponentAutomato
    {
        #region Variáveis

        Index index;
        State state = new State();
        ImageAutomato[] imageAutomato = new ImageAutomato[50];
        CompilerAutomato compiler;

        private TabPage tabPageProject = new TabPage();
        private PictureBox pictureBox_ProjectAuto = new PictureBox();
        private Panel panelLinguagem = new Panel();
        private Panel panelAutomato = new Panel();
        private bool primaryTrans = false;
        private bool secundaryTrans = false;
        private List<PointF> obj = new List<PointF>();
        private List<PointF> objInicial = new List<PointF>();
        TypeAutomato _typeAutomatoDesenv;
        public TypeAutomato typeAutomatoDesenv { get { return _typeAutomatoDesenv; } set { _typeAutomatoDesenv = value; } }

        public int X, Y;
        public bool createTransition;
        public TypeTransition typeTrans = TypeTransition.None;
        public Bitmap bmp;
        public object senderAutomato;

        #region Compilador
        //private string valueEntrada;
        #endregion
        
        #endregion

        #region Contruct
        public ComponentAutomato(Index _index)
        {
            index = _index;
            typeAutomatoDesenv = TypeAutomato.AFD;
            index.txtTypeAutomatoDesenv.Text = typeAutomatoDesenv.ToString();
            compiler = new CompilerAutomato(this);
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
        }
        #endregion

        #region PictureBox Automato
        private void pAutomato(string name)
        {
            pictureBox_ProjectAuto.Name = "panel" + name;
            pictureBox_ProjectAuto.Location = new Point(0, 0);
            pictureBox_ProjectAuto.Size = new Size(5000, 5000);
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
            if (e.Button == MouseButtons.Left)
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
                        imageAutomato[count].setX_Y(X, Y, count);
                        imageAutomato[count].createImageState(state.createAutomato());

                        addStatePictureBox(count);

                        compiler.totalStates.Add(imageAutomato[count].getNameAutomato());
                    }
                    else
                        MessageBox.Show("O limite de estados foi atingido, por favor verifique o autômato e remova os estados que não são utilizados", 
                                        "Error", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
                }
                else
                    index.txtStateAtual.Text = "Nenhum";
            }
            senderAutomato = sender;
        }

        void pictureBox_ProjectAuto_MouseDown(object sender, MouseEventArgs e)
        {
            if (compiler.getState1() != -1 && index.statusTransition)
            {
                DialogResult result = MessageBox.Show("Deseja cancelar Transição?",
                                                      "Info",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Question,
                                                      MessageBoxDefaultButton.Button2,
                                                      MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.OK)
                {
                    imageAutomato[compiler.getState1()].setBooleanTransState(false);
                    imageAutomato[compiler.getState1()].corStateMouse(Color.SkyBlue);
                    
                    primaryTrans = false;
                    secundaryTrans = false;
                    createTransition = false;
                    compiler.nullTransition();
                }
            }
        }
        
        #endregion

        #endregion

        #region Adiciona estado ao painel
        public void addStatePictureBox(int _count)
        {
            pictureBox_ProjectAuto.Controls.Add(imageAutomato[_count].getLabelState());
            pictureBox_ProjectAuto.Controls.Add(imageAutomato[_count].getImageState());
        }
        #endregion

        #region Gets
        //-----TabPage Referente ao tipo de Projeto-----\\
        public TabPage getTabPage()
        {
            return tabPageProject;
        }
        public TypeAutomato getIndexTypeAutomat()
        {
            return index.typeAutomato;
        }
        public Index getFindIndex()
        {
            return index;
        }
        public ImageAutomato getImageState(int _indice)
        {
            return imageAutomato[_indice];
        }        
        public CompilerAutomato getFindCompiler()
        {
            return compiler;
        }        
        #endregion  
    
        #region Deleta o estado
        public void removeState(PictureBox _ImageState, Label _LabelState, int _numberState)
        {
            if (index.statusDelete)
            {
                if (_numberState == compiler.getNumberStateInicial())
                {
                    compiler.setStateInicial(false);
                    compiler.setStateInicialLocation(new Point(0, 0));
                    compiler.setNameStateInicial("");
                    compiler.setNumberStateInicial(-1);
                    index.txtStateIncial.Text = "";

                    objInicial.Clear();

                    compiler.DrawTransition();
                }
                //compiler.createStateFinal("", _numberState);

                compiler.deleteStatesFinais(_numberState);

                compiler.DrawTransition();

                compiler.deleteElementMatrix(_numberState);

                pictureBox_ProjectAuto.Controls.Remove(_ImageState);
                pictureBox_ProjectAuto.Controls.Remove(_LabelState);
            }
        }
        #endregion

        #region Apaga Label Transition
        public void deleteStateLabelTransition(Label _stateLabelTransition)
        {
            pictureBox_ProjectAuto.Controls.Remove(_stateLabelTransition);
        }        
        #endregion

        #region Nova Transição AF
        public bool newTransicaoAutomato(ImageAutomato _automato)
        {
            createTransition = true;

            if (index.statusTransition)
            {
                if (!primaryTrans)
                {
                    compiler.setState1(_automato.getNumberState());
                    _automato.corStateMouse(Color.Yellow);
                    primaryTrans = true;
                }
                else
                {
                    compiler.setState2(_automato.getNumberState());
                    _automato.corStateMouse(Color.Yellow);
                    imageAutomato[compiler.getState2()].setBooleanTransState(true);
                    secundaryTrans = true;
                }
            }

            if (secundaryTrans)
            {
                if (!compiler.validateMatrix())
                {                    
                    ImageTransition imageTransicao = new ImageTransition(this);

                    if (imageTransicao.getStatusTrans())
                    {
                        if (!compiler.existAFND(compiler.getState1(), imageTransicao.getNameTrans()))
                        {
                            createNewTransition(imageTransicao.getNameTrans(), imageTransicao.getLabelTrans());
                        }
                        else
                        {
                            if (typeAutomatoDesenv == TypeAutomato.AFD)
                            {
                                DialogResult result = MessageBox.Show("Este Autômato se transfomará em um AFND, Deseja continuar?",
                                                                      "Info",
                                                                      MessageBoxButtons.OKCancel,
                                                                      MessageBoxIcon.Question);
                                if (result == DialogResult.OK)
                                {
                                    typeAutomatoDesenv = TypeAutomato.AFND;

                                    createNewTransition(imageTransicao.getNameTrans(), imageTransicao.getLabelTrans(), true);
                                     
                                    MessageBox.Show("Perfeito!\n" +
                                                    "Apartir de agora seu novo projeto se tornará um AFND.\n",
                                                    "Congratulations",
                                                    MessageBoxButtons.OK, 
                                                    MessageBoxIcon.Information);                                   
                                }
                            }
                            else if(typeAutomatoDesenv == TypeAutomato.AFND)
                            {
                                createNewTransition(imageTransicao.getNameTrans(), imageTransicao.getLabelTrans());
                                index.txtTypeAutomatoDesenv.Text = typeAutomatoDesenv.ToString();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Já existe uma transição para estes estados\nClique no texto da transição para alterar seu valor",
                                    "Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }


                imageAutomato[compiler.getState1()].setBooleanTransState(false);
                imageAutomato[compiler.getState1()].corStateMouse(Color.SkyBlue);

                imageAutomato[compiler.getState1()].setBooleanTransState(false);
                imageAutomato[compiler.getState2()].corStateMouse(Color.SkyBlue);
                primaryTrans = false;
                secundaryTrans = false;
                createTransition = false;
                compiler.nullTransition();
                
            }
            return createTransition;
        }

        private void createNewTransition(string _nameTrans, Label _labelTrans, bool AFND = false)
        {
            compiler.newTransition(_nameTrans, _labelTrans, index.typeAutomato);
            compiler.DrawTransition();                
        }

        #endregion

        #region Nova Transição AP
        public bool newTransicaoAP(ImageAutomato _automato)
        {
            createTransition = true;

            if (index.statusTransition)
            {
                if (!primaryTrans)
                {
                    compiler.setState1(_automato.getNumberState());
                    _automato.corStateMouse(Color.Yellow);
                    primaryTrans = true;
                }
                else
                {
                    compiler.setState2(_automato.getNumberState());
                    _automato.corStateMouse(Color.Yellow);
                    imageAutomato[compiler.getState2()].setBooleanTransState(true);
                    secundaryTrans = true;
                }
            }

            if (secundaryTrans)
            {
                if (!compiler.validateMatrix())
                {                    
                    ImageTransition imageTransicao = new ImageTransition(this);

                    if (imageTransicao.getStatusTrans())
                    {
                        if (!compiler.existAFND(compiler.getState1(), imageTransicao.getNameTrans()))
                        {
                            compiler.newTransition(imageTransicao.getNameTrans(), imageTransicao.getLabelTrans(), index.typeAutomato);
                            compiler.DrawTransition();
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Este Autômato se transfomará em um AFND, Deseja continuar?",
                                                                  "Info",
                                                                  MessageBoxButtons.YesNo,
                                                                  MessageBoxIcon.Question,
                                                                  MessageBoxDefaultButton.Button2,
                                                                  MessageBoxOptions.ServiceNotification);
                            if (result == DialogResult.Yes)
                            {
                                MessageBox.Show("Ok\n" +
                                                "Apartir de agora seu novo projeto se tornará um AFND.\n"+
                                                "Sendo assim será criado um histórico com o projeto anterior podendo ser resgatado apenas uma vez.\n"+
                                                "No menu Editar/Refazer poderá refazer o antigo projeto anterior a este novo",
                                                "Info",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button2,
                                                MessageBoxOptions.ServiceNotification);
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Já existe uma transição para estes estados\nClique no texto da transição para alterar seu valor",
                                    "Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }


                imageAutomato[compiler.getState1()].setBooleanTransState(false);
                imageAutomato[compiler.getState1()].corStateMouse(Color.SkyBlue);

                imageAutomato[compiler.getState1()].setBooleanTransState(false);
                imageAutomato[compiler.getState2()].corStateMouse(Color.SkyBlue);
                primaryTrans = false;
                secundaryTrans = false;
                createTransition = false;
                compiler.nullTransition();

            }
            return createTransition;
        }
        #endregion

        #region DrawTransition
        public void DrawTransition(Point pPoint1, 
                                   Point pPoint2,                                    
                                   Label _StateLabelTransition,
                                   TypeTransition _typeTrans, 
                                   TypeDoubleTransition _typeDouble,
                                   Color _color)
        {
            typeTrans = _typeTrans;
                        
            if (_typeTrans == TypeTransition.Loop)
            {                
                drawLoop(pPoint1,_color);                
            }

            if (_typeDouble == TypeDoubleTransition.None && _typeTrans == TypeTransition.Line)
            {
                drawLine(pPoint1, pPoint2,_color);
            }

            if (_typeDouble == TypeDoubleTransition.Up)
            {
                drawLineUp(pPoint1, pPoint2);
            }
            else if (_typeDouble == TypeDoubleTransition.Down)
            {
                drawLineDown(pPoint1, pPoint2);
            }
            
            pictureBox_ProjectAuto.Controls.Add(_StateLabelTransition);
        }
        public void nullDrawTransition()
        {
            pictureBox_ProjectAuto.Image = bmp;
        }
        #endregion

        #region DrawLines
        #region Draw Line
        private void drawLine(Point _pPoint1, Point _pPoint2, Color c)
        {
            Point pPoint1 = new Point(_pPoint1.X + 25, _pPoint1.Y + 25);
            Point pPoint2 = new Point(_pPoint2.X + 25, _pPoint2.Y + 25);

            Pen p = new Pen(c);
            p.Width = 1.5f;
            
            Graphics gfx = Graphics.FromImage(bmp);
            
            gfx.DrawLine(p, pPoint1, pPoint2);
            arrowTransition(_pPoint1, _pPoint2, c);

            gfx.Dispose();
        }
        #endregion
        #region Draw Circle
        private void drawLoop(Point pPoint, Color c)
        {
            Point pCircle = new Point(pPoint.X + 5, pPoint.Y - 20);

            Size pSize = new Size(40, 40);
            Pen p = new Pen(c);
            p.Width = 1.2f;

            Graphics grafico = Graphics.FromImage(bmp);
            grafico.DrawEllipse(p, new Rectangle(pCircle, pSize));

            //pinta o fundo
            p = new Pen(Color.Transparent);
            grafico.FillEllipse(p.Brush, new Rectangle(pCircle, pSize));

            arrowTransition(pPoint, new Point(0, 0), c);
            
            grafico.Dispose();
        }
        #endregion
        #region DrawLineDouble
        private void drawLineDown(Point _pPoint1,Point _pPoint2)
        {
            Point pPoint1 = new Point(_pPoint1.X + 25, _pPoint1.Y + 28);
            Point pPoint2 = new Point(_pPoint2.X + 25, _pPoint2.Y + 28);

            Pen p = new Pen(Color.Red);
            p.Width = 1.0f;

            Graphics gfx = Graphics.FromImage(bmp);

            gfx.DrawLine(p, pPoint1, pPoint2);
            arrowTransition(_pPoint1, _pPoint2, Color.Red);

            gfx.Dispose();
        }
        private void drawLineUp(Point _pPoint1, Point _pPoint2)
        {
            Point pPoint1 = new Point(_pPoint1.X + 25, _pPoint1.Y + 25);
            Point pPoint2 = new Point(_pPoint2.X + 25, _pPoint2.Y + 25);

            Pen p = new Pen(Color.Black);
            p.Width = 1.0f;

            Graphics gfx = Graphics.FromImage(bmp);

            gfx.DrawLine(p, pPoint1, pPoint2);
            arrowTransition(_pPoint1, _pPoint2, Color.Black);

            gfx.Dispose();
        }
        #endregion
        #endregion

        #region Draw Setas
        public void arrowTransition(Point pPoint, Point pPoint2, Color c)
        {
            if (typeTrans == TypeTransition.Loop)
            {
                pointsTransition(pPoint);

                Graphics g = Graphics.FromImage(bmp);
                Pen p = new Pen(c);
                p.Width = 1.0f;

                g.FillPolygon(new SolidBrush(c), (PointF[])(obj.ToArray()));
                g.DrawPolygon(p, (PointF[])(obj.ToArray()));
            }
            else
                if (typeTrans == TypeTransition.Line)
                {
                    pointsTransition(pPoint2);
                    rotationArrow(anguloArrow(pPoint, pPoint2), pPoint2);

                    Graphics g = Graphics.FromImage(bmp);
                    Pen p = new Pen(c);
                    p.Width = 1.0f;                    

                    g.FillPolygon(new SolidBrush(c), (PointF[])(obj.ToArray()));
                    g.DrawPolygon(p, (PointF[])(obj.ToArray()));
                }
        }
        #endregion

        #region Angulos
        private void rotationArrow(double angulo,Point _p2)
        {
            double rad = angulo;// (angulo * Math.PI) / 180;
            double p, q;     // ponto original
            double x, y;     // novo ponto            
            PointF centro = new PointF(_p2.X + 25, _p2.Y + 25);
            
            for (int i = 0; i < obj.Count; i++)
            {
                p = obj[i].X;
                q = obj[i].Y;

                x = (p * Math.Cos(rad)) + (q * -Math.Sin(rad)) + ((Math.Cos(rad) * -centro.X) + (-Math.Sin(rad) * -centro.Y) + centro.X);
                y = (p * Math.Sin(rad)) + (q * Math.Cos(rad)) + ((Math.Sin(rad) * -centro.X) + (Math.Cos(rad) * -centro.Y) + centro.Y);
                obj[i] = new PointF((float)x, (float)y);
            }
        }

        private double anguloArrow(Point p1, Point p2)
        {
            /***********************************************
            |            1°                      2°        |
            |                       90°                    |
            |                        |                     |
            |              X2 > X1   |   X2 < X1*          |
            |              Y2 > Y1   |   Y2 > Y1*          |
            |                        |                     |
            |  180°__________________O__________________0° |
            |                        |                360° |
            |              X2 > X1   |   X2 < X1           |
            |              Y2 < Y1   |   Y2 < Y1           |
            |                        |                     |
            |                        |                     |
            |                       270°                   |
            |            3°                      4°        |
            ***********************************************/

            double angulo;
            Point p3;
            double catOp, catAdj;

            p3 = new Point(p2.X, p1.Y);

            catOp = Math.Abs(p1.X - p3.X);
            catAdj = Math.Abs(p3.Y - p2.Y);
            angulo = Math.Atan(catOp / catAdj);

            if (p2.X >= p1.X)//Esquerda
            {
                if (p2.Y >= p1.Y)//Alto
                {
                    return (-angulo) + ((Math.PI / 2) - Math.PI);
                }
                else if (p2.Y <= p1.Y)//Baixo
                {
                    return angulo + (((3 * Math.PI) / 2) + Math.PI);
                }
            }

            else if (p2.X <= p1.X)//Direita
            {
                if (p2.Y >= p1.Y)//Alto
                {
                    return angulo + (Math.PI / 2) + Math.PI;
                }
                else if (p2.Y <= p1.Y)//Baixo
                {
                    return (-angulo) + (((3 * Math.PI) / 2) + Math.PI);
                }
            }

            return 0;
        }
        #endregion

        #region Pontos das Setas
        private void pointsTransition(Point pPoint)
        {
            if (typeTrans == TypeTransition.Loop)
            {
                PointF seta1 = new PointF(pPoint.X + 8f, pPoint.Y + 14);
                PointF seta2 = new PointF(seta1.X - 8f, seta1.Y - 8f);
                PointF seta3 = new PointF(seta2.X + 6f, seta2.Y + 2f);
                PointF seta4 = new PointF(seta1.X, seta1.Y - 12f);

                obj.Clear();
                obj.Add(seta1);
                obj.Add(seta2);
                obj.Add(seta3);
                obj.Add(seta4);
            }
            else
                if (typeTrans == TypeTransition.Line)
                {
                    PointF seta1 = new PointF(pPoint.X + 45, pPoint.Y + 25);
                    PointF seta2 = new PointF(seta1.X + 8f, seta1.Y - 5f);
                    PointF seta3 = new PointF(seta2.X - 2f, seta1.Y);
                    PointF seta4 = new PointF(seta1.X + 8f, seta1.Y + 5f);

                    obj.Clear();
                    obj.Add(seta1);
                    obj.Add(seta2);
                    obj.Add(seta3);
                    obj.Add(seta4);
                }
        }
        #endregion

        #region Pontos State Inicial 
        private void pointsInicial(Point pPoint)
        {
            PointF seta1 = new PointF(pPoint.X + 5f, pPoint.Y + 25);
            PointF seta2 = new PointF(seta1.X - 20f, seta1.Y - 20f);
            PointF seta3 = new PointF(seta2.X, seta2.Y + 40f);
            
            objInicial.Clear();
            objInicial.Add(seta1);
            objInicial.Add(seta2);
            objInicial.Add(seta3);            
        }
        #endregion

        #region StateInicial StateFinal

        #region StateInicial
        public bool setStateInicial(Point _automato, string _NameStateInicial, int _numberState)
        {
            if (!compiler.getExistStateInicial())
            {
                compiler.setStateInicial(true);
                compiler.setStateInicialLocation(_automato);
                compiler.setNameStateInicial(_NameStateInicial);
                compiler.setNumberStateInicial(_numberState);

                drawStateInicial(_automato);

                addImagePainelAutomato();
            }
            else
            {
                if (compiler.getNameStateIncial() == _NameStateInicial)
                {                    
                    compiler.setStateInicial(false);
                    compiler.setStateInicialLocation(new Point(0, 0));
                    compiler.setNameStateInicial("");
                    compiler.setNumberStateInicial(-1);

                    compiler.DrawTransition();
                }
                else
                {
                    MessageBox.Show("O estado " + compiler.getNameStateIncial() + " já está marcado como inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return compiler.getExistStateInicial();
        }
        public string getStateInicial()
        {
            return compiler.getNameStateIncial();
        }
        #endregion

        #region StateFinal
        public bool setStateFinal(string _NameStateFinal, int _numberState)
        {
            if (compiler.getFindExistsStateFinal(_numberState))
            {
                compiler.createStateFinal(_NameStateFinal, _numberState);
            }
            else
            {
                compiler.createStateFinal(_NameStateFinal, _numberState);
                imageAutomato[_numberState].drawStateFinal(new Point(0, 0));
            }

            return compiler.getExistStatesFinais();
        }
        #endregion

        #endregion

        #region Draw Inicial
        public void drawStateInicial(Point pPoint)
        {
            pointsInicial(pPoint);

            Graphics g = Graphics.FromImage(bmp);
            Pen p = new Pen(Color.Black);
            p.Width = 2.0f;

            g.FillPolygon(new SolidBrush(Color.Red), (PointF[])(objInicial.ToArray()));
            g.DrawPolygon(p, (PointF[])(objInicial.ToArray()));

            //pictureBox_ProjectAuto.Image = bmp;
        }
        #endregion 
       
        #region Adiciona imagem ao painel
        public void addImagePainelAutomato()
        {
            bmp.Save("a.bmp");
            pictureBox_ProjectAuto.Image = bmp;
        }
        #endregion

        #region Comentarios
        /*
            int numberStateInicial = compiler.getNumberStateInicial();
            int numberStateFinal = compiler.getNumberStateFinal();
            
            int number = numberStateInicial;            

            valueEntrada = _value.ToLower();

            foreach (char c in valueEntrada.ToCharArray())
                valueInput.Add(c);
                        
            for(int i = 0; i < valueInput.Count; i++)
            {
                if(valueInput[i].ToString() != "")
                    numberStateAtual = compiler.findValueMatrixAFD(number, valueInput[i].ToString());

                if (numberStateAtual == -1 && number == numberStateFinal)
                {
                    index.lblStatusFinal.Text = "Aprovado!";
                    index.lblStatusFinal.ForeColor = Color.Green;
                }
                else
                {
                    number = numberStateAtual;
                }
            }
            */


        /*
         * corrigir as transições para nao deixa um AFD ter 2 transições iguais para outros estados
        fazer um find na matriz passando como parametro o numero do automato com o valor do caracter 
            retornando o proximo estado se existir caracter valido
                       
        int i = 0;
        do
        {
            lbValueTrans.Items.Add(valueInput[i]);
            i++;
        } while (i < valueInput.Count);
        */
        #endregion               
    }
}