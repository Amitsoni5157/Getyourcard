using UnityEngine;

/* Written by Amit Sonu <amit.soni5157@gmail.com>, April 2022 */

//namespace MemoryPuzzle {
    /// <summary>
    /// The following class will make any class that inherits from it a singleton automatically
    /// </summary>   
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        protected static T instance;

        //Returns the instance of this singleton.
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null)
                    {
                       // Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                    }
                }
                return instance;
            }
        }
    }
//}

