namespace Moonfish.Forms
{
    partial class VrtxViewer
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer_sc1_values = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer_tags_hex = new System.Windows.Forms.SplitContainer();
            this.vertexTags = new System.Windows.Forms.ListView();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txbStride = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txbOffset = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txbShift = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.txbMask = new System.Windows.Forms.ToolStripTextBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_sc1_values)).BeginInit();
            this.splitContainer_sc1_values.Panel1.SuspendLayout();
            this.splitContainer_sc1_values.Panel2.SuspendLayout();
            this.splitContainer_sc1_values.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tags_hex)).BeginInit();
            this.splitContainer_tags_hex.Panel1.SuspendLayout();
            this.splitContainer_tags_hex.Panel2.SuspendLayout();
            this.splitContainer_tags_hex.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // splitContainer_sc1_values
            // 
            this.splitContainer_sc1_values.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_sc1_values.Location = new System.Drawing.Point(0, 49);
            this.splitContainer_sc1_values.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_sc1_values.Name = "splitContainer_sc1_values";
            // 
            // splitContainer_sc1_values.Panel1
            // 
            this.splitContainer_sc1_values.Panel1.Controls.Add(this.splitContainer_tags_hex);
            // 
            // splitContainer_sc1_values.Panel2
            // 
            this.splitContainer_sc1_values.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer_sc1_values.Size = new System.Drawing.Size(1117, 460);
            this.splitContainer_sc1_values.SplitterDistance = 900;
            this.splitContainer_sc1_values.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(213, 460);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(213, 230);
            this.propertyGrid1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(213, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1117, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1102, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer_tags_hex
            // 
            this.splitContainer_tags_hex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_tags_hex.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_tags_hex.Name = "splitContainer_tags_hex";
            // 
            // splitContainer_tags_hex.Panel1
            // 
            this.splitContainer_tags_hex.Panel1.Controls.Add(this.vertexTags);
            // 
            // splitContainer_tags_hex.Panel2
            // 
            this.splitContainer_tags_hex.Panel2.Controls.Add(this.hexBox1);
            this.splitContainer_tags_hex.Size = new System.Drawing.Size(900, 460);
            this.splitContainer_tags_hex.SplitterDistance = 278;
            this.splitContainer_tags_hex.TabIndex = 6;
            // 
            // vertexTags
            // 
            this.vertexTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertexTags.FullRowSelect = true;
            this.vertexTags.Location = new System.Drawing.Point(0, 0);
            this.vertexTags.MultiSelect = false;
            this.vertexTags.Name = "vertexTags";
            this.vertexTags.Size = new System.Drawing.Size(278, 460);
            this.vertexTags.TabIndex = 5;
            this.vertexTags.UseCompatibleStateImageBehavior = false;
            this.vertexTags.View = System.Windows.Forms.View.Details;
            this.vertexTags.SelectedIndexChanged += new System.EventHandler(this.vertexTags_SelectedIndexChanged);
            // 
            // hexBox1
            // 
            this.hexBox1.BackColor = System.Drawing.Color.DarkGray;
            this.hexBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox1.GroupSeparatorVisible = true;
            this.hexBox1.LineInfoOffset = ((long)(6));
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.Location = new System.Drawing.Point(0, 0);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ReadOnly = true;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(618, 460);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 4;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            this.hexBox1.SelectionStartChanged += new System.EventHandler(this.hexBox1_SelectionStartChanged);
            this.hexBox1.SelectionLengthChanged += new System.EventHandler(this.hexBox1_SelectionLengthChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1117, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txbStride,
            this.toolStripLabel1,
            this.txbOffset,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.txbShift,
            this.toolStripLabel4,
            this.txbMask});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1117, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txbStride
            // 
            this.txbStride.Name = "txbStride";
            this.txbStride.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbStride.Size = new System.Drawing.Size(100, 25);
            this.txbStride.Text = "16";
            this.txbStride.ToolTipText = "Distance between consequetive items";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Stride:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Offset";
            // 
            // txbOffset
            // 
            this.txbOffset.Name = "txbOffset";
            this.txbOffset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbOffset.Size = new System.Drawing.Size(100, 25);
            this.txbOffset.Text = "4";
            this.txbOffset.ToolTipText = "Offset from start of data to begin repeating";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel3.Text = "BitShift";
            // 
            // txbShift
            // 
            this.txbShift.Name = "txbShift";
            this.txbShift.Size = new System.Drawing.Size(100, 25);
            this.txbShift.Validating += new System.ComponentModel.CancelEventHandler(this.txbShift_Validating);
            this.txbShift.Validated += new System.EventHandler(this.txbShift_Validated);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel4.Text = "BitMask";
            // 
            // txbMask
            // 
            this.txbMask.Name = "txbMask";
            this.txbMask.Size = new System.Drawing.Size(100, 25);
            this.txbMask.Validating += new System.ComponentModel.CancelEventHandler(this.txbMask_Validating);
            this.txbMask.Validated += new System.EventHandler(this.txbMask_Validated);
            // 
            // VrtxViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 531);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer_sc1_values);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VrtxViewer";
            this.Text = "MetaViewer";
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer_sc1_values.Panel1.ResumeLayout(false);
            this.splitContainer_sc1_values.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_sc1_values)).EndInit();
            this.splitContainer_sc1_values.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer_tags_hex.Panel1.ResumeLayout(false);
            this.splitContainer_tags_hex.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tags_hex)).EndInit();
            this.splitContainer_tags_hex.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer_sc1_values;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer_tags_hex;
        private System.Windows.Forms.ListView vertexTags;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txbStride;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txbOffset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txbShift;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox txbMask;
    }
}