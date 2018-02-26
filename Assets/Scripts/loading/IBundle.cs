using UnityEngine;

namespace loading
{
    public interface IBundle
    {
        T LoadAsset<T>(string assetName) where T : Object;
    }
}