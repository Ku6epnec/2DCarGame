using System;


namespace Tools
{
    public class SubscriptionAction : IReadOnlySubscriptionAction
    {
        #region Fields

        private Action _action;

        #endregion

        #region OtherMethods

        public void Invoke()
        {
            _action?.Invoke();
        }
        
        public void SubscribeOnChange(Action subscriptionAction)
        {
            _action += subscriptionAction;
        }

        public void UnSubscriptionOnChange(Action unsubscriptionAction)
        {
            _action -= unsubscriptionAction;
        }

        #endregion
    }
}

