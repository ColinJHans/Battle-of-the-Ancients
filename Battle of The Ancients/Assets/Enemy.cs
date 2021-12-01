using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Troops
{
    override public void Start()
    {
        base.Start();
        enemy = "Player";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    IEnumerator Bleed()
    {
        WaitForSeconds wait = new WaitForSeconds(.5f);
        while (true)
        {
            activateBlood();
            yield return wait;
        }
    }
    */
    override public void loseHealth()
    {

        numTroops = maxTroops;
        CurrentHealth -= enemyDamage;
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
