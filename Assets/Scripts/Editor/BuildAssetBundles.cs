using UnityEditor;

namespace Editor
{
    public static class BuildAssetBundles
    {
        [MenuItem("Tools/Build bundles")]
        public static void Build()
        {
            
            BuildPipeline.BuildAssetBundles(@"/Users/alt/Projects/Unity/uilatebinding/Bundles", 
                BuildAssetBundleOptions.ForceRebuildAssetBundle, BuildTarget.StandaloneOSX);
        }
    }
}