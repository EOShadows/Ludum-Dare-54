using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatman_behaviour : MonoBehaviour
{
    private Animator anime;
    private simpleEnemyMove move;
    private simpleEnemyAttack attack;
    private Rigidbody2D rb;
    private Transform player;

    private bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        move = GetComponent<simpleEnemyMove>();
        attack = GetComponent<simpleEnemyAttack>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        move.enabled = false;
        attack.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!up)
            return;

        anime.SetFloat("x", (-transform.position + player.position).normalized.x);
        anime.SetFloat("y", (-transform.position + player.position).normalized.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            up = true;
            anime.SetTrigger("pop out");
        }
    }

    public void startMoving()
    {
        move.enabled = true;
        attack.enabled = true;
    }
}
