using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public static class ModelTC
    {
        public static CopyStatus copyStatus = CopyStatus.None;
        public static List<DriveInfo> Drives()
        {
            return DriveInfo.GetDrives().ToList();
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

        public static FileSystemInfo GetParent(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo Folder = new DirectoryInfo(path);
                return Folder.Parent;
            }
            else if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                return file.Directory.Parent;
            }
            return null;
        }

        public static void Copy(string src, string des)
        {
            if (copyStatus == CopyStatus.Stop)
            {
                return;
            }
            if (File.Exists(des + "\\" + Path.GetFileName(src)))
            {
                if (copyStatus == CopyStatus.OverwriteAll)
                {
                    File.Delete(des + "\\" + Path.GetFileName(src));
                }
                else if (copyStatus == CopyStatus.SkipAll)
                {
                    return;
                }
                else
                {
                    var cpMessFrm = new CopyMesseageForm(src, des);
                    cpMessFrm.ShowDialog();
                    switch (copyStatus)
                    {
                        case CopyStatus.Overwrite:
                        case CopyStatus.OverwriteAll:
                            File.Delete(des + "\\" + Path.GetFileName(src));
                            break;
                        case CopyStatus.Skip:
                        case CopyStatus.SkipAll:
                        case CopyStatus.Stop:
                            return;
                    }
                }
            }
            if (Directory.Exists(src))
            {
                Directory.CreateDirectory(des + @"\" + Path.GetFileName(src));
                DirectoryInfo di = new DirectoryInfo(des + @"\" + Path.GetFileName(src));
                di.Attributes = (new DirectoryInfo(src)).Attributes;
                des += @"\" + Path.GetFileName(src);
                foreach (string dir in Directory.GetFileSystemEntries(src))
                {
                    Copy(dir, des);
                }
            }
            else if (File.Exists(src))
            {
                File.Copy(src, des + @"\" + Path.GetFileName(src));
                File.SetAttributes(des, (new FileInfo(src)).Attributes);
            }
        }

        public static void MoveAndRename(string src, string des)
        {
            if (IsRename(src, des))
            {
                if (Directory.Exists(src))
                {
                    //Directory.Move();
                }
            }
            else
            {
                Copy(src, des);
                Delete(src);
            }
        }

        private static bool IsRename(string src, string des)
        {
            DirectoryInfo di = new DirectoryInfo(des);
            foreach (var item in di.GetFileSystemInfos())
            {
                if (di.FullName.Equals(item.FullName))
                {
                    return true;
                }
            }
            return false;
        }

        private static void Delete(string src)
        {
            if (File.Exists(src))
            {
                File.Delete(src);
            }
            else if (Directory.Exists(src))
            {
                Directory.Delete(src, true);
            }
        }
    }
}
