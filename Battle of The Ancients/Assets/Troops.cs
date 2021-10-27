using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : MonoBehaviour
{
    [SerializeField] public int Health = 5;
    [SerializeField] public string type = "";
    [SerializeField] public int range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 mousepos)
    {
        if (Vector2.Distance(new Vector2(mousepos.x, mousepos.y), new Vector2(transform.position.x, transform.position.y)) < range)
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
        Health ++;
    }

}
