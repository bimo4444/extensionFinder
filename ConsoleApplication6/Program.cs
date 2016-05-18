using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine eng = new Engine("d:\\2", ".dll");
            Console.WriteLine("press enter");
            Console.ReadLine();
            eng.Help("d:\\1");
            Console.WriteLine("finished");
            Console.ReadLine();
        }
    }
    class Engine
    {
        string targetPath, extension;
        public Engine(string targetPath, string extension)
        {
            this.targetPath = targetPath;
            this.extension = extension;
        }
        public void Help(string sourcePath)
        {
            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            foreach (FileSystemInfo i in infos)
            {
                string ss = Path.Combine(sourcePath, i.ToString());
                if (i is DirectoryInfo)
                    Help(ss);
                if (i is FileInfo)
                {
                    if (Path.GetExtension(sourcePath) == i.ToString())
                        File.Copy(ss, Path.Combine(targetPath, i.ToString()));
                } 
            }
        }
    }
}
