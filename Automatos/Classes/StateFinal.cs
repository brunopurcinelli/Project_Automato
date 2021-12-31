using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Automatos.Classes
{
    class StateFinal
    {
        #region Variáveis

        private string nameState;
        private int numberState = -1;
        private Point stateLocation;
        private bool stateFinal;

        public Point getStateLocation { get { return stateLocation; } set { stateLocation = value; } }
        public bool getStateFinal { get { return stateFinal; } set { stateFinal = value; } }
        public string getNameState { get { return nameState; } set { nameState = value; } }
        public int getNumberState { get { return numberState; } set { numberState = value; } }

        #endregion
    }
}
