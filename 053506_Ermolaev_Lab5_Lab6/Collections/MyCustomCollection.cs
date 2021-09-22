using System;


namespace _053506_Ermolaev_Lab5
{
    class MyCustomCollection<T> : ICustomCollection<T>
    {
        public T this[int index] 
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();
                Node<T> temp = _head;
                int counter = 0;
                while (counter < index)
                {
                    temp = temp.Next; 
                    ++counter;
                }
                return temp.Data;
            }
            set
            {
                if (index >= _count || index < 0)
                    throw new IndexOutOfRangeException();
                Node<T> temp = _head;
                Node<T> prevTemp = null;
                int counter = 0;
                while (counter < index)
                {
                    prevTemp = temp;
                    temp = temp.Next;
                    ++counter;
                }
                if (prevTemp != null)
                    prevTemp.Next = new Node<T>(value, temp);
                else
                {
                    _head = new Node<T>(value, temp);
                    if (temp == null)
                        _tail = _head;
                }
            }
        }
        public int Count { get => _count; }
        public void Add(T item)
        {
            if (_tail == null)
                _head = _tail = new Node<T>(item);
            else
            {
                _tail.Next = new Node<T>(item);
                _tail = _tail.Next;
            }
            ++_count;
        }

        public T Find(T item)
        {
            Node<T> temp = _head;
            for (int i = 0; i < _count; ++i)
            {
                if (temp.Data.Equals(item))
                {
                    return temp.Data;
                }
                temp = temp.Next;
            }
            return default;
        }
        public T Current()
        {
            if(_current==null)
                throw new NullReferenceException();
            return _current.Data;
        }
        public void Next()
        {
            if(_current==null)
                throw new NullReferenceException();
            _prevCurrent = _current;
            _current = _current.Next;
        }
        public void Remove(T item)
        {
            Node<T> temp = _head;
            Node<T> prevTemp = null;
            bool isRemoved = false;
            for(int i = 0; i < _count; ++i)
            {
                if (temp.Data.Equals(item))
                {
                    isRemoved = true;
                    if (prevTemp != null)
                    {
                        prevTemp.Next = temp.Next;
                        if (prevTemp.Next == null)
                            _tail = prevTemp;
                        --_count;
                        break;
                    }
                    else
                    {
                        _head = _head.Next;
                        if (_head == null)
                            _tail = null;
                        --_count;
                        break;
                    }
                }
                prevTemp = temp;
                temp = temp.Next;
            }
            if(!isRemoved)
                throw new RemoveException("this object was not found in the list");
        }

        public T RemoveCurrent()
        {
            T value = _current.Data;
            if (_prevCurrent != null)
            {
                _prevCurrent.Next = _current.Next;
                _current = _prevCurrent.Next;
                if (_current == null)
                    _tail = _prevCurrent;
                --_count;
                return value;
            }
            else
            {
                _head = _head.Next;
                _current = _head;
                if (_head == null)
                    _tail = null;
                --_count;
                return value;
            }
        }

        public void Reset()
        {
            _current = _head;
        }

        private int _count = 0;

        private Node<T> _head = null;

        private Node<T> _tail = null;

        private Node<T> _current = null;

        private Node<T> _prevCurrent = null;
    }
}
