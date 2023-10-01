using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class simpleEnemyAttack : MonoBehaviour
{
    public LayerMask player;
    GameObject character;
    public float damage;
    private Vector2 loc;
    private Collider2D attackArea;
    public float Attacksize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attack(float range)
    {
        // Debug.Log("Enemy Attack Called");
        Vector3 playerDir = (character.transform.position - transform.position);
        if (Mathf.Abs(playerDir.x) > Mathf.Abs(playerDir.y))
        {
            if (playerDir.x > 0)
            {
               // Debug.Log("Player is right");
                loc = new Vector2(transform.position.x + range / 2, transform.position.y);
            }
            else
            {
               // Debug.Log("Player is left");
                loc = new Vector2(transform.position.x - range / 2, transform.position.y);
            }
        }
        else
        {
            if (playerDir.y < 0)
            {
              //  Debug.Log("Player is down");
                loc = new Vector2(transform.position.x, transform.position.y - range / 2);
            }
            else
            {
               // Debug.Log("Player is up");
                loc = new Vector2(transform.position.x, transform.position.y + range / 2);
            }
        }
        attackArea = Physics2D.OverlapCircle(loc, Attacksize / 2, player);
        if(attackArea != null)
        {
            Debug.Log("attacked Player");
            attackArea.gameObject.GetComponent<health>().takeDamage(damage);
        }
    }

}
