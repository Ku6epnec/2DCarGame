using System.Collections.Generic;


public class DataPlayer
{
    #region Fields

    private string _titleData;
    private int _countMoney;
    private int _countHealth;
    private int _countPower;
    private int _countCrime;

    private List<IEnemy> _enemies = new List<IEnemy>();

    public string TitleData => _titleData;

    #endregion

    #region Properties

    public int CountMoney
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                Notify(DataType.Money);
            }
        }
    }

    public int CountHealth
    {
        get => _countHealth;
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notify(DataType.Health);
            }
        }
    }

    public int CountPower
    {
        get => _countPower;
        set
        {
            if (_countPower != value)
            {
                _countPower = value;
                Notify(DataType.Power);
            }
        }
    }

    public int CountCrime
    {
        get => _countCrime;
        set
        {
            if (_countCrime != value)
            {
                _countCrime = value;
                Notify(DataType.CrimeLvl);
            }
        }
    }

    public DataPlayer(string titleData)
    {
        _titleData = titleData;
    }

    public void Attach(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void Detach(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    private void Notify(DataType dataType)
    {
        foreach (var enemy in _enemies)
            enemy.Update(this, dataType);
    }

    #endregion
}

#region Data

class Money : DataPlayer
{
    public Money(string titleData) : base (titleData)
    {

    }
}

class Health : DataPlayer
{
    public Health(string titleData) : base(titleData)
    {

    }
}

class Power : DataPlayer
{
    public Power(string titleData) : base(titleData)
    {

    }
}

class Crime : DataPlayer
{
    public Crime(string titleData) : base(titleData)
    {

    }
}

#endregion
