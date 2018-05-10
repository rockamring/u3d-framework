using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static T mInstance;
    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType<T>();
                if (mInstance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    mInstance = go.AddComponent<T>();
                    GameObject boot = GameObject.Find("Boot");
                    if (boot == null)
                    {
                        boot = new GameObject("Boot");
                        DontDestroyOnLoad(boot);
                    }
                    go.transform.parent = boot.transform;
                    DontDestroyOnLoad(go);
                }
            }
            return mInstance;
        }
    }
    public virtual void Init()
    {

    }
    public virtual void Dispose()
    {

    }
}