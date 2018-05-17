
public abstract class BaseContext
{
    public UIInfo ViewType { get; private set; }

    public BaseContext(UIInfo viewType)
    {
        ViewType = viewType;
    }
}