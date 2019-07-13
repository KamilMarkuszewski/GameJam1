using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Common
{
    public class ObjectPool<T>
    {
        private readonly Queue<T> _objects;
        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objects = new Queue<T>();
            _objectGenerator = objectGenerator;
        }

        public T GetObject()
        {
            lock (_objects)
            {
                if (_objects.Any())
                {
                    return _objects.Dequeue();

                }
                return _objectGenerator();
            }
        }

        public void PutObject(T item)
        {
            lock (_objects)
            {
                if (item != null)
                {
                    _objects.Enqueue(item);
                }
            }
        }
    }
}
