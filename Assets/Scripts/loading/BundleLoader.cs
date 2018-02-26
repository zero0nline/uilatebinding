using System.Collections.Generic;
using System.IO;
using settings;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace loading
{
    public class BundleLoader
    {
        private readonly Dictionary<string, IBundle> _loadedBundles = new Dictionary<string, IBundle>();

        public IBundle GetBundle(string bundleName)
        {
            IBundle bundle;

#if UNITY_EDITOR
            if (Settings.ProjectSettingsInstance.ResourcesMode == ResourcesMode.Development)
            {
                var objects = new List<Object>();
                var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundle(bundleName);

                foreach (var assetPath in assetPaths)
                {
                    var asset = AssetDatabase.LoadMainAssetAtPath(assetPath);
                    objects.Add(asset);
                }

                bundle = new SimulatedBundle(objects);
                return bundle;
            }
#endif

            var bundlePath = Directory.GetParent(Application.dataPath) + @"\Bundles\" + bundleName;
            if (_loadedBundles.ContainsKey(bundlePath)) return _loadedBundles[bundlePath];

            bundle = new Bundle(AssetBundle.LoadFromFile(bundlePath));
            _loadedBundles[bundlePath] = bundle;

            return bundle;
        }
    }
}