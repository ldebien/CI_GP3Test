using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EditorBuilder
{
    [MenuItem("Build/Full")]
    private static void BuildFull1()
    {
    }

    [MenuItem("Build/Free")]
    private static void BuildFree1()
    {
    }

    [MenuItem("Build/ALL")]
    private static void BuildAll()
    {
        string locationPathName = Application.dataPath.Replace("/Assets", "/Builds");
        string filename = "TestBuild.exe";
        BuildTarget target = BuildTarget.StandaloneWindows64;
        locationPathName += "/" + target.ToString();
        System.IO.Directory.CreateDirectory(locationPathName);

        BuildPipeline.BuildPlayer(
            GetEnableScenesName(),
            locationPathName + "/" + filename,
            target,
            BuildOptions.None);
    }

    public static string[] GetEnableScenesName()
    {
        EditorBuildSettingsScene[] buildSettinsScenes = EditorBuildSettings.scenes;
        List<string> enableSceneName = new List<string>();
        foreach (EditorBuildSettingsScene s in buildSettinsScenes)
            if (s.enabled)
                enableSceneName.Add(s.path);

        return enableSceneName.ToArray();
    }
}