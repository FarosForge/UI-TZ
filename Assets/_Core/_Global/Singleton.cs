using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance;

    private void Awake()
    {
        instance = this as T;
    }
}
