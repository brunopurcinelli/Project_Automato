using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Automatos.Classes
{
    class ImageAutomato
    {
        #region Variáveis

        private PictureBox ImageState = new PictureBox();
        private Label LabelState = new Label();
        private Bitmap bmp = new Bitmap(50,50);
        private bool moveImageState = false;
        private int imageStateX, imageStateY, labelStateX, labelStateY;
        Rectangle dropImage = new Rectangle(180, 180, 60, 60);

        private Int32 X, Y;
        private int numberState;

        private Point locationImage;
        private string nameAutomato;

        private bool transState;

        ComponentAutomato component;
        
        #endregion

        #region Construtor
        public ImageAutomato(ComponentAutomato _component)
        {
            component = _component;
        }
        #endregion

        #region Sets

        #region Imagem do Estado
        public void setImageState(PictureBox _ImageState)
        {
            ImageState = _ImageState;
        }
        #endregion

        #region Label do Estado
        public void steLabelState(Label _LabelState)
        {
            LabelState = _LabelState;
        }
        #endregion

        #region Name Label
        public void setNameLabelState(string _nameLabel)
        {
            LabelState.Text = _nameLabel;
        }
        #endregion

        #region Name Label
        public void setNameState(string _nameLabel)
        {
            nameAutomato = _nameLabel;
        }
        #endregion

        #region Localização da Imagem
        public void setX_Y(Int32 _x, Int32 _y, int _numberState)
        {
            X = _x - 25;
            Y = _y - 25;

            numberState = _numberState;
        }
        #endregion

        #region Set Button Enabled
        public void setBooleanTransState(bool _transState)
        {
            transState = _transState;
        }
        #endregion

        #endregion

        #region Gets

        #region Imagem do Estado
        public PictureBox getImageState()
        {
            return ImageState;
        }
        #endregion

        #region Label do Estado
        public Label getLabelState()
        {
            return LabelState;
        }
        #endregion

        #region Location Image
        
        public Point getLocationImage()
        {
            return ImageState.Location;
        }
        
        #endregion
        
        #region Name Automato
        public string getNameAutomato()
        {
            return nameAutomato;
        }        
        #endregion

        #region BitMap Automato
        /*
        public Bitmap getBmpAutomato()
        {
            return bmp;
        }
        */
        #endregion

        #region Count State
        /*
        public int getCountState()
        {
            return countState;        
        }
        */
        #endregion

        #region Number State
        public int getNumberState()
        {
            return numberState;
        }
        #endregion

        #region Get X e Y Imagem do Estado
        /*
        public Point getX_Y()
        {
            return new Point(X + 23, Y + 23);
        }
        */
        #endregion

        #endregion

        #region Cria Imagem
        public void createImageState(string contador)
        {
            #region Imagem do Estado
            ImageState.Name = contador;
            ImageState.BackColor = Color.SkyBlue;
            ImageState.Size = new Size(50, 50);
            ImageState.Location = new Point(X, Y);
            ImageState.Paint += new PaintEventHandler(ImagemState_Paint);
            ImageState.MouseDown += new MouseEventHandler(ImageState_MouseDown);
            ImageState.MouseMove += new MouseEventHandler(ImageState_MouseMove);
            ImageState.MouseUp += new MouseEventHandler(ImageState_MouseUp);
            ImageState.MouseEnter += new EventHandler(ImageState_MouseEnter);
            ImageState.MouseLeave += new EventHandler(ImageState_MouseLeave);
            //ImageState.dra
            #endregion

            #region Label do Estado
            LabelState.Name = ImageState.Name;
            LabelState.Text = LabelState.Name;
            LabelState.ForeColor = Color.Black;
            LabelState.BackColor = Color.SkyBlue;
            LabelState.TabIndex = 0;
            LabelState.AutoSize = true;
            LabelState.Font = new Font("Verdana", 7, FontStyle.Bold);
            LabelState.Size = new Size(20, 11);
            LabelState.Location = new Point(X + 14, Y + 18);
            LabelState.MouseDown += new MouseEventHandler(LabelState_MouseDown);
            LabelState.MouseUp += new MouseEventHandler(LabelState_MouseUp);
            LabelState.MouseMove += new MouseEventHandler(LabelState_MouseMove);
            LabelState.MouseEnter += new EventHandler(LabelState_MouseEnter);
            LabelState.MouseLeave += new EventHandler(LabelState_MouseLeave);

            #endregion

            // Nome do estado
            nameAutomato = ImageState.Name;

            // Localização do estado
            locationImage = new Point(X, Y);
        }
        #endregion

        #region Events

        #region alterar cor estado
        public void corStateMouse(Color c)
        {
            ImageState.BackColor = c;
            LabelState.BackColor = c;
        }

        void LabelState_MouseLeave(object sender, EventArgs e)
        {
            if (!transState)
                corStateMouse(Color.SkyBlue);
        }

        void LabelState_MouseEnter(object sender, EventArgs e)
        {
            corStateMouse(Color.Yellow);
        }

        void ImageState_MouseLeave(object sender, EventArgs e)
        {
            if (!transState)
                corStateMouse(Color.SkyBlue);
        }

        void ImageState_MouseEnter(object sender, EventArgs e)
        {
            corStateMouse(Color.Yellow);
        }
        #endregion
        
        #region Events LabelState
        void LabelState_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpState(e);
        }
        void LabelState_MouseDown(object sender, MouseEventArgs e)
        {            
            mouseDownState(e);
        }
        void LabelState_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoveState(e);
        }
        #endregion

        #region Events ImageState
        void ImageState_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpState(e);
        }
        void ImageState_MouseDown(object sender, MouseEventArgs e)
        {            
            mouseDownState(e);
        }
        void ImageState_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoveState(e);
        }
        #endregion

        #region Desenha o picturebox da imagem redondo
        void ImagemState_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath = new GraphicsPath();

            Rectangle newRectangle = ImageState.ClientRectangle;

            newRectangle.Inflate(-6, -6);
            e.Graphics.DrawEllipse(Pens.Black, newRectangle);
            newRectangle.Inflate(1, 1);

            buttonPath.AddEllipse(newRectangle);

            ImageState.Region = new Region(buttonPath);
        }
        #endregion
        
        #endregion

        #region Mouse Down
        private void mouseDownState(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int buttonAutomato = getButtonIndex();

                if (buttonAutomato == 4)
                {
                    moveImageState = true;
                    imageStateX = e.X;
                    imageStateY = e.Y;
                    labelStateX = e.X;
                    labelStateY = e.Y;
                    component.bmp = new Bitmap(1000, 1000);
                    component.getFindCompiler().apagaLabels();
                    component.addImagePainelAutomato();
                    
                }
            }
        }
        #endregion

        #region Mouse Up
        private void mouseUpState(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int buttonAutomato = getButtonIndex();

                component.getFindIndex().txtStateAtual.Text = nameAutomato;

                if (buttonAutomato == 2)
                {
                    if(component.getFindIndex().typeAutomato == TypeAutomato.AF)
                        setBooleanTransState(component.newTransicaoAutomato(this));
                    else
                        setBooleanTransState(component.newTransicaoAP(this));
                }

                else if (buttonAutomato == 3)
                {
                    component.removeState(ImageState, LabelState, numberState);
                    component.getFindIndex().txtStateAtual.Text = "Nenhum";
                }
                
                else if (buttonAutomato == 4)
                {
                    moveImageState = false;

                    component.getFindCompiler().updateMatrixTransitions(numberState, ImageState.Location);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!component.getFindIndex().executeCompiler)
                {
                    component.getFindIndex().setStateLocation(ImageState.Location);
                    component.getFindIndex().setNameState(nameAutomato);
                    component.getFindIndex().numberStateOrigem = numberState;
                    component.getFindIndex().numberStateDestino = -1;
                    component.getFindIndex().imageStateDelete = ImageState;
                    component.getFindIndex().labelStateDelete = LabelState;
                    component.getFindIndex().toolStripFinal.Visible = true;
                    component.getFindIndex().toolStripInicial.Visible = true;
                    component.getFindIndex().toolStripRename.Visible = true;
                    component.getFindIndex().contextMenuState.Show(new Point(ImageState.Location.X + 270, ImageState.Location.Y + 150));
                }
            }
        }
        #endregion

        #region Mouse Move
        private void mouseMoveState(MouseEventArgs e)
        {
            if (moveImageState)
            {                
                ImageState.Top = ImageState.Top + (e.Y - imageStateY);
                ImageState.Left = ImageState.Left + (e.X - imageStateX);
                LabelState.Top = LabelState.Top + (e.Y - labelStateY);
                LabelState.Left = LabelState.Left + (e.X - labelStateX);

                //component.getFindCompiler().updateMatrixTransitions(numberState, ImageState.Location);
            }
        }
        #endregion

        #region Draw Final
        public void drawStateFinal(Point pPoint)
        {
            Point pCircle = new Point(pPoint.X + 10, pPoint.Y + 10);

            Size pSize = new Size(30, 30);
            Pen p = new Pen(Color.Black);
            p.Width = 1.5f;

            Graphics grafico = Graphics.FromImage(bmp);
            grafico.DrawEllipse(p, new Rectangle(pCircle, pSize));

            //pinta o fundo
            p = new Pen(Color.Transparent);
            grafico.FillEllipse(p.Brush, new Rectangle(pCircle, pSize));

            bmp.Save("a.bmp");

            ImageState.Image = bmp;

            grafico.Dispose();
        }
        #endregion

        #region Delete Draw Final
        public void deleteDrawFinal()
        {
            Bitmap bmpFinal = new Bitmap(50, 50);
            ImageState.Image = bmpFinal;
        }
        #endregion

        #region BotoesImageIndex
        private int getButtonIndex()
        {
            return component.getFindIndex().getButtonAutomato();
        }
        #endregion
    }
}
