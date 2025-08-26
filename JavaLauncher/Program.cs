using System;
using System.Diagnostics;
using System.IO;

namespace JavaLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string arguments = "--module-path jre\\javafx\\lib --add-modules javafx.base,javafx.controls,javafx.graphics,javafx.web,javafx.swing --add-opens javafx.controls/com.sun.javafx.scene.control.skin=ALL-UNNAMED --add-exports javafx.base/com.sun.javafx.collections=ALL-UNNAMED --add-exports java.desktop/sun.awt=ALL-UNNAMED -jar .\\ImageTrans.jar";

            if (args.Length > 0)
            {
                arguments += " ";
                foreach (string arg in args)
                {
                    arguments += "\"" + arg + "\" ";
                }
                arguments = arguments.TrimEnd(); // 移除末尾多余的空格
            }

            ProcessStartInfo startInfo = new ProcessStartInfo("jre\\bin\\java", arguments);
            startInfo.UseShellExecute = false; // 不使用操作系统外壳程序启动
            startInfo.CreateNoWindow = true; // 不创建新窗口
            startInfo.WorkingDirectory = workDir;

            try
            {
                Process process = Process.Start(startInfo);
                process.WaitForExit(); // 如果需要，等待程序执行完成
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误: " + ex.Message);
            }
        }
    }
}