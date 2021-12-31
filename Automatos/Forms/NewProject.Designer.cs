namespace Automatos.FormsAutomato
{
    partial class NewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Autômato Finito");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Todos os Modelos", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Autômato Finito");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Autômato de Pilha");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Todos os Modelos", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.btOk = new System.Windows.Forms.Button();
            this.infoImage = new System.Windows.Forms.PictureBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.txtInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pButton = new System.Windows.Forms.Panel();
            this.projectName = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.splitNewItem = new System.Windows.Forms.SplitContainer();
            this.pTree = new System.Windows.Forms.Panel();
            this.treeIniciar = new System.Windows.Forms.TreeView();
            this.barraStatus = new System.Windows.Forms.StatusStrip();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.infoImage)).BeginInit();
            this.panelButton.SuspendLayout();
            this.pButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitNewItem)).BeginInit();
            this.splitNewItem.Panel1.SuspendLayout();
            this.splitNewItem.Panel2.SuspendLayout();
            this.splitNewItem.SuspendLayout();
            this.pTree.SuspendLayout();
            this.barraStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btOk.Location = new System.Drawing.Point(0, 0);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(67, 25);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // infoImage
            // 
            this.infoImage.BackColor = System.Drawing.Color.White;
            this.infoImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("infoImage.InitialImage")));
            this.infoImage.Location = new System.Drawing.Point(0, 0);
            this.infoImage.Name = "infoImage";
            this.infoImage.Size = new System.Drawing.Size(270, 215);
            this.infoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.infoImage.TabIndex = 1;
            this.infoImage.TabStop = false;
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.Location = new System.Drawing.Point(67, 0);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panelButton
            // 
            this.panelButton.BackColor = System.Drawing.Color.DarkBlue;
            this.panelButton.Controls.Add(this.btOk);
            this.panelButton.Controls.Add(this.btCancel);
            this.panelButton.Location = new System.Drawing.Point(306, 25);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(142, 25);
            this.panelButton.TabIndex = 9;
            // 
            // txtInfo
            // 
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(39, 17);
            this.txtInfo.Text = "Status";
            // 
            // pButton
            // 
            this.pButton.BackColor = System.Drawing.Color.DarkBlue;
            this.pButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pButton.Controls.Add(this.panelButton);
            this.pButton.Controls.Add(this.projectName);
            this.pButton.Controls.Add(this.lblInfo);
            this.pButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButton.Location = new System.Drawing.Point(0, 217);
            this.pButton.Name = "pButton";
            this.pButton.Size = new System.Drawing.Size(455, 57);
            this.pButton.TabIndex = 9;
            // 
            // projectName
            // 
            this.projectName.Dock = System.Windows.Forms.DockStyle.Right;
            this.projectName.Location = new System.Drawing.Point(138, 0);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(313, 20);
            this.projectName.TabIndex = 8;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(11, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(86, 13);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Nome do Projeto";
            // 
            // splitNewItem
            // 
            this.splitNewItem.BackColor = System.Drawing.Color.DarkBlue;
            this.splitNewItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitNewItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitNewItem.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitNewItem.Location = new System.Drawing.Point(0, 0);
            this.splitNewItem.Name = "splitNewItem";
            // 
            // splitNewItem.Panel1
            // 
            this.splitNewItem.Panel1.Controls.Add(this.pTree);
            // 
            // splitNewItem.Panel2
            // 
            this.splitNewItem.Panel2.Controls.Add(this.infoImage);
            this.splitNewItem.Size = new System.Drawing.Size(455, 219);
            this.splitNewItem.SplitterDistance = 177;
            this.splitNewItem.TabIndex = 7;
            // 
            // pTree
            // 
            this.pTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pTree.Controls.Add(this.treeIniciar);
            this.pTree.Controls.Add(this.treeView1);
            this.pTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTree.Location = new System.Drawing.Point(0, 0);
            this.pTree.Name = "pTree";
            this.pTree.Size = new System.Drawing.Size(173, 215);
            this.pTree.TabIndex = 3;
            // 
            // treeIniciar
            // 
            this.treeIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeIniciar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeIniciar.Location = new System.Drawing.Point(0, 0);
            this.treeIniciar.Name = "treeIniciar";
            treeNode1.Name = "NodeAF";
            treeNode1.Text = "Autômato Finito";
            treeNode1.ToolTipText = "Autômato Finito";
            treeNode2.BackColor = System.Drawing.Color.Blue;
            treeNode2.ForeColor = System.Drawing.Color.White;
            treeNode2.Name = "NodeAllTemplates";
            treeNode2.Text = "Todos os Modelos";
            treeNode2.ToolTipText = "Todos os Modelos";
            this.treeIniciar.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeIniciar.ShowNodeToolTips = true;
            this.treeIniciar.Size = new System.Drawing.Size(169, 211);
            this.treeIniciar.TabIndex = 0;
            this.treeIniciar.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeIniciar_NodeMouseClick);
            this.treeIniciar.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeIniciar_NodeMouseDoubleClick);
            // 
            // barraStatus
            // 
            this.barraStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtInfo});
            this.barraStatus.Location = new System.Drawing.Point(0, 274);
            this.barraStatus.Name = "barraStatus";
            this.barraStatus.Size = new System.Drawing.Size(455, 22);
            this.barraStatus.TabIndex = 8;
            this.barraStatus.Text = "statusStrip1";
            // 
            // treeView1
            // 
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "NodeAF";
            treeNode3.Text = "Autômato Finito";
            treeNode3.ToolTipText = "Autômato Finito";
            treeNode4.Name = "NodeAP";
            treeNode4.Text = "Autômato de Pilha";
            treeNode4.ToolTipText = "Autômato de Pilha";
            treeNode5.BackColor = System.Drawing.Color.Blue;
            treeNode5.ForeColor = System.Drawing.Color.White;
            treeNode5.Name = "NodeAllTemplates";
            treeNode5.Text = "Todos os Modelos";
            treeNode5.ToolTipText = "Todos os Modelos";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(169, 211);
            this.treeView1.TabIndex = 1;
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 296);
            this.Controls.Add(this.pButton);
            this.Controls.Add(this.splitNewItem);
            this.Controls.Add(this.barraStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Projeto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewProject_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.infoImage)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.pButton.ResumeLayout(false);
            this.pButton.PerformLayout();
            this.splitNewItem.Panel1.ResumeLayout(false);
            this.splitNewItem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitNewItem)).EndInit();
            this.splitNewItem.ResumeLayout(false);
            this.pTree.ResumeLayout(false);
            this.barraStatus.ResumeLayout(false);
            this.barraStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.PictureBox infoImage;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.ToolStripStatusLabel txtInfo;
        private System.Windows.Forms.Panel pButton;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.SplitContainer splitNewItem;
        private System.Windows.Forms.Panel pTree;
        private System.Windows.Forms.TreeView treeIniciar;
        private System.Windows.Forms.StatusStrip barraStatus;
        private System.Windows.Forms.TreeView treeView1;
    }
}