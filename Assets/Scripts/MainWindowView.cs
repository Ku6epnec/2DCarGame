using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainWindowView : MonoBehaviour
{
    #region ObjectsFields

    [SerializeField]
    private GameObject _skipButtonObject;

    [SerializeField]
    private TMP_Text _countMoneyText;
    [SerializeField]
    private TMP_Text _countHealthText;
    [SerializeField]
    private TMP_Text _countPowerText;
    [SerializeField]
    private TMP_Text _countEnemyCrimeText;
    [SerializeField]
    private TMP_Text _countEnemyPowerText;

    [SerializeField]
    private Button _addMoneyButton;
    [SerializeField]
    private Button _minusMoneyButton;
    [SerializeField]
    private Button _addHealthButton;
    [SerializeField]
    private Button _minusHealthButton;
    [SerializeField]
    private Button _addPowerButton;
    [SerializeField]
    private Button _minusPowerButton;
    [SerializeField]
    private Button _addEnemyCrimeButton;
    [SerializeField]
    private Button _minusEnemyCrimeButton;
    [SerializeField]
    private Button _fightButton;
    [SerializeField]
    private Button _skipButton;

    #endregion

    #region OtherFields

    private Enemy _enemy;

    private Crime _crime;
    private Money _money;
    private Power _power;
    private Health _health;

    private int _allCountCrime;
    private int _allCountMoney;
    private int _allCountPower;
    private int _allCountHealth;

    private int _threshold = 3;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _enemy = new Enemy("Enemy №1");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        _health = new Health(nameof(Health));
        _health.Attach(_enemy);

        _crime = new Crime(nameof(Crime));
        _crime.Attach(_enemy);


        _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _addEnemyCrimeButton.onClick.AddListener(() => ChangeCrimeLvl(true));
        _minusEnemyCrimeButton.onClick.AddListener(() => ChangeCrimeLvl(false));

        _fightButton.onClick.AddListener(Fight);

        _skipButton.onClick.AddListener(Skip);
    }

    private void OnDestroy()
    {
        _addMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addEnemyCrimeButton.onClick.RemoveAllListeners();
        _minusEnemyCrimeButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _power.Detach(_enemy);
        _health.Detach(_enemy);
        _crime.Detach(_enemy);
    }

    #endregion

    #region OtherMethods

    private void ChangeMoney(bool isAddData)
    {
        if (isAddData)
            _allCountMoney++;
        else
            _allCountMoney--;

        ChangeWindowData(_allCountMoney, DataType.Money);
    }

    private void ChangePower(bool isAddData)
    {
        if (isAddData)
            _allCountPower++;
        else
            _allCountPower--;

        ChangeWindowData(_allCountPower, DataType.Power);
    }

    private void ChangeHealth(bool isAddData)
    {
        if (isAddData)
            _allCountHealth++;
        else
            _allCountHealth--;

        ChangeWindowData(_allCountHealth, DataType.Health);
    }

    private void ChangeCrimeLvl(bool isAddData)
    {
        if (isAddData)
            _allCountCrime++;
        else
            _allCountCrime--;

        ChangeWindowData(_allCountCrime, DataType.CrimeLvl);

        if (_allCountCrime >= _threshold)
            _skipButtonObject.SetActive(false);
        else
            _skipButtonObject.SetActive(true);
    }

    private void Fight()
    {
        Debug.Log(_allCountPower >= _enemy.Power ? "Win" : "Lose");
    }

    private void Skip()
    {
        Debug.Log(_allCountCrime <= _threshold ? "Skip Enemy" : "That's BUG! U don't see this button!") ;
    }

    private void ChangeWindowData(int countData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _countHealthText.text = $"Player health: {countData}";
                _health.CountHealth = countData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player power: {countData}";
                _power.CountPower = countData;
                break;

            case DataType.Money:
                _countMoneyText.text = $"Player money: {countData}";
                _health.CountMoney = countData;
                break;

            case DataType.CrimeLvl:
                _countEnemyCrimeText.text = $"Crime Lvl: {countData}";
                _crime.CountCrime = countData;
                break;
        }

        _countEnemyPowerText.text = $"Enemy power: {_enemy.Power}"; 
    }

    #endregion
}
