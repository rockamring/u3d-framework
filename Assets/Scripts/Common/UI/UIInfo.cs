
public class UIInfo
{
    public enum UIType
    {
        TYPE_ITEM,
        TYPE_BASE,
        TYPE_POP,
        TYPE_STORY,
        TYPE_MESSAGEBOX,
        TYPE_TIPS,
    }
    public string Path { get; private set; }
    public UIType UiType { get; private set; }

    public UIInfo(string path, UIType type)
    {
        Path = path;
        UiType = type;
    }

    public bool CachedAfterClosed()
    {
        return UiType == UIType.TYPE_BASE;
    }
    public static readonly UIInfo MainMenu = new UIInfo("xxx/xxx", UIType.TYPE_BASE);
}