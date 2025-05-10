using System.Collections;
using UnityEngine;

namespace Utils
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner _instance;
        
        public static CoroutineRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var obj = new GameObject("CoroutineRunner");
                    _instance = obj.AddComponent<CoroutineRunner>();
                    DontDestroyOnLoad(obj); // Optional: persist between scenes
                }
                return _instance;
            }
        }
        
        public static Coroutine Run(IEnumerator coroutine)
        {
            return Instance.StartCoroutine(coroutine);
        }
    }
}
