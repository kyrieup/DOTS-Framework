using UnityEditor;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class EditorTool
{
    [MenuItem("Assets/CustomTool/MergeSprite")]
    public static void MergeSprite()
    {
        string[] spriteGUIDs = Selection.assetGUIDs;
        if (spriteGUIDs == null || spriteGUIDs.Length <= 1) return;
        List<string> pathList = new List<string>(spriteGUIDs.Length);
        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]);
            pathList.Add(assetPath);
        }
        pathList.Sort();

        Texture2D firstTex = AssetDatabase.LoadAssetAtPath<Texture2D>(pathList[0]);
        int unitHight = firstTex.height;
        int unitWidth = firstTex.width;

        Texture2D outputTex = new Texture2D(unitWidth * pathList.Count, unitHight);
        for (int i = 0; i < pathList.Count; i++)
        {
            Texture2D temp = AssetDatabase.LoadAssetAtPath<Texture2D>(pathList[i]);
            Color[] colors = temp.GetPixels();
            outputTex.SetPixels(i * unitWidth ,0,unitWidth, unitHight, colors);
        }
        byte[] res = outputTex.EncodeToPNG();
        File.WriteAllBytes(pathList[0].Remove(pathList[0].LastIndexOf(firstTex.name)) + "Merge.png",res);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
