using System;


namespace Tools
{
    public class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        #region Fields

        private T _value;
        private Action<T> _onChangeValue;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _onChangeValue?.Invoke(_value);
            }
        }

        #endregion

        #region OtherMethods

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            _onChangeValue += subscriptionAction;
        }

        public void UnSubscriptionOnChange(Action<T> unsubscriptionAction)
        {
            _onChangeValue -= unsubscriptionAction;
        }

        #endregion
    }
}

