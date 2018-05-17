using System.Collections.Generic;

// 对UIManager的封装
public class ContextManager : Singleton<ContextManager> 
{
    private Stack<BaseContext> _contextStack = new Stack<BaseContext>();

    public void Push(BaseContext nextContext, bool popCur = true)
    {
        if (nextContext == null) return;

        if (_contextStack.Count > 0)
        {
            BaseContext curContext = _contextStack.Peek();
            if (curContext != null)
            {
                UIManager.Instance.CloseUI(curContext.ViewType);
            }
            if (popCur)
            {
                _contextStack.Pop();
            }
        }

        _contextStack.Push(nextContext);
        UIManager.Instance.ShowUI(nextContext.ViewType);
    }

    public void Pop()
    {
        if (_contextStack.Count > 0)
        {
            BaseContext popContext = _contextStack.Peek();
            _contextStack.Pop();

            // delete view
            if (popContext != null)
            {
                UIManager.Instance.CloseUI(popContext.ViewType);
            }
        }

        if (_contextStack.Count > 0)
        {
            BaseContext topContext = _contextStack.Peek();
            if (topContext != null)
            {
                UIManager.Instance.ShowUI(topContext.ViewType);
            }
        }
    }

    private BaseContext Peek()
    {
        return _contextStack.Count > 0 ? _contextStack.Peek() : null;
    }

    public void ShowMessageBox()
    {

    }
}