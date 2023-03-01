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


}
