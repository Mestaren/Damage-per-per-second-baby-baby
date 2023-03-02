using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unithealth
{
    //field

    int _curentHealth;
    int _curentMaxHealth;

    //properties

    public int Health
    {
        get
        {
           return _curentHealth;
        }
        set
        {
            _curentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _curentMaxHealth;
        }
        set
        {
            _curentMaxHealth = value;
        }
    }

    //construction

    public Unithealth(int health, int MaxHealt)
    {
        _curentHealth = health;
        _curentMaxHealth = MaxHealt;

    }


    //methods

    public void DmgUnits(int dmgAmount)
    {
        if(_curentHealth > 0)
        {
            _curentHealth -= dmgAmount;
        }
    }

    public void HealUnits(int healAmount)
    {
        if (_curentHealth < _curentMaxHealth)
        {
            _curentHealth += healAmount;
        }
        if(_curentHealth > _curentMaxHealth)
        {
            _curentHealth = _curentMaxHealth;
        }
    }
}
