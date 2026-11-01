/*
LeetCode daily question #225 https://leetcode.com/problems/implement-stack-using-queues/description/
*/

namespace Problems.DQ225;

public class MyStack
{
    private readonly Queue<int> _firstQueue;
    private readonly Queue<int> _secQueue;

    public MyStack()
    {
        _firstQueue = new Queue<int>();
        _secQueue = new Queue<int>();
    }

    public void Push(int x)
    {
        if (_secQueue.Count > 0)
        {
            _secQueue.Enqueue(x);
        }
        else
        {
            _firstQueue.Enqueue(x);
        }
    }

    public int Pop()
    {
        if (_firstQueue.Count > 0)
        {
            while (_firstQueue.Count > 1)
            {
                _secQueue.Enqueue(_firstQueue.Dequeue());
            }
            return _firstQueue.Dequeue();
        }
        else if (_secQueue.Count > 0)
        {
            while (_secQueue.Count > 1)
            {
                _firstQueue.Enqueue(_secQueue.Dequeue());
            }
            return _secQueue.Dequeue();
        }
        return 0;
    }

    public int Top()
    {
        if (_firstQueue.Count > 0)
        {
            while (_firstQueue.Count > 1)
            {
                _secQueue.Enqueue(_firstQueue.Dequeue());
            }
            int val = _firstQueue.Dequeue();
            _secQueue.Enqueue(val);
            return val;
        }
        else if (_secQueue.Count > 0)
        {
            while (_secQueue.Count > 1)
            {
                _firstQueue.Enqueue(_secQueue.Dequeue());
            }
            int val = _secQueue.Dequeue();
            _firstQueue.Enqueue(val);
            return val;
        }
        return 0;
    }

    public bool Empty()
    {
        return _firstQueue.Count == 0 && _secQueue.Count == 0;
    }
}
