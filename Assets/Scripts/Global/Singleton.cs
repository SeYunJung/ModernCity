using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.Log($"�̱��� �ν��Ͻ� '{typeof(T)}'�� �̹� �����Ǿ����ϴ�. null�� ��ȯ�մϴ�.");
                return null;
            }

            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T)); // scene���� ��������

                if (FindObjectsOfType(typeof(T)).Length > 1) // scene�� ���� ���� �ִٸ� 
                {
                    Debug.LogError($"���� �߻� - �̱��� �ν��Ͻ��� 1�� �̻��� �� �����ϴ�.");
                    return instance;
                }

                if (instance == null)
                {
                    GameObject go = new GameObject();
                    instance = go.AddComponent<T>();
                    go.name = $"{typeof(T).Name}";
                }
            }

            return instance;
        }
    }

    protected virtual void OnDestroy() // ��ü �����ƴٸ� �����ϴ� �޼���
    {
        applicationIsQuitting = true;
    }
}

