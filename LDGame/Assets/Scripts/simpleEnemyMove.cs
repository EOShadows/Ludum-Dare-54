using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class simpleEnemyMove : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float attackRange = 1f;
    public float attackSpeed = 4f;
    private float nextAttack = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
        else if (dist < attackRange && nextAttack <= Time.time){
            nextAttack = Time.time + attackSpeed;
            gameObject.GetComponent<simpleEnemyAttack>().attack(attackRange);
        }
    }
}
