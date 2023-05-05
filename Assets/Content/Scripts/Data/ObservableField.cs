using System;

namespace Content.Scripts.Data
{
    public class ObservableInt : ObservableField<int>
    {
        public ObservableInt(int value = 0) : base(value)
        {
        
        }
    }
    
    public class ObservableByte : ObservableField<byte>
    {
        public ObservableByte(byte value = 0) : base(value)
        {
        
        }
    }

    public abstract class ObservableField<T>
    {
        private T _value;
        private event Action<T> _changed;

        public ObservableField(T value = default)
        {
            Value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                if(_value.Equals(value) || value == null) return;

                _value = value;
                _changed?.Invoke(_value);
            }
        }
    
        public event Action<T> Changed
        {
            add
            {
                _changed += value;
                value?.Invoke(_value);
            }
            remove
            {
                _changed -= value;
                value?.Invoke(_value);
            }
        }
    }
}