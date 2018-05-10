using UnityEngine;
using XLua;
using System.IO;

public class LuaManager : MonoSingleton<LuaManager>
{
    LuaEnv mLuaEvn = null;

    public LuaEnv GetLuaEnv()
    {
        return mLuaEvn;
    }

    void InitLuaEnv()
    {
        mLuaEvn = new LuaEnv();

        if (mLuaEvn != null)
        {
            mLuaEvn.AddLoader(CustomLoader);
        }
        else
        {

        }
    }

    byte[] CustomLoader(ref string filepath)
    {
#if UNITY_EDITOR
        string luaPath = "./LuaScript/" + filepath + ".lua";
        return File.ReadAllBytes(luaPath);
#else

#endif
    }

    private void Update()
    {
        if (null == mLuaEvn)
        {
            mLuaEvn.Tick();
        }
    }

    public override void Init()
    {
        InitLuaEnv();
    }
    public override void Dispose()
    {
        if (mLuaEvn != null)
        {
            try
            {
                mLuaEvn.Dispose();
                mLuaEvn = null;
            }
            catch (System.Exception ex)
            {
            	
            }
        }
    }
    public void Startup()
    {
        if (null == mLuaEvn) return;

        LoadScript("main");
    }

    void LoadScript(string scriptName)
    {
        mLuaEvn.DoString(string.Format("require '{0}'", scriptName));
    }
}