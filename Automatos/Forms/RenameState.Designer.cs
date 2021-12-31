namespace Automatos.Forms
{
    partial class RenameState
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameState));
            this.lblNameAtual = new System.Windows.Forms.Label();
            this.lblNameModificado = new System.Windows.Forms.Label();
            this.txtNameAtual = new System.Windows.Forms.TextBox();
            this.txtNameModificado = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNameAtual
            // 
            this.lblNameAtual.AutoSize = true;
            this.lblNameAtual.Location = new System.Drawing.Point(21, 17);
            this.lblNameAtual.Name = "lblNameAtual";
            this.lblNameAtual.Size = new System.Drawing.Size(62, 13);
            this.lblNameAtual.TabIndex = 0;
            this.lblNameAtual.Text = "Nome Atual";
            // 
            // lblNameModificado
            // 
            this.lblNameModificado.AutoSize = true;
            this.lblNameModificado.Location = new System.Drawing.Point(21, 42);
            this.lblNameModificado.Name = "lblNameModificado";
            this.lblNameModificado.Size = new System.Drawing.Size(90, 13);
            this.lblNameModificado.TabIndex = 0;
            this.lblNameModificado.Text = "Nome Modificado";
            // 
            // txtNameAtual
            // 
            this.txtNameAtual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameAtual.Location = new System.Drawing.Point(116, 14);
            this.txtNameAtual.Name = "txtNameAtual";
            this.txtNameAtual.Size = new System.Drawing.Size(100, 20);
            this.txtNameAtual.TabIndex = 1;
            // 
            // txtNameModificado
            // 
            this.txtNameModificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameModificado.Location = new System.Drawing.Point(116, 39);
            this.txtNameModificado.MaxLength = 3;
            this.txtNameModificado.Name = "txtNameModificado";
            this.txtNameModificado.Size = new System.Drawing.Size(100, 20);
            this.txtNameModificado.TabIndex = 1;
            this.txtNameModificado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNameModificado_KeyDown);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(50, 71);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "Renomear";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(141, 71);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // RenameState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 111);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.txtNameModificado);
            this.Controls.Add(this.txtNameAtual);
            this.Controls.Add(this.lblNameModificado);
            this.Controls.Add(this.lblNameAtual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renomear";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RenameState_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameAtual;
        private System.Windows.Forms.Label lblNameModificado;
        private System.Windows.Forms.TextBox txtNameAtual;
        private System.Windows.Forms.TextBox txtNameModificado;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancelar;
    }
}