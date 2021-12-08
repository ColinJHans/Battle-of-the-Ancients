using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Enemy
{
    public static bool Alive = true;
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        type = "King";
        MaxHealth = 10;
        CurrentHealth = MaxHealth;
        MoveRange = 2;
        AttackRange = 3;
        Damage = 0;
    }

    public void isAlive()
    {
        if (MaxHealth > 0)
        {
            Alive = false;
        }
       
    }
}
