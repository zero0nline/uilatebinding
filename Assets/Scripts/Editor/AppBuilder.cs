using UnityEditor;

namespace Editor
{
    public static class AppBuilder
    {
        [MenuItem("Tools/Build/Android")]
        public static void BuildAndroid()
        {
            BuildApp(BuildTarget.Android);
        }
        
        private static void BuildApp(BuildTarget target)
        {
            var options = new BuildPlayerOptions();
            options.locationPathName = "build/application.apk";

            var editorBuildSettingsScenes = EditorBuildSettings.scenes;
            var sceneCount = editorBuildSettingsScenes.Length;
            var scenes = new string[sceneCount];

            for (int i = 0; i < sceneCount; i++)
            {
                var editorSettingsScene = editorBuildSettingsScenes[i];
                if (editorSettingsScene.enabled) scenes[i] = editorSettingsScene.path;
            }

            options.scenes = scenes;
            options.target = target;
            options.options = BuildOptions.None;
            
            BuildPipeline.BuildPlayer(options);
        }
    }
}