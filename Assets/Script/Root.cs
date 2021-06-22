using Profile;
using Profile.Analytic;
using UnityEngine;


public class Root : MonoBehaviour
{
    #region Fields

    [SerializeField] 
    private Transform _placeForUi;

    private MainController _mainController;

    #endregion

    #region UnityMethods

    private void Awake()
    {
        ProfilePlayer profilePlayer = new ProfilePlayer(15f, new UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }

    #endregion
}
