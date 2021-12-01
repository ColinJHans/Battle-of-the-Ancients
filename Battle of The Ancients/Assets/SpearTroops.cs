using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTroops : Player
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        type = "Spear Troop";
        MaxHealth = 10;
        CurrentHealth = MaxHealth;
        MoveRange = 3;
        AttackRange = 3;
        Damage = 1;
        
    }


}
