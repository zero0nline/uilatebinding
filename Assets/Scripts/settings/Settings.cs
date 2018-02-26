using UnityEngine;

namespace settings
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private ProjectSettings _s;
        public static ProjectSettings ProjectSettingsInstance;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            if (ProjectSettingsInstance == null) ProjectSettingsInstance = _s;
        }
    }
}