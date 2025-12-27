using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace JavaLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDir = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            string baseArguments = "--module-path jre\\javafx\\lib --add-modules javafx.base,javafx.controls,javafx.graphics,javafx.web,javafx.swing --add-opens javafx.controls/com.sun.javafx.scene.control.skin=ALL-UNNAMED --add-exports javafx.base/com.sun.javafx.collections=ALL-UNNAMED --add-exports java.desktop/sun.awt=ALL-UNNAMED --add-exports java.desktop/com.sun.imageio.plugins.jpeg=ALL-UNNAMED --add-exports java.desktop/com.sun.imageio.plugins.png=ALL-UNNAMED --add-exports java.desktop/com.sun.imageio.plugins.bmp=ALL-UNNAMED --add-exports java.desktop/com.sun.imageio.plugins.gif=ALL-UNNAMED --add-exports java.desktop/com.sun.imageio.plugins.wbmp=ALL-UNNAMED --add-exports java.desktop/com.sun.imageio.spi=ALL-UNNAMED --add-opens java.desktop/com.sun.imageio.plugins.jpeg=ALL-UNNAMED -jar .\\ImageTrans.jar";

            string arguments = baseArguments;
            if (args.Length > 0)
            {
                // 简单安全的参数拼接方式
                arguments += " " + string.Join(" ", args.Select(arg => QuoteArgument(arg)));
            }

            ProcessStartInfo startInfo = new ProcessStartInfo("jre\\bin\\java", arguments);
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = workDir;

            try
            {
                Process process = Process.Start(startInfo);
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误: " + ex.Message);
            }
        }

        /// <summary>
        /// 简单的参数引号处理
        /// </summary>
        private static string QuoteArgument(string arg)
        {
            // 如果参数包含空格，就用引号包裹
            if (arg.Contains(" "))
                return "\"" + arg + "\"";
            return arg;
        }
    }
}