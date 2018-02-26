using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace loading
{
    public class SimulatedBundle : IBundle
    {
        private readonly List<Object> _objects;

        public SimulatedBundle(List<Object> objects)
        {
            _objects = objects;
        }

        public T LoadAsset<T>(string assetName) where T : Object
        {
            return (T) _objects.Where((o, i) => o is T).First();
        }
    }
}