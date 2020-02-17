#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using System;
using System.Runtime.CompilerServices;

public class PostProcessLauncherCopy
{
    const string selectorPath = "selector~/ScreenSelector.exe";

    private static bool GetAttribute(string[] args, string parameterName)
    {
        var index = Array.IndexOf(args, parameterName);
        return index > 0;
    }

    private static string GetThisFilePath([CallerFilePath] string path = null)
    {
        return path;
    }

    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        var args = Environment.GetCommandLineArgs();

        if ((target == BuildTarget.StandaloneWindows || target == BuildTarget.StandaloneWindows64) && !GetAttribute(args, "-noselector"))
        {
            string dataPath = Path.Combine(Path.GetDirectoryName(pathToBuiltProject), "PersistentDataPath.txt");
            using (StreamWriter file = new StreamWriter(dataPath))
            {
                file.WriteLine(Path.Combine(Application.companyName, Application.productName));
                file.WriteLine(Path.GetFileName(pathToBuiltProject));
                foreach (var name in QualitySettings.names)
                {
                    file.WriteLine(name);
                }
            }

            var filePath = GetThisFilePath();
            var fullselectorPath = Path.Combine(Path.GetDirectoryName(filePath), selectorPath);

            File.Copy(fullselectorPath, Path.Combine(Path.GetDirectoryName(pathToBuiltProject), Path.GetFileName(selectorPath)), true);
        }
    }
}
#endif