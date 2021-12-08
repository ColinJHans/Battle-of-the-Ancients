using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Collider2D clicked = null;
    bool moving = false;
    bool resting = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (clicked != null)
            {
                foreach (SpriteRenderer child in clicked.gameObject.GetComponentsInChildren<SpriteRenderer>(false))
                {
                    if (child.name == "Highlight")
                    {
                        child.enabled = false;
                    }
                }
            }
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!moving)
            {
                clicked = Physics2D.OverlapCircle(new Vector2(mousepos.x, mousepos.y), .5f, LayerMask.GetMask("Units"));
                if (clicked != null)
                {

                    foreach (SpriteRenderer child in clicked.gameObject.GetComponentsInChildren<SpriteRenderer>(false))
                    {
                        if (child.name == "Highlight")
                        {
                            child.enabled = true;
                        }
                    }
                }
            }
            else
            {
                clicked.GetComponent<Troops>().Move(mousepos);
                moving = false;
            }
            if (!resting)
            {
                clicked = Physics2D.OverlapCircle(new Vector2(mousepos.x, mousepos.y), .5f, LayerMask.GetMask("Units"));
                foreach (SpriteRenderer child in clicked.gameObject.GetComponentsInChildren<SpriteRenderer>(false))
                {
                    if (child.name == "Highlight")
                    {
                        child.enabled = true;
                    }
                }
            }
            else
            {
                clicked.GetComponent<Troops>().Rest();
                resting = false;
            }

        }
        bool areEnemiesDead = EnemiesDead();
        bool isPlayerDead = PlayerDead();
        bool isEnemyKingDead = KingDead();
        if (areEnemiesDead || isEnemyKingDead)
        {
            //go to victory screen
            GameObject[] ending = GameObject.FindGameObjectsWithTag("WinScreen");
            foreach (GameObject end in ending)
            {
                if (end.name == "Text")
                {
                    end.GetComponent<Text>().enabled = true;
                }
                else
                {
                    end.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            return;
        }
        else if (isPlayerDead)
        {
            // go to defeat screen
            GameObject[] ending = GameObject.FindGameObjectsWithTag("LoseScreen");
            foreach (GameObject end in ending)
            {
                if (end.name == "Text")
                {
                    end.GetComponent<Text>().enabled = true;
                }
                else
                {
                    end.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            return;
        }
    }


    public bool EnemiesDead()
    {
        return Enemy.count == 0;
    }

    public bool PlayerDead()
    {
        return Player.count == 0;
    }

    public bool KingDead()
    {
        return !King.Alive;
    }
    public void Move()
    {
        
        moving = true;
    }

    public void Rest()
    {
        resting = true;
    }
}
