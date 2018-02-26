using settings;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class MakeScriptableObject
    {
        [MenuItem("Assets/Create/ProjectSettings Object")]
        public static void CreateMyAsset()
        {
            ProjectSettings asset = ScriptableObject.CreateInstance<ProjectSettings>();

            AssetDatabase.CreateAsset(asset, "Assets/Settings/ProjectSettings.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}