using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Troops
{
    // Start is called before the first frame update
    public static int count = 0;
    void Awake()
    {
        count++;
    }
    override public void Start()
    {
        base.Start();
        enemy = "Enemy";
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
        CurrentHealth-= enemyDamage;
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
            count--;
        }
        updateTroops(numTroops);
    }
}
