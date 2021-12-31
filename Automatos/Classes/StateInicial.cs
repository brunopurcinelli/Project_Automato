using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Automatos.Classes
{
    class StateInicial
    {
        #region Variáveis

        private string nameState;
        private Point stateLocation;
        private bool stateInicial;
        private int numberState = -1;

        public Point getStateLocation { get { return stateLocation; } set { stateLocation = value; } }
        public bool getStateInicial { get { return stateInicial; } set { stateInicial = value; } }
        public string getNameState { get { return nameState; } set { nameState = value; } }
        public int getNumberState { get { return numberState; } set { numberState = value; } }

        #endregion
    }
}
