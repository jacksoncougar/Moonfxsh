namespace Sunfish.Forms
{
    partial class MoonfxshExplorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoonfxshExplorer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new Sunfish.TagListView();
            this.explorerLargeImages = new System.Windows.Forms.ImageList(this.components);
            this.explorerSmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.scenarioView1 = new Sunfish.Forms.ScenarioView();
            this.tinyIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new Sunfish.ToolStripBindableButton();
            //this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            //this.navigationBar1 = new Sunfish.Forms.NavigationBar();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.scenarioView1);
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 406);
            this.panel1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.AutoArrange = false;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.explorerLargeImages;
            this.listView1.Location = new System.Drawing.Point(244, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(576, 406);
            this.listView1.SmallImageList = this.explorerSmallImageList;
            this.listView1.TabIndex = 5;
            this.listView1.TileSize = new System.Drawing.Size(200, 64);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // explorerLargeImages
            // 
            this.explorerLargeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("explorerLargeImages.ImageStream")));
            this.explorerLargeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.explorerLargeImages.Images.SetKeyName(0, "Document-128.png");
            this.explorerLargeImages.Images.SetKeyName(1, "Folder-256.png");
            // 
            // explorerSmallImageList
            // 
            this.explorerSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("explorerSmallImageList.ImageStream")));
            this.explorerSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.explorerSmallImageList.Images.SetKeyName(0, "Document-128.png");
            this.explorerSmallImageList.Images.SetKeyName(1, "Folder-256.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(241, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 406);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // scenarioView1
            // 
            this.scenarioView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.scenarioView1.FullRowSelect = true;
            this.scenarioView1.HideSelection = false;
            this.scenarioView1.ImageIndex = 1;
            this.scenarioView1.ImageList = this.tinyIcons;
            this.scenarioView1.Location = new System.Drawing.Point(0, 0);
            this.scenarioView1.Mode = Sunfish.Forms.ScenarioView.DisplayMode.Hierarchical;
            this.scenarioView1.Name = "scenarioView1";
            this.scenarioView1.SelectedImageIndex = 1;
            this.scenarioView1.ShowLines = false;
            this.scenarioView1.ShowRootLines = false;
            this.scenarioView1.Size = new System.Drawing.Size(241, 406);
            this.scenarioView1.TabIndex = 3;
            this.scenarioView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.scenarioView1_AfterSelect);
            this.scenarioView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.scenarioView1_NodeMouseDoubleClick);
            // 
            // tinyIcons
            // 
            this.tinyIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tinyIcons.ImageStream")));
            this.tinyIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.tinyIcons.Images.SetKeyName(0, "Document-128.png");
            this.tinyIcons.Images.SetKeyName(1, "Folder-256.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(820, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(38, 28);
            this.toolStripButton3.Text = "fd";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // elementHost1
            // 
            //this.elementHost1.AutoSize = true;
            //this.elementHost1.Dock = System.Windows.Forms.DockStyle.Top;
            //this.elementHost1.Location = new System.Drawing.Point(0, 31);
            //this.elementHost1.Name = "elementHost1";
            //this.elementHost1.Size = new System.Drawing.Size(820, 22);
            //this.elementHost1.TabIndex = 4;
            //this.elementHost1.Text = "elementHost1";
            //this.elementHost1.Child = this.navigationBar1;
            // 
            // MoonfxshExplorer
            // 
            this.ClientSize = new System.Drawing.Size(820, 484);
            //this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MoonfxshExplorer";
            this.ShowInTaskbar = false;
            this.Text = "Moonfxsh Explorer";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ScenarioView scenarioView1;
        private TagListView listView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList explorerSmallImageList;
        private System.Windows.Forms.ImageList explorerLargeImages;
        private System.Windows.Forms.ImageList tinyIcons;
        private ToolStripBindableButton toolStripButton3;
    }
}
