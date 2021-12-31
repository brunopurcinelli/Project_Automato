using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Automatos.Forms;

namespace Automatos.Classes
{
    class TransitionMatrix
    {
        #region Variáveis

        Index index;
        
        private Point StateLocationOrigem, StateLocationDestino;
        public Point stateLocationOrigem { get { return StateLocationOrigem; } set { StateLocationOrigem = value; } }
        public Point stateLocationDestino { get { return StateLocationDestino; } set { StateLocationDestino = value; } }

        private string StateNameOrigem, StateNameDestino;
        public string stateNameOrigem { get { return StateNameOrigem; } set { StateNameOrigem = value; } }
        public string stateNameDestino { get { return StateNameDestino; } set { StateNameDestino = value; } }

        private string StateValueTransition;
        public string stateValueTransition { get { return StateValueTransition; } set { StateValueTransition = value; } }

        private Label StateLabelTransition;
        public Label stateLabelTransition
        {
            get { return StateLabelTransition; }
            set
            {
                StateLabelTransition = value; 
                
                stateLabelTransition.MouseEnter += new EventHandler(stateLabelTransition_MouseEnter);
                stateLabelTransition.MouseLeave += new EventHandler(stateLabelTransition_MouseLeave);
                stateLabelTransition.MouseClick += new MouseEventHandler(stateLabelTransition_MouseClick);

                locationStateLabelTransition();
            }
        }
        
        private int NumberStateOrigem, NumberStateDestino;
        public int numberStateOrigem { get { return NumberStateOrigem; } set { NumberStateOrigem = value; } }
        public int numberStateDestino { get { return NumberStateDestino; } set { NumberStateDestino = value; } }
        
        private TypeTransition StateTypeTransition = TypeTransition.None;
        public TypeTransition stateTypeTransition { get { return StateTypeTransition; } set { StateTypeTransition = value; } }
        
        private TypeAutomato StateTypeAutomato = TypeAutomato.None;
        public TypeAutomato stateTypeAutomato { get { return StateTypeAutomato; } set { StateTypeAutomato = value; } }
        
        private TypeDoubleTransition StateDoubleTransition = TypeDoubleTransition.None;
        public TypeDoubleTransition stateDoubleTransition { get { return StateDoubleTransition; } set { StateDoubleTransition = value; } }

        private bool EnabledLabelTransition = true;
        public bool enabledLabelTransition { get { return EnabledLabelTransition; } set { EnabledLabelTransition = value; } }

        private bool DoubleTransition;
        public bool doubleTransition { get { return DoubleTransition; } set { DoubleTransition = value; } }
        #endregion

        #region Construtor
        public TransitionMatrix(Index _index)
        {
            index = _index;
        }
        #endregion

        #region Localização do Label da Transição
        public void locationStateLabelTransition()
        {
            if (stateLocationOrigem == stateLocationDestino)
            {
                stateTypeTransition = TypeTransition.Loop;
                valueTransitionLoop(stateLocationOrigem);
            }
            else
            {
                if (doubleTransition)
                {
                    stateTypeTransition = TypeTransition.Line;
                    valueTransitionDouble(stateLocationOrigem, stateLocationDestino);
                }
                else
                {
                    stateTypeTransition = TypeTransition.Line;
                    valueTransitionDouble(stateLocationOrigem, stateLocationDestino);
                }
            }
        }
        private void valueTransition(Point p1, Point p2)
        {
            Point pInicio = new Point();

            pInicio.X = ((p1.X + p2.X) / 2);
            pInicio.Y = ((p1.Y + p2.Y) / 2);

            stateLabelTransition.Location = pInicio;
        }
        private void valueTransitionDouble(Point p1, Point p2)
        {
            Point pInicio = new Point();
                        
            if (stateDoubleTransition == TypeDoubleTransition.Down)
            {
                pInicio.X = ((p1.X + p2.X) / 2);// +20;
                pInicio.Y = ((p1.Y + p2.Y) / 2);// +40;
                
                
                stateLabelTransition.ForeColor = Color.Red;
            }
            else
            {                
                pInicio.X = ((p1.X + p2.X) / 2);
                pInicio.Y = ((p1.Y + p2.Y) / 2);
                                
            }

            stateLabelTransition.Location = pInicio;
        }
        private void valueTransitionLoop(Point _location)
        {
            Point pInicio = new Point();
            
            pInicio.X = _location.X + 20;
            pInicio.Y = _location.Y - 30;

            stateLabelTransition.Location = pInicio;
        }
        #endregion
               
        #region Sets
        /*
        public void setTypeTransition(TypeTransition _stateTypeTransition)
        {
            stateTypeTransition = _stateTypeTransition;
        }
        public void setTypeAutomato(TypeAutomato _stateTypeAutomato)
        {   
            stateTypeAutomato = _stateTypeAutomato;
        }
        public void setNumberStates(int _numberStateOrigem, int _numberStateDestino)
        {
            numberStateOrigem = _numberStateOrigem;
            numberStateDestino = _numberStateDestino;
        }

        public void setNameStateOrigem(string _nameStateOrigem)
        {
            stateNameOrigem = _nameStateOrigem;
        }
        public void setNameStateDestino(string _nameStateDestino)
        {
            stateNameDestino = _nameStateDestino;
        }

        public void updateStateOrigem(Point _stateLocationOrigem)
        {
            stateLocationOrigem = _stateLocationOrigem;
        }
        public void updateStateDestino(Point _stateLocationDestino)
        {
            stateLocationDestino = _stateLocationDestino;
        }

        public void setEnabledLabelTransition(bool _enabled)
        {
            enabledLabelTransition = _enabled;
        }

        public void setValueTransition(string _name)
        {
            stateValueTransition += _name;
        }
        
        public void setNewTransition(Label _StateLabelTransition)//Point _StateLocationInicial, Point _StateLocationFinal, string _ValueTransition, Label _StateLabelTransition)
        {            
            stateLabelTransition = _StateLabelTransition;

            stateLabelTransition.MouseEnter += new EventHandler(stateLabelTransition_MouseEnter);
            stateLabelTransition.MouseLeave += new EventHandler(stateLabelTransition_MouseLeave);
            stateLabelTransition.MouseClick += new MouseEventHandler(stateLabelTransition_MouseClick);

            locationStateLabelTransition();
        }
        */
        #endregion

        #region Gets
        /*
        public Point getStateLocationInicial()
        {
            return stateLocationOrigem;
        }
        public Point getStateLocationfinal()
        {
            return stateLocationDestino;
        }
        public string getValueTransition()
        {
            return stateValueTransition;
        }
        public Label getStateLabelTransition()
        {
            return stateLabelTransition;
        }
        public TypeTransition getStateTypeTransition()
        {
            return stateTypeTransition;
        }

        public int getNumberStateOrigem()
        {
            return numberStateOrigem;
        }
        public int getNumberStateDestino()
        {
            return numberStateDestino;
        }

        public string getNameStateOrigem()
        {
            return stateNameOrigem;
        }
        public string getNameStateDestino()
        {
            return stateNameDestino;
        }
        public bool getEnabledLabelTransition()
        {
            return enabledLabelTransition;
        }
        public TypeAutomato getTypeAutomato()
        {
            return stateTypeAutomato;
        }
         * */
        #endregion

        #region Events
        void stateLabelTransition_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (enabledLabelTransition)
                {
                    NewTransition transLocal = new NewTransition();//stateTypeAutomato);
                    transLocal.setInitialize(stateValueTransition, stateTypeAutomato);// compiler.getFindComponent().typeAutomatoDesenv);
                    transLocal.ShowDialog();

                    if (transLocal.getSituation())
                    {
                        stateLabelTransition.Text = transLocal.getTransText();
                        stateValueTransition = transLocal.getTransTextContinuous();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                index.toolStripFinal.Visible = false;
                index.toolStripInicial.Visible = false;
                index.toolStripRename.Visible = false;

                index.numberStateOrigem = numberStateOrigem;
                index.numberStateDestino = numberStateDestino;
                index.contextMenuState.Show(new Point(StateLabelTransition.Location.X + 270, StateLabelTransition.Location.Y + 150));

            }
        }

        void stateLabelTransition_MouseLeave(object sender, EventArgs e)
        {
            stateLabelTransition.BackColor = Color.White;
        }

        void stateLabelTransition_MouseEnter(object sender, EventArgs e)
        {
            stateLabelTransition.BackColor = Color.Yellow;
        }
        #endregion        
    }
}
