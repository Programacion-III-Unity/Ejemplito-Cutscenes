using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildProject : MonoBehaviour{

    public static void BuildWindows()
    {

        BuildPipeline.BuildPlayer(
            new string[] { "Assets\\Scenes\\Gameplay\\GamePlay.unity" },
            ".\\build\\Juego.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }

}
