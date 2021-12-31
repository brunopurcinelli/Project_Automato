using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatos.Classes
{
    class State
    {
        #region Variáveis

        private int countAuto;

        #endregion

        #region Construct
        public State()
        {
            countAuto = 0;
        }
        #endregion

        #region Sets

        public void setcontador(int count = 1)
        {
            countAuto += count;
        }

        #endregion

        #region Gets
        public int getcontador()
        {
            return countAuto;
        }
        public string nameAutomato()
        {
            return "Q" + getcontador();
        }
        #endregion

        #region Criação do Autômato
        public string createAutomato()
        {
            string name;

            if (countAuto != 0)
            {
                name = nameAutomato();
            }
            else
                name = nameAutomato();

            setcontador();
            return name;
        }
        #endregion
    }
}
