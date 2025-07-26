using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<T>();
                    go.name = $"{typeof(T).Name}";
                }
            }
            return _instance;
        }
    }
}

