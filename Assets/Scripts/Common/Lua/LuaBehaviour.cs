using System;
using UnityEngine;
using XLua;

public class LuaBehaviour : MonoBehaviour
{
    Action mLuaUpdate = null;
    Action mLuaLateUpdate = null;
    Action mLuaFixedUpdate = null;

    private void Awake()
    {
        LuaEnv env = LuaManager.Instance.GetLuaEnv();
        mLuaUpdate = env.Global.Get<Action>("Update");
        mLuaLateUpdate = env.Global.Get<Action>("LateUpdate");
        mLuaFixedUpdate = env.Global.Get<Action>("FixedUpdate");
    }

    private void Update()
    {
        if (null != mLuaUpdate)
        {
            mLuaUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (null != mLuaFixedUpdate)
        {
            mLuaFixedUpdate();
        }
    }

    private void LateUpdate()
    {
        if (null != mLuaLateUpdate)
        {
            mLuaLateUpdate();
        }
    }
}