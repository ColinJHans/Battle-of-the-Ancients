using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlerTroop : Player
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        type = "Brawler Troop";
        MaxHealth = 15;
        CurrentHealth = MaxHealth;
        MoveRange = 4;
        AttackRange = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
