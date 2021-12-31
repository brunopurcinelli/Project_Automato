using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automatos.Forms
{
    public partial class RenameState : Form
    {
        #region Variáveis
        Index index;
        #endregion

        #region Construtor
        public RenameState(Index _index)
        {
            InitializeComponent();
            index = _index;
        }
        #endregion

        #region FormClosing
        private void RenameState_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region Sets
        public void setNameStateAtual(string _nameState)
        {
            txtNameAtual.Text = _nameState;
        }
        #endregion

        #region Gets
        public string getNameModificado()
        {
            return txtNameModificado.Text;
        }        
        #endregion

        #region Botoes
        private void btOk_Click(object sender, EventArgs e)
        {
            index.renameState = true;
            index.setNameState(txtNameModificado.Text);
            Dispose();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion

        #region Key Enter
        private void txtNameModificado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                index.renameState = true;
                index.setNameState(txtNameModificado.Text);
                Dispose();
            }
        }
        #endregion
    }
}
