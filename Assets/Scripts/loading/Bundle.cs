using UnityEngine;

namespace loading
{
    public class Bundle : IBundle
    {
        private readonly AssetBundle _assetBundle;

        public Bundle(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;
        }

        public T LoadAsset<T>(string assetName) where T : Object
        {
            return _assetBundle.LoadAsset<T>(assetName);
        }
    }
}