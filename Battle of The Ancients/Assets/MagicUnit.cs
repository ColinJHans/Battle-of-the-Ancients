using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUnit : Player
{
    // Start is called before the first frame update
    // Working on figuring out range without making units run into each other
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
