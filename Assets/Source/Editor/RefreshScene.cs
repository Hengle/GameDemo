using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class RefreshScene : Editor {

    private static readonly string scenePath = "Scenes";
    [MenuItem("Tool/RefreshScene")]
    static void RefreshAllScene()
    {
        string path = Path.Combine(Application.dataPath, scenePath);
        string[] files = Directory.GetFiles(path, "*.unity", SearchOption.AllDirectories);

        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[files.Length];
        for (int i = 0; i < files.Length; ++i)
        {
            //int index = files[i].LastIndexOf("Assets");
            //if (index <= 0)
            //{
            //    continue;
            //}
            //Debug.LogError(index);
            //string scenePath = files[i].Substring(index + 7);
            string scenePath = files[i];

            scenes[i] = new EditorBuildSettingsScene(scenePath, true);
        }

        EditorBuildSettings.scenes = scenes;
    }

}
