using MyShell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project1___Total_Commander
{

    public partial class Form1 : Form
    {
        private View[] TypeView;
        private int PanelChoose;
        public Form1()
        {
            InitializeComponent();
            TypeView = new View[2];
            RightView.LargeImageList = LeftView.LargeImageList = new ImageList();
            RightView.LargeImageList.ImageSize = LeftView.LargeImageList.ImageSize = new Size(48, 48);
            RightView.LargeImageList.ColorDepth = LeftView.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;

        
            RightView.SmallImageList = LeftView.SmallImageList = new ImageList();
            RightView.SmallImageList.ColorDepth = LeftView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;

            LoadListViewLogicalDrives();



            PanelChoose = 0;
            rightAddress.Enabled = true;
            leftAddress.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void LoadListView(ref ListView lv, View type, string path)
        {
            lv.Clear();

            var listview = new ListView();
            var imagelist = new ImageList();

            imagelist.ImageSize = new Size(48, 48);


            imagelist.Images.Add(Image.FromFile("C:\\Users\\hungm\\source\\repos\\Project1 - Total-Commander\\Project1 - Total-Commander\\Images\\Back.png"));

            if (type == View.LargeIcon)
            {

                lv.View = type;
                if (!lv.LargeImageList.Images.Keys.Contains("Back"))
                {
                    lv.LargeImageList.Images.Add("Back", Image.FromFile("C:\\Users\\hungm\\source\\repos\\Project1 - Total-Commander\\Project1 - Total-Commander\\Images\\Back.png"));
                }
                lv.Items.Add(new ListViewItem()
                {
                    Text = "..",
                    ImageKey = "Back",
                    Tag = null
                });

                foreach (var item in Items(path))
                {
                    if (item is FileInfo fi)
                    {

                        if (!lv.LargeImageList.Images.Keys.Contains(fi.Name))
                        {
                            lv.LargeImageList.Images.Add(fi.Name, Shell.GetFileIcon(fi.FullName, false));
                        }
                        lv.Items.Add(new ListViewItem()
                        {
                            Text = fi.Name,
                            ImageKey = fi.Name,
                            Tag = fi
                        });
                    }
                    else if (item is DirectoryInfo di)
                    {
                        if (!lv.LargeImageList.Images.Keys.Contains("Folder"))
                        {
                            lv.LargeImageList.Images.Add("Folder", Shell.GetFolderIcon(false));
                        }

                        lv.Items.Add(new ListViewItem()
                        {
                            Text = di.Name,
                            ImageKey = "Folder",
                            Tag = di
                        });

                    }
                }
            }
            else if (type == View.List)
            {

                lv.View = type;
                foreach (var item in Items(path))
                {
                    if (item is FileInfo fi)
                    {
                        if (!lv.SmallImageList.Images.Keys.Contains(fi.Name))
                        {
                            lv.SmallImageList.Images.Add(fi.Name, Shell.GetFileIcon(fi.FullName, true));
                        }
                        lv.Items.Add(new ListViewItem()
                        {
                            Text = fi.Name,
                            ImageKey = fi.Name,
                            Tag = fi
                        });

                    }
                    else if (item is DirectoryInfo di)
                    {
                        if (!lv.SmallImageList.Images.Keys.Contains("Folder"))
                        {
                            lv.SmallImageList.Images.Add("Folder", Shell.GetFolderIcon(true));
                        }

                        lv.Items.Add(new ListViewItem()
                        {
                            Text = di.Name,
                            ImageKey = "Folder",
                            Tag = di
                        });

                    }
                }

            }
            else
            {
                LeftView.Columns.Add("Name");
                LeftView.Columns.Add("Ext");
                LeftView.Columns.Add("Size");
                LeftView.Columns.Add("Date");
                LeftView.Columns.Add("Attr");
                lv.View = type;
                foreach (var item in Items(path))
                {

                    if (item is FileInfo fi)
                    {
                        string ext = fi.Name;
                        if (!lv.SmallImageList.Images.Keys.Contains(ext))
                        {
                            lv.SmallImageList.Images.Add(ext, Shell.GetFileIcon(fi.FullName, true));
                        }
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageKey = fi.Name;
                        lvi.Text = fi.Name.Substring(0, fi.Name.IndexOf('.') == -1 ? fi.Name.Length : fi.Name.IndexOf('.'));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = fi.Extension.Contains('.') ? fi.Extension.Remove(0, 1) : fi.Extension });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = fi.Length.ToString()
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = fi.LastAccessTime.ToString()
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = fi.Attributes.ToString()
                        });
                        lvi.Tag = fi;
                        lv.Items.Add(lvi);
                    }
                    else if (item is DirectoryInfo di)
                    {
                        if (!lv.SmallImageList.Images.Keys.Contains("Folder"))
                        {
                            lv.SmallImageList.Images.Add("Folder", Shell.GetFolderIcon(true));
                        }
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageKey = "Folder";
                        lvi.Text = di.Name;
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = " "
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = "<DIR>"
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = di.LastAccessTime.ToString()
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = di.Attributes.ToString()
                        });
                        lvi.Tag = di;
                        lv.Items.Add(lvi);
                    }
                }

            }
        }

        private void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception) { } // Ignore all exceptions
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                try
                {
                    di.Delete();
                }
                catch (Exception) { } // Ignore all exceptions
            }
            
        }

        private void SmallICon_Click(object sender, EventArgs e)
        {
            TypeView[PanelChoose] = View.SmallIcon;
            if (PanelChoose == 0)
            {
                LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
            }
            else
            {
                LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
            }
        }
        private void LargeIcon_Click(object sender, EventArgs e)
        {
            TypeView[PanelChoose] = View.LargeIcon;
            if (PanelChoose == 0)
            {
                LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
            }
            else
            {
                LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
            }
        }

        private void List_Click(object sender, EventArgs e)
        {
            TypeView[PanelChoose] = View.List;
            if (PanelChoose == 0)
            {
                LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
            }
            else
            {
                LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
            }
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            TypeView[PanelChoose] = View.Details;
            if (PanelChoose == 0)
            {
                LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
            }
            else
            {
                LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
            }
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public static FileSystemInfo GetParent(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo Folder = new DirectoryInfo(path);
                return Folder.Parent;
            }
            else if (File.Exists(path))
            {
                FileInfo File = new FileInfo(path);
                return File.Directory.Parent;
            }
            return null;
        }
        public static List<FileSystemInfo> Items(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo Folder = new DirectoryInfo(path);
                List<FileSystemInfo> Result = new List<FileSystemInfo>();
                foreach (var item in Folder.GetFileSystemInfos())
                {
                    if (!item.Attributes.HasFlag(FileAttributes.System))
                    {
                        Result.Add(item);
                    }
                }
                return Result;
            }
            else if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                if (!file.Attributes.HasFlag(FileAttributes.System))
                {
                    return new List<FileSystemInfo>()
                    {
                        file as FileSystemInfo,
                    };
                }
            }
            return null;
        }
      
       

        private void LeftAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadListView(ref LeftView, TypeView[1], leftAddress.Text);
            }
        }

        private void RightAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadListView(ref RightView, TypeView[1], rightAddress.Text);
            }
        }
      
        private void LeftView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lv = sender as ListView;
            var lvi = lv.HitTest(e.X, e.Y).Item;

            if (lvi != null)
            {
                if (lvi == lv.Items[0])
                {
                    if (PanelChoose == 0)
                    {
                        var Back = GetParent(leftAddress.Text);
                        if (Back == null) { return; }
                        LoadListView(ref lv, TypeView[PanelChoose], Back.FullName);
                        leftAddress.Text = Back.FullName;
                    }
                    else
                    {
                        var Back = GetParent(rightAddress.Text);
                        if (Back == null) { return; }
                        LoadListView(ref lv, TypeView[PanelChoose], Back.FullName);
                        rightAddress.Text = Back.FullName;
                    }

                }

                else
                {
                    var fsi = lvi.Tag as FileSystemInfo;
                    if (!(fsi is FileInfo))
                    {
                        lv.Clear();
                        var folderInfo = fsi as DirectoryInfo;
                        LoadListView(ref lv, TypeView[PanelChoose], folderInfo.FullName);
                        if (PanelChoose == 0)
                        {
                            leftAddress.Text = folderInfo.FullName;
                        }
                        else 
                        {
                            rightAddress.Text = folderInfo.FullName;
                        }
                    }
                    else
                    {
                        try { Process.Start(fsi.FullName); }
                        catch
                        {
                            MessageBox.Show("Error", "No File Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }
        private void RightView_MouseDoubleClick(object sender, MouseEventArgs e)

        {
            var lv = sender as ListView;
            var lvi = lv.HitTest(e.X, e.Y).Item;

            if (lvi != null)
            {
                if (lvi == lv.Items[0])
                {
                    if (PanelChoose == 1)
                    {
                        var Back = GetParent(rightAddress.Text);
                        if (Back == null) { return; }
                        LoadListView(ref lv, TypeView[PanelChoose], Back.FullName);
                        rightAddress.Text = Back.FullName;
                    }
                    else
                    {
                        var Back = GetParent(leftAddress.Text);
                        if (Back == null) { return; }
                        LoadListView(ref lv, TypeView[PanelChoose], Back.FullName);
                        leftAddress.Text = Back.FullName;
                    }

                }

                else
                {
                    var fsi = lvi.Tag as FileSystemInfo;
                    if (!(fsi is FileInfo))
                    {
                        lv.Clear();
                        var folderInfo = fsi as DirectoryInfo;

                        LoadListView(ref lv, TypeView[PanelChoose], folderInfo.FullName);

                        if (PanelChoose == 1)
                        {
                            rightAddress.Text = folderInfo.FullName;
                        }
                        else
                        {
                            leftAddress.Text = folderInfo.FullName;
                        }
                    }
                    else
                    {
                        try { Process.Start(fsi.FullName); }
                        catch
                        {
                            MessageBox.Show("Error", "No File Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }
        private void RightView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadListView(ref RightView, TypeView[1], rightAddress.Text);
            }
        }

        private void LeftView_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right) {
                PanelChoose = 0;
                leftAddress.Enabled = true;
            }
        }
        private void RightView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PanelChoose = 1;
                rightAddress.Enabled = true;
            }
        }
        private void LeftView_Click(object sender, EventArgs e)
        {
            PanelChoose = 0;
            leftAddress.Enabled = true;
            rightAddress.Enabled = false;
        }

        private void RightView_Click(object sender, EventArgs e)
        {
            PanelChoose = 1;
            leftAddress.Enabled = false;
            rightAddress.Enabled = true;
        }

        
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RightView.SelectedItems.Count > 0 || LeftView.SelectedItems.Count > 0)
            {
                var item = PanelChoose == 1 ? RightView.SelectedItems[0].Tag : LeftView.SelectedItems[0].Tag;
                if (item is FileInfo fi)
                {
                    Process.Start("notepad.exe", fi.FullName);
                }
                else
                {
                    MessageBox.Show("No file selected", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No file selected", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RightView.SelectedItems.Count > 0 || LeftView.SelectedItems.Count > 0)
            {

                if (PanelChoose == 0)
                {
                    var item = LeftView.SelectedItems[0].Tag;
                    if (item is FileInfo fi && item != null)
                    {
                        var Result = MessageBox.Show("Do you really want to remove the selected file " + fi.Name + " to the recycle bin?", "Total Commander", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            try
                            {
                                if (File.Exists(Path.Combine(leftAddress.Text, item.ToString())))
                                {
                                    File.Delete(Path.Combine(leftAddress.Text, item.ToString()));
                                    MessageBox.Show("File Deleted", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
                                }
                            }
                            catch (IOException ioExp)
                            {
                                MessageBox.Show(ioExp.Message, "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (Result == DialogResult.No)
                        {
                            LoadListView(ref LeftView, TypeView[PanelChoose], fi.FullName);
                        }
                        else
                        {

                        }
                    }
                    else if (item is DirectoryInfo di)
                    {

                        var Result = MessageBox.Show("Do you really want to remove the selected directory " + di.Name + " to the recycle bin?", "Total Commander", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (Result == DialogResult.Yes)
                        {

                            ClearFolder(di.FullName);

                            MessageBox.Show("Directory Deleted", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
                        }

                    }
                }
                else
                {
                    var item = RightView.SelectedItems[0].Tag;
                    if(item == null)
                    {
                        MessageBox.Show("No file selected", "Total Commander", MessageBoxButtons.OK);
                    }
                    if (item is FileInfo fi && item != null)
                    {
                        var Result = MessageBox.Show("Do you really want to remove the selected file " + fi.Name + " to the recycle bin?", "Total Commander", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            try
                            {
                                if (File.Exists(Path.Combine(rightAddress.Text, item.ToString())))
                                {
                                    File.Delete(Path.Combine(rightAddress.Text, item.ToString()));
                                    MessageBox.Show("File Deleted", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
                                }
                            }
                            catch (IOException ioExp)
                            {
                                MessageBox.Show(ioExp.Message, "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (Result == DialogResult.No)
                        {
                            LoadListView(ref RightView, TypeView[PanelChoose], fi.FullName);
                        }
                        else
                        {

                        }
                    }
                    else if (item is DirectoryInfo di)
                    {

                        var Result = MessageBox.Show("Do you really want to remove the selected directory " + di.Name + " to the recycle bin?", "Total Commander", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (Result == DialogResult.Yes)
                        {

                            ClearFolder(di.FullName);

                            MessageBox.Show("Directory Deleted", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("No file selected", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadListViewLogicalDrives()
        {
            LoadListView(ref LeftView, View.LargeIcon, "C:\\");
            LoadListView(ref RightView, View.LargeIcon, "C:\\");

            leftAddress.Text = "C:\\";
            rightAddress.Text = "C:\\";

        }

      public static class DefaultIcons
        {
            private static readonly Lazy<Icon> _lazyFolderIcon = new Lazy<Icon>(FetchIcon, true);

            public static Icon FolderLarge
            {
                get { return _lazyFolderIcon.Value; }
            }

            private static Icon FetchIcon()
            {
                var tmpDir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())).FullName;
                var icon = ExtractFromPath(tmpDir);
                Directory.Delete(tmpDir);
                return icon;
            }

            private static Icon ExtractFromPath(string path)
            {
                SHFILEINFO shinfo = new SHFILEINFO();
                SHGetFileInfo(
                    path,
                    0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
                    SHGFI_ICON | SHGFI_LARGEICON);
                return System.Drawing.Icon.FromHandle(shinfo.hIcon);
            }

            //Struct used by SHGetFileInfo function
            [StructLayout(LayoutKind.Sequential)]
            private struct SHFILEINFO
            {
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            };

            [DllImport("shell32.dll")]
            private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

            private const uint SHGFI_ICON = 0x100;
            private const uint SHGFI_LARGEICON = 0x0;
            private const uint SHGFI_SMALLICON = 0x000000001;
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("New folder(directory)", "Total Commander", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
                if (PanelChoose == 0)
                {
                    string folderName = @"New Folder";
                    
                    System.IO.Directory.CreateDirectory(leftAddress.Text + "\\" + folderName);
                    
                    LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);

                }
                else
                {
                    string folderName = @"New Folder";

                    System.IO.Directory.CreateDirectory(rightAddress.Text + "\\" + folderName);

                    LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
                }
            }
        }

        private string GetIndexedFilePath(string path, int index)
        {
            var directoryName = Path.GetDirectoryName(path);
            var oldFileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            var indexedFileName = String.Format("{0}_{1}{2}", oldFileName, index, extension);
            return Path.Combine(directoryName, indexedFileName);
        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RightView.SelectedItems.Count > 0 || LeftView.SelectedItems.Count > 0)
            {
                if(PanelChoose == 0)
                {
                    var item = LeftView.SelectedItems[0].Tag;
                    if(item is FileInfo fi)
                    {
                        
                      var Result =  MessageBox.Show("Copy 1 file(s) to " + rightAddress.Text,"Total Commander", MessageBoxButtons.YesNo);
                      if(Result == DialogResult.Yes)
                        {

                            string fileName = fi.FullName;
                            fi.Attributes = FileAttributes.Normal;
                            File.Copy(fileName, rightAddress.Text + "\\" + Path.GetFileName(fileName));

                            LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
                        }
                    }
                    else if (item is DirectoryInfo di)
                    {
                        var Result = MessageBox.Show("Copy 1 (s) to " + rightAddress.Text, "Total Commander", MessageBoxButtons.YesNo);
                        if (Result == DialogResult.Yes)
                        {
                            if(PanelChoose == 0)
                            { 
                                System.IO.Directory.CreateDirectory(rightAddress.Text + "\\" + di.Name + "-Copy");
                                string CopyPath = rightAddress.Text + "\\" + di.Name + "-Copy";
                                Copy(di.FullName, CopyPath);
                                LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
                            } 
                        }
                    } 
                }
                else
                {
                    var item = RightView.SelectedItems[0].Tag;
                    if (item is FileInfo fi)
                    {

                        var Result = MessageBox.Show("Copy 1 file(s) to " + leftAddress.Text, "Total Commander", MessageBoxButtons.YesNo);
                        if (Result == DialogResult.Yes)
                        {

                            string fileName = fi.FullName;
                            fi.Attributes = FileAttributes.Normal;
                            File.Copy(fileName, leftAddress.Text + "\\" + Path.GetFileName(fileName));

                            LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
                        }
                    }
                    else if (item is DirectoryInfo di)
                    {
                        var Result = MessageBox.Show("Copy 1 (s) to " + leftAddress.Text, "Total Commander", MessageBoxButtons.YesNo);
                        if (Result == DialogResult.Yes)
                        {
                            if (PanelChoose == 1)
                            {
                                System.IO.Directory.CreateDirectory(leftAddress.Text + "\\" + di.Name + "-Copy");
                                string CopyPath = leftAddress.Text + "\\" + di.Name + "-Copy";
                                Copy(di.FullName, CopyPath);
                                LoadListView(ref LeftView, TypeView[PanelChoose], leftAddress.Text);
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("No file selected", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Commander \n MSSV: 1753069 \n Name: Hoang Hung Manh", "About", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try { Process.Start("C:\\Users\\hungm\\source\\repos\\Project1 - Total-Commander\\Project1 - Total-Commander\\How to use\\1.pdf"); }
            catch
            {
                MessageBox.Show("Error", "No File Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RightView.SelectedItems.Count > 0 || LeftView.SelectedItems.Count > 0)
            {
                if (PanelChoose == 0)
                {
                    var item = LeftView.SelectedItems[0].Tag;
                    if (item is FileInfo fi)
                    {
                        var Result = MessageBox.Show("Copy 1 file(s) to " + rightAddress.Text, "Total Commander", MessageBoxButtons.YesNo);
                        if (Result == DialogResult.Yes)
                        {
                            string sc = System.IO.Path.Combine(leftAddress.Text, fi.Name);
                            string de = System.IO.Path.Combine(rightAddress.Text, fi.Name);
                            string sourceFile = sc;
                            string destinationFile = de;

                            System.IO.File.Move(sourceFile, destinationFile);
                            System.IO.Directory.Move(leftAddress.Text, rightAddress.Text);
                            LoadListView(ref RightView, TypeView[PanelChoose], rightAddress.Text);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No file selected", "Total Commander", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
