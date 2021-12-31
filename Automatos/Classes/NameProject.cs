using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatos
{
    class NameProject
    {
        #region Variáveis        
        private string nameProject;
        #endregion

        #region Nome do Projeto
        public string setTypeProject(TypeProject _typeProject = TypeProject.None,
                                     TypeAutomato _typeAutomato = TypeAutomato.None)
        {
            if (_typeProject != TypeProject.None)
            {
                nameProject = _typeProject.ToString();
            }
            if (_typeAutomato != TypeAutomato.None)
            {
                nameProject = nameProject + "_" + _typeAutomato.ToString();
            }

            return nameProject;
        }
        #endregion
    }
}
