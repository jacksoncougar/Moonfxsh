namespace Moonfish.Forms
{
    partial class GuerillaBlockViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuerillaBlockViewer));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.navBack = new System.Windows.Forms.ToolStripButton();
            this.navForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.navParent = new System.Windows.Forms.ToolStripButton();
            this.elementIndex = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(558, 417);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navBack,
            this.navForward,
            this.toolStripSeparator1,
            this.navParent,
            this.elementIndex});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(564, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // navBack
            // 
            this.navBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navBack.Image = ((System.Drawing.Image)(resources.GetObject("navBack.Image")));
            this.navBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navBack.Name = "navBack";
            this.navBack.Size = new System.Drawing.Size(23, 22);
            this.navBack.Text = "toolStripButton1";
            // 
            // navForward
            // 
            this.navForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navForward.Image = ((System.Drawing.Image)(resources.GetObject("navForward.Image")));
            this.navForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navForward.Name = "navForward";
            this.navForward.Size = new System.Drawing.Size(23, 22);
            this.navForward.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // navParent
            // 
            this.navParent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navParent.Image = ((System.Drawing.Image)(resources.GetObject("navParent.Image")));
            this.navParent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navParent.Name = "navParent";
            this.navParent.Size = new System.Drawing.Size(23, 22);
            this.navParent.Text = "toolStripButton3";
            this.navParent.Click += new System.EventHandler(this.navParent_Click);
            // 
            // elementIndex
            // 
            this.elementIndex.Name = "elementIndex";
            this.elementIndex.Size = new System.Drawing.Size(121, 25);
            // 
            // GuerillaBlockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GuerillaBlockViewer";
            this.Size = new System.Drawing.Size(564, 448);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton navBack;
        private System.Windows.Forms.ToolStripButton navForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton navParent;
        private System.Windows.Forms.ToolStripComboBox elementIndex;
    }
}
