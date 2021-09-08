using UnityEngine;

namespace xOrfe.Utilities
{
    public class SingletonUtility<T> : MonoBehaviour where T: SingletonUtility<T>
    {
        private static volatile T instance = null;

        public static T Instance
        {
            get => return instance;
            protected set => instance = value;
        }
        private void OnEnable()
        {
            if (_instance == null)
            {
                _instance = (T)this;
            }
        }
        private void OnDisable()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
