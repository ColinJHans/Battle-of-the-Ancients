using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpears : Enemy
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        MaxHealth = 6;
        CurrentHealth = MaxHealth;
        numTroops = 3;
        maxTroops = 3;
        Damage = 2f;
        AttackRange = -3;
        enemy = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
