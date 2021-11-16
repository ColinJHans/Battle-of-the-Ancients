using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : MonoBehaviour
{
    [SerializeField] public int MaxHealth;
    [SerializeField] public string type = "";
    [SerializeField] public int MoveRange;
    [SerializeField] public int AttackRange;
    
    public int maxTroops = 4;
    public int numTroops = 0;
    public int CurrentHealth;
    public string enemy = null;
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
        Hit(col);
    }
    
    private void Hit(Collision2D col)
    {

        if (col.gameObject.tag == enemy)
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


    public void updateTroops(int inumTroops)
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log(inumTroops);

        }
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
                    Debug.Log(child.gameObject.name);

                }
                inumTroops++;
                child.GetComponent<SpriteRenderer>().enabled = false;
                
            }
        }
            }
    }

