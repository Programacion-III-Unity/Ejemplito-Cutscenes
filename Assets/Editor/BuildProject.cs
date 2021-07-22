using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildProject : MonoBehaviour{
    public static string version = System.Environment.GetEnvironmentVariable("projectVersion");
    public static string gameName = System.Environment.GetEnvironmentVariable("gameName");

    public static void BuildWindows64()
    {
        string buildPath = ".\\build\\" + version + "\\Win64\\" + gameName + ".exe";
        BuildPipeline.BuildPlayer(
            new string[] { "Assets\\Scenes\\Gameplay\\GamePlay.unity" },
            buildPath,
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
    public static void BuildWindows32()
    {
        string buildPath = ".\\build\\" + version + "\\Win32\\" + gameName + ".exe";
        BuildPipeline.BuildPlayer(
            new string[] { "Assets\\Scenes\\Gameplay\\GamePlay.unity" },
            buildPath,
            BuildTarget.StandaloneWindows,
            BuildOptions.None
        );
    }

}
