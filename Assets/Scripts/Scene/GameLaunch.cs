using UnityEngine;


public class GameLaunch : MonoBehaviour
{
    private void Start()
    {
        LuaManager.Instance.Init();
        LuaManager.Instance.Startup();
    }
}