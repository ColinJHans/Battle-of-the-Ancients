using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : MonoBehaviour
{
    public float MaxHealth;
    public string type = "";
    public int MoveRange;
    public float AttackRange;
    
    public int maxTroops = 4;
    public int numTroops = 0;
    public float CurrentHealth;
    public float Damage;

    public string enemy = null;
    public float enemyDamage;

    private Coroutine Coroutine = null;
    // Start is called before the first frame update
    virtual public void Start()
    {
        numTroops = maxTroops;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 mousepos)
    {
        if (Vector2.Distance(new Vector2(mousepos.x, mousepos.y), new Vector2(transform.position.x, transform.position.y)) < MoveRange)
        {
            
            transform.position = new Vector3(mousepos.x,mousepos.y,0);
        }
        else
        {
            Debug.Log(Vector2.Distance(new Vector2(mousepos.x, mousepos.y), new Vector2(transform.position.x, transform.position.y)));
        }
    }

    public void Rest()
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth++;
        }
        else
        {
            Debug.Log("Full Health!");
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == gameObject.tag)
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
        DamageTroops(col);
        Hit(col);
    }
    
    private void Hit(Collision2D col)
    {
        float distance = ((col.transform.position.x - gameObject.transform.position.x) + (col.transform.position.y - gameObject.transform.position.y));
        Debug.Log(gameObject.name);
        Debug.Log(distance);
        
        if (col.gameObject.tag == enemy && AttackRange >= distance && distance > 0)
        {
            
            this.Coroutine = StartCoroutine(Battle());
            
        }
        if (col.gameObject.tag == enemy && AttackRange <= distance && distance < 0)
        {

            this.Coroutine = StartCoroutine(Battle());

        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == enemy)
        {
            StopCoroutine(this.Coroutine);
        }
    }

    IEnumerator Battle()
    {
        //makes units go into battle while not instantly destroying the one with less health
        WaitForSeconds wait = new WaitForSeconds(2);
        while (true)
        {
            loseHealth();
            yield return wait;

        }
    }
    
    virtual public void loseHealth()
    {
        Debug.Log("Error: Wrong loseHealth()");
        return;
    }

    /*
    public void activateBlood()
    {
        foreach (SpriteRenderer child in gameObject.GetComponentsInChildren<SpriteRenderer>(false))
        {
            if (child.name == "HitBox")
            {
                child.enabled = true;
            }
        }
    }
    
    public void deactivateBlood()
    {
        foreach (SpriteRenderer child in gameObject.GetComponentsInChildren<SpriteRenderer>(false))
        {
            if (child.name == "HitBox")
            {
                child.enabled = false;
            }
        }
    }
    */
    public void updateTroops(int inumTroops)
    {
        //disables sprite renders when the health is low enough
        foreach (Transform child in GetComponentsInChildren<Transform>(false))
        {
            if (inumTroops == maxTroops)
            {
                return;
            }
            if (child.gameObject.tag == "Unit")
            {
                if (gameObject.tag == "Player")
                {
                    inumTroops++;
                    child.GetComponent<SpriteRenderer>().enabled = false;
                }
                if (gameObject.tag == "Enemy")
                {
                    inumTroops++;
                    child.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    public void DamageTroops(Collision2D collision)
    {

        if (collision.gameObject.name.Contains("Brawler Unit"))
        {
            enemyDamage = .5f;
        }
        else if (collision.gameObject.name.Contains("Spear Unit") || (collision.gameObject.name.Contains("Magic Unit")))
        {
            enemyDamage = 1f;
        }
        else if (collision.gameObject.name.Contains("Sword Unit"))
        {
            enemyDamage = 1.5f;
        }

        if (collision.gameObject.name.Contains("EnemySpear"))
        {
            enemyDamage = 1.5f;
        }
    }
}

