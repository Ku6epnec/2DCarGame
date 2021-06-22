using UnityEngine;


public class Enemy : IEnemy
{
    #region Fields

    private const float KPower = 1.2f;
    private const float KMoneyPower = 0.7f; 

    private string _name;

    private int _countMoney;
    private int _countHealth;
    private int _countPower;
    private int _countCrime;

    #endregion

    #region UnityMethods

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoney = dataPlayer.CountMoney;
                break;

            case DataType.Health:
                _countHealth = dataPlayer.CountHealth;
                break;

            case DataType.Power:
                _countPower = dataPlayer.CountPower;
                break;

            case DataType.CrimeLvl:
                _countCrime = dataPlayer.CountCrime;
                break;

        }

        Debug.Log($"Notify {_name} data {dataType}");
    }

    #endregion

    #region OtherMethods
    public Enemy(string name)
    {
        _name = name;
    }

    public int Power
    {
        get
        {
            var countPower = (int)((_countPower + _countCrime) * KPower) - _countHealth - (int)(_countMoney * KMoneyPower);
            return countPower;
        }
    }

    #endregion
}
