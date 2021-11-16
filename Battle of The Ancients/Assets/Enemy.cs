using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Troops
{

    override public void Start()
    {
        base.Start();
        MaxHealth = 6;
        CurrentHealth = MaxHealth;
        numTroops = 3;
        maxTroops = 3;
        enemy = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void loseHealth()
    {
        numTroops = maxTroops;
        CurrentHealth--;
        if ((MaxHealth * .67) > CurrentHealth)
        {
            numTroops--;
        }

        if ((MaxHealth * .33) > CurrentHealth)
        {
            numTroops--;
        }
        if (0 >= CurrentHealth)
        {
            Destroy(this.gameObject);
        }
        updateTroops(numTroops);
    }
}
