using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;

namespace LandEvaluationBll
{
    public class BindingDataTable
    {
        //获取根目录表
        public static DataTable GetRootPathDataTable(string RootPathesString, char separator)
        {
            DataTable rootPathTable = new DataTable();
            //初始化列
            rootPathTable.Columns.Add("ID", typeof(int));
            rootPathTable.Columns.Add("RootPath", typeof(string));
            string[] rootPathes = RootPathesString.Split(new char[] { separator });
            foreach (string rootPath in rootPathes)
                AddRowForRootPathDataTable(rootPath, ref rootPathTable);
            return rootPathTable;
        }
        //为根目录表添加行
        public static void AddRowForRootPathDataTable(string RootPath, ref DataTable rootPathTable)
        {
            if (Directory.Exists(RootPath))
            {
                DataRow row = rootPathTable.NewRow();
                row["ID"] = rootPathTable.Rows.Count;
                row["RootPath"] = RootPath;
                rootPathTable.Rows.Add(row);
            }
        }

        //获取指定目录下文件列表
        public static DataTable GetFileListDataTable(string RootPath)
        {
            DataTable fileListTable = new DataTable();
            //初始化列
            fileListTable.Columns.Add("ID", typeof(int));                //节点编号
            fileListTable.Columns.Add("ParentID", typeof(int));      //父节点编号
            fileListTable.Columns.Add("Name", typeof(string));      //名称
            fileListTable.Columns.Add("ExtName", typeof(string)); //后缀名,文件夹为空
            fileListTable.Columns.Add("ImageIndex", typeof(int)); //文件图标编号
            fileListTable.Columns.Add("FilePath", typeof(string));   //文件路径

            if (Directory.Exists(RootPath))
            {
                DirectoryInfo dir = new DirectoryInfo(RootPath);
                int id = 0;
                ListFiles(dir, ref fileListTable, ref id);
                return fileListTable;
            }
            return fileListTable;
        }
        //递归遍历路径中的所有文件夹及文件
        public static void ListFiles(FileSystemInfo info, ref DataTable dt, ref int id)
        {
            try
            {
                //目录信息不存在
                if (!info.Exists)
                    return;
                DirectoryInfo dir = info as DirectoryInfo;
                //不是目录
                if (dir == null)
                    return;
                int pid = id;       //记录当前id，作为pid

                FileSystemInfo[] files = dir.GetFileSystemInfos();
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i] as FileInfo;
                    id++;
                    //是文件
                    if (file != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ID"] = id;
                        dr["ParentID"] = pid;
                        dr["Name"] = Path.GetFileName(file.FullName);  //文件名 
                        dr["ExtName"] = file.Extension.Substring(1, file.Extension.Length - 1).ToLower();      //拓展名，不包含“.”
                        dr["ImageIndex"] = GetImageIndexByExtName(dr["ExtName"].ToString());
                        dr["FilePath"] = file.FullName;         //全路径
                        dt.Rows.Add(dr);
                    }
                    //对于子目录，进行递归调用
                    else
                    {
                        DirectoryInfo di = files[i] as DirectoryInfo;

                        DataRow dr = dt.NewRow();
                        dr["ID"] = id;
                        dr["ParentID"] = pid;
                        dr["Name"] = di.Name;  //文件名 
                        dr["ExtName"] = "";      //拓展名
                        dr["ImageIndex"] = 0;
                        dr["FilePath"] = di.FullName;
                        dt.Rows.Add(dr);

                        ListFiles(files[i], ref dt, ref id);
                    }
                }
            }
            catch
            {
            }
        }
        //根据后缀名获取图标编号
        public static int GetImageIndexByExtName(string ExtName)
        {
            int imageIndex;
            switch (ExtName)
                {
                    case "doc":
                    case "docx": 
                        imageIndex = 1; 
                        break;
                    case "xls":
                    case "xlsx": 
                        imageIndex = 2; 
                        break;
                    case "ppt":
                    case "pptx": 
                        imageIndex = 3; 
                        break;
                    case "pdf":
                        imageIndex = 4; 
                        break;
                    case "jpg":
                    case "png":
                    case "bmp":
                    case "tif":
                    case "tiff": 
                        imageIndex = 5; 
                        break;
                    case "mdb":
                    case "gdb":
                    case "access": 
                        imageIndex = 6; 
                        break;
                    case "ini":
                    case "config": 
                        imageIndex = 7; 
                        break;
                    case "exe":
                        imageIndex = 8; 
                        break;
                    case "mxd":
                        imageIndex = 9;
                        break;
                    default:
                        imageIndex = 10; 
                        break;
                }
            return imageIndex;
        }
    }
}
