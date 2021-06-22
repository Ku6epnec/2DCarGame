using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        #region Fields

        [SerializeField] 
        private Button _buttonStart;

        #endregion

        #region OtherMethods

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }

        #endregion

        #region UnityMethods

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        #endregion
    }
}

