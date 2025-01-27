using System;
using System.Diagnostics;

namespace JavaLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("jre\\bin\\java", "--module-path jre\\javafx\\lib --add-modules javafx.base,javafx.controls,javafx.graphics,javafx.web,javafx.swing --add-opens javafx.controls/com.sun.javafx.scene.control.skin=ALL-UNNAMED --add-exports javafx.base/com.sun.javafx.collections=ALL-UNNAMED -jar --add-exports java.desktop/sun.awt=ALL-UNNAMED --add-opens javafx.graphics/com.sun.glass.ui=ALL-UNNAMED .\\Silhouette.jar");
            startInfo.UseShellExecute = false; // 不使用操作系统外壳程序启动
            startInfo.CreateNoWindow = true; // 不创建新窗口
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
