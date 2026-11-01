/*
LeetCode daily question #232 https://leetcode.com/problems/implement-queue-using-stacks/description/
*/

namespace Problems.DQ232;

public class MyQueue
{
    private Stack<int> _uprightStack;
    private Stack<int> _upsideDownStack;

    public MyQueue()
    {
        _uprightStack = new Stack<int>();
        _upsideDownStack = new Stack<int>();
    }

    public void Push(int x)
    {
        if (_uprightStack.Count > 0 && _upsideDownStack.Count == 0)
        {
            while (_uprightStack.Count > 0)
            {
                _upsideDownStack.Push(_uprightStack.Pop());
            }
        }
        _upsideDownStack.Push(x);
    }

    public int Pop()
    {
        if (_uprightStack.Count > 0)
        {
            return _uprightStack.Pop();
        }

        if (_upsideDownStack.Count > 0 && _uprightStack.Count == 0)
        {
            while (_upsideDownStack.Count > 0)
            {
                _uprightStack.Push(_upsideDownStack.Pop());
            }
            return _uprightStack.Pop();
        }
        return 0;
    }

    public int Peek()
    {
        if (_uprightStack.Count > 0)
        {
            return _uprightStack.Peek();
        }

        if (_upsideDownStack.Count > 0 && _uprightStack.Count == 0)
        {
            while (_upsideDownStack.Count > 0)
            {
                _uprightStack.Push(_upsideDownStack.Pop());
            }
            return _uprightStack.Peek();
        }
        return 0;
    }

    public bool Empty()
    {
        return _upsideDownStack.Count == 0 && _uprightStack.Count == 0;
    }
}
