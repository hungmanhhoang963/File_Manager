namespace Project1___Total_Commander
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LeftView = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.smallICon = new System.Windows.Forms.ToolStripButton();
            this.largeIcon = new System.Windows.Forms.ToolStripButton();
            this.list = new System.Windows.Forms.ToolStripButton();
            this.detail = new System.Windows.Forms.ToolStripButton();
            this.leftAddress = new System.Windows.Forms.TextBox();
            this.rightAddress = new System.Windows.Forms.TextBox();
            this.RightView = new System.Windows.Forms.ListView();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftView
            // 
            this.LeftView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftView.Location = new System.Drawing.Point(0, 132);
            this.LeftView.Margin = new System.Windows.Forms.Padding(5);
            this.LeftView.Name = "LeftView";
            this.LeftView.Size = new System.Drawing.Size(706, 600);
            this.LeftView.TabIndex = 0;
            this.LeftView.UseCompatibleStateImageBehavior = false;
            this.LeftView.Click += new System.EventHandler(this.LeftView_Click);
            this.LeftView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftView_MouseClick);
            this.LeftView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LeftView_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1300, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.moveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.NewFolderToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1");
            this.imageList1.Images.SetKeyName(1, "Back");
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallICon,
            this.largeIcon,
            this.list,
            this.detail});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1300, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // smallICon
            // 
            this.smallICon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.smallICon.Image = ((System.Drawing.Image)(resources.GetObject("smallICon.Image")));
            this.smallICon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.smallICon.Name = "smallICon";
            this.smallICon.Size = new System.Drawing.Size(29, 24);
            this.smallICon.Text = "small icon";
            this.smallICon.Click += new System.EventHandler(this.SmallICon_Click);
            // 
            // largeIcon
            // 
            this.largeIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.largeIcon.Image = ((System.Drawing.Image)(resources.GetObject("largeIcon.Image")));
            this.largeIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.largeIcon.Name = "largeIcon";
            this.largeIcon.Size = new System.Drawing.Size(29, 24);
            this.largeIcon.Text = "large icon";
            this.largeIcon.Click += new System.EventHandler(this.LargeIcon_Click);
            // 
            // list
            // 
            this.list.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.list.Image = ((System.Drawing.Image)(resources.GetObject("list.Image")));
            this.list.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(29, 24);
            this.list.Text = "List";
            this.list.Click += new System.EventHandler(this.List_Click);
            // 
            // detail
            // 
            this.detail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detail.Image = ((System.Drawing.Image)(resources.GetObject("detail.Image")));
            this.detail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(29, 24);
            this.detail.Text = "Details";
            this.detail.Click += new System.EventHandler(this.Detail_Click);
            // 
            // leftAddress
            // 
            this.leftAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.leftAddress.Location = new System.Drawing.Point(47, 94);
            this.leftAddress.Margin = new System.Windows.Forms.Padding(5);
            this.leftAddress.Name = "leftAddress";
            this.leftAddress.Size = new System.Drawing.Size(659, 34);
            this.leftAddress.TabIndex = 3;
            this.leftAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LeftAddress_KeyDown);
            // 
            // rightAddress
            // 
            this.rightAddress.Location = new System.Drawing.Point(730, 94);
            this.rightAddress.Name = "rightAddress";
            this.rightAddress.Size = new System.Drawing.Size(558, 34);
            this.rightAddress.TabIndex = 4;
            this.rightAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RightAddress_KeyDown);
            // 
            // RightView
            // 
            this.RightView.Location = new System.Drawing.Point(730, 132);
            this.RightView.Name = "RightView";
            this.RightView.Size = new System.Drawing.Size(570, 325);
            this.RightView.TabIndex = 5;
            this.RightView.UseCompatibleStateImageBehavior = false;
            this.RightView.Click += new System.EventHandler(this.RightView_Click);
            this.RightView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RightView_KeyDown);
            this.RightView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightView_MouseClick);
            this.RightView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RightView_MouseDoubleClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.MoveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 731);
            this.Controls.Add(this.RightView);
            this.Controls.Add(this.rightAddress);
            this.Controls.Add(this.leftAddress);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LeftView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Quan Ly File";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LeftView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton smallICon;
        private System.Windows.Forms.ToolStripButton largeIcon;
        private System.Windows.Forms.ToolStripButton list;
        private System.Windows.Forms.ToolStripButton detail;
        private System.Windows.Forms.TextBox leftAddress;
        private System.Windows.Forms.TextBox rightAddress;
        private System.Windows.Forms.ListView RightView;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
    }
}

