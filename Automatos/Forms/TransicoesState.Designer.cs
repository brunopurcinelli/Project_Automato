namespace Automatos.Forms
{
    partial class TransicoesState
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Coisa",
            "Coisa2"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransicoesState));
            this.lbStateAtual = new System.Windows.Forms.Label();
            this.txtStateAtual = new System.Windows.Forms.Label();
            this.listTransicoes = new System.Windows.Forms.ListView();
            this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lbStateAtual
            // 
            this.lbStateAtual.AutoSize = true;
            this.lbStateAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStateAtual.Location = new System.Drawing.Point(39, 25);
            this.lbStateAtual.Name = "lbStateAtual";
            this.lbStateAtual.Size = new System.Drawing.Size(78, 15);
            this.lbStateAtual.TabIndex = 0;
            this.lbStateAtual.Text = "Estado Atual:";
            // 
            // txtStateAtual
            // 
            this.txtStateAtual.AutoSize = true;
            this.txtStateAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStateAtual.Location = new System.Drawing.Point(136, 25);
            this.txtStateAtual.Name = "txtStateAtual";
            this.txtStateAtual.Size = new System.Drawing.Size(55, 15);
            this.txtStateAtual.TabIndex = 1;
            this.txtStateAtual.Text = "Nenhum";
            // 
            // listTransicoes
            // 
            this.listTransicoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderState,
            this.columnHeaderValue});
            this.listTransicoes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listTransicoes.Location = new System.Drawing.Point(42, 54);
            this.listTransicoes.Name = "listTransicoes";
            this.listTransicoes.Size = new System.Drawing.Size(213, 227);
            this.listTransicoes.TabIndex = 0;
            this.listTransicoes.UseCompatibleStateImageBehavior = false;
            this.listTransicoes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderState
            // 
            this.columnHeaderState.Text = "Estado";
            this.columnHeaderState.Width = 100;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Valor Transição";
            this.columnHeaderValue.Width = 100;
            // 
            // TransicoesState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 407);
            this.Controls.Add(this.listTransicoes);
            this.Controls.Add(this.txtStateAtual);
            this.Controls.Add(this.lbStateAtual);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransicoesState";
            this.Text = "Transições";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStateAtual;
        private System.Windows.Forms.Label txtStateAtual;
        private System.Windows.Forms.ListView listTransicoes;
        private System.Windows.Forms.ColumnHeader columnHeaderState;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
    }
}