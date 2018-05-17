using UnityEngine;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
    Dictionary<UIInfo, GameObject> _cacheDic = new Dictionary<UIInfo, GameObject>();
    public void ShowUI(UIInfo viewType)
    {
        if (!_cacheDic.ContainsKey(viewType) || _cacheDic[viewType] == null)
        {

        }
        _cacheDic[viewType].SetActive(true);
    }

    public void CloseUI(UIInfo viewType)
    {
        if (viewType.CachedAfterClosed())
        {

        }
        else
        {

        }
    }

}