using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Troops
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        enemy = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public void loseHealth()
    {
        numTroops = maxTroops;
        CurrentHealth--;
        if ((MaxHealth * .75) > CurrentHealth)
        {
            numTroops--;
        }

        if ((MaxHealth * .5) > CurrentHealth)
        {
            numTroops--;
        }
        if ((MaxHealth * .25) > CurrentHealth)
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
