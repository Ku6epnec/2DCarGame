using JoostenProductions;
using Tools;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace Game.InputLogic
{
    public class InputJoystickView : BaseInputView
    {
        #region UnityMethods

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        #endregion

        #region OtherMethods

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void Move()
        {
            float moveStep = 10 * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
            if(moveStep > 0)
                OnRightMove(moveStep);
            else if(moveStep < 0)
                OnLeftMove(moveStep); 
        }

        #endregion
    }
}

