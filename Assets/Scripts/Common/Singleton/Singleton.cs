﻿
public abstract class Singleton<T> where T: Singleton<T>, new()
{
    private static T mInstance;
    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new T();
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