using System.Reflection;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _get;
    public static T Get
    {
        get
        {
            if (_get == null)
            {
                Object[] objects = FindObjectsOfType(typeof(T));
                if (objects.Length == 0)
                {
                    GameObject tGameObject = new GameObject();
                    _get = tGameObject.AddComponent<T>();
                    tGameObject.name = _get.GetType().Name;

                    Debug.LogWarning($"Could not find Object {typeof(T).ToString()}. Object created.");
                }
                else if (objects.Length >= 2)
                {
                    Debug.LogError($"Multiple objects found of type {typeof(T).ToString()}.");
                }
                else
                {
                    _get = (T)objects[0];
                }
            }

            return _get;
        }
    }

    public static ST GetDerived<ST>() where ST : Singleton<T>
    {
        return Get as ST;
    }

    public static T GetInstanceFromType()
    {
        return (T)typeof(T).GetProperty("Get", BindingFlags.Public | BindingFlags.Static).GetValue(null);
    }
}
