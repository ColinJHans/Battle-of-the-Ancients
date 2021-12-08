using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUnit : Player
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        type = "Sword Troop";
        MaxHealth = 6;
        CurrentHealth = MaxHealth;
        MoveRange = 3;
        AttackRange = 3;
        Damage = 2f;
        maxTroops = 3;

    }
}
