namespace Automatos.Forms
{
    partial class NewTransition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTransition));
            this.txtTransValue = new System.Windows.Forms.TextBox();
            this.lbTransitions = new System.Windows.Forms.ListBox();
            this.toolsTransition = new System.Windows.Forms.ToolStrip();
            this.toolStripVazio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripInserir = new System.Windows.Forms.ToolStripButton();
            this.toolStripApagar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolsTransition.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTransValue
            // 
            this.txtTransValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtTransValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTransValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransValue.Location = new System.Drawing.Point(0, 0);
            this.txtTransValue.MaxLength = 1;
            this.txtTransValue.Name = "txtTransValue";
            this.txtTransValue.Size = new System.Drawing.Size(176, 21);
            this.txtTransValue.TabIndex = 16;
            this.txtTransValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTransValue_KeyUp);
            // 
            // lbTransitions
            // 
            this.lbTransitions.BackColor = System.Drawing.SystemColors.Info;
            this.lbTransitions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTransitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransitions.FormattingEnabled = true;
            this.lbTransitions.ItemHeight = 15;
            this.lbTransitions.Location = new System.Drawing.Point(0, 21);
            this.lbTransitions.Name = "lbTransitions";
            this.lbTransitions.Size = new System.Drawing.Size(84, 202);
            this.lbTransitions.TabIndex = 17;
            // 
            // toolsTransition
            // 
            this.toolsTransition.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolsTransition.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsTransition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripVazio,
            this.toolStripSeparator2,
            this.toolStripInserir,
            this.toolStripApagar,
            this.toolStripSeparator1,
            this.toolStripOk,
            this.toolStripCancelar});
            this.toolsTransition.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolsTransition.Location = new System.Drawing.Point(86, 21);
            this.toolsTransition.Name = "toolsTransition";
            this.toolsTransition.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolsTransition.Size = new System.Drawing.Size(90, 202);
            this.toolsTransition.TabIndex = 18;
            this.toolsTransition.Text = "toolStrip1";
            // 
            // toolStripVazio
            // 
            this.toolStripVazio.Image = ((System.Drawing.Image)(resources.GetObject("toolStripVazio.Image")));
            this.toolStripVazio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripVazio.Name = "toolStripVazio";
            this.toolStripVazio.Size = new System.Drawing.Size(87, 20);
            this.toolStripVazio.Text = "Trans. Vazia";
            this.toolStripVazio.Click += new System.EventHandler(this.toolStripVazio_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(87, 6);
            // 
            // toolStripInserir
            // 
            this.toolStripInserir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripInserir.Image")));
            this.toolStripInserir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInserir.Name = "toolStripInserir";
            this.toolStripInserir.Size = new System.Drawing.Size(87, 20);
            this.toolStripInserir.Text = "Inserir";
            this.toolStripInserir.Click += new System.EventHandler(this.btInsertTrans_Click);
            // 
            // toolStripApagar
            // 
            this.toolStripApagar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripApagar.Image")));
            this.toolStripApagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripApagar.Name = "toolStripApagar";
            this.toolStripApagar.Size = new System.Drawing.Size(87, 20);
            this.toolStripApagar.Text = "Apagar";
            this.toolStripApagar.Click += new System.EventHandler(this.btApagar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(87, 6);
            // 
            // toolStripOk
            // 
            this.toolStripOk.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOk.Image")));
            this.toolStripOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOk.Name = "toolStripOk";
            this.toolStripOk.Size = new System.Drawing.Size(87, 20);
            this.toolStripOk.Text = "OK";
            this.toolStripOk.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // toolStripCancelar
            // 
            this.toolStripCancelar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCancelar.Image")));
            this.toolStripCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCancelar.Name = "toolStripCancelar";
            this.toolStripCancelar.Size = new System.Drawing.Size(87, 20);
            this.toolStripCancelar.Text = "Cancelar";
            this.toolStripCancelar.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // NewTransition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 223);
            this.Controls.Add(this.toolsTransition);
            this.Controls.Add(this.lbTransitions);
            this.Controls.Add(this.txtTransValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTransition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transição";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewTransition_FormClosing);
            this.toolsTransition.ResumeLayout(false);
            this.toolsTransition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransValue;
        private System.Windows.Forms.ListBox lbTransitions;
        private System.Windows.Forms.ToolStrip toolsTransition;
        private System.Windows.Forms.ToolStripButton toolStripVazio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripInserir;
        private System.Windows.Forms.ToolStripButton toolStripApagar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripOk;
        private System.Windows.Forms.ToolStripButton toolStripCancelar;
    }
}