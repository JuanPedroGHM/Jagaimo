using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateScriptableObjects : Editor {

    [MenuItem("Assets/Create/Hero")]
    public static void CreateAsset ()
    {
        CreateAsset<Hero> ();
    }


    public static void CreateAsset<T> () where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T> ();

        string path = AssetDatabase.GetAssetPath (Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension (path) != "")
        {
            path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/New " + typeof(T).ToString() + ".asset");

        AssetDatabase.CreateAsset (asset, assetPathAndName);

        AssetDatabase.SaveAssets ();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }
}
