using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Automatos.Classes
{
    class StatesMatrix
    {
        #region Variáveis        
        private int NroState = -1;
        public int nroState                 { get { return NroState;        } set { NroState = value;        } }
        private Point LocationState;
        public Point locationState          { get { return LocationState;   } set { LocationState = value;   } }
        private string NameState;  
        public string nameState             { get { return NameState;       } set { NameState = value;       } }
        private string ValorTrans;
        public string valorTrans            { get { return ValorTrans;      } set { ValorTrans = value;      } }
        private ArrayList StatesƐ_Closure;
        public ArrayList statesƐ_Closure    { get { return StatesƐ_Closure; } set { StatesƐ_Closure = value; } }
        #endregion

        #region Estados do Ɛ_Closure
        public int findExistStateƐ_Closure(int _nroState)
        {
            return StatesƐ_Closure.IndexOf(_nroState);
        }
        #endregion

    }
}
