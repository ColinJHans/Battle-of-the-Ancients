using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUnit : Troops
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        type = "Magic Troop";
        MaxHealth = 8;
        CurrentHealth = MaxHealth;
        MoveRange = 2;
        AttackRange = 4;
        Damage = 1.5f;

    }
}
