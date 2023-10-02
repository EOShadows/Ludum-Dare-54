using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteManLookAtMoving : MonoBehaviour
{
    private Transform player;
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        anime.SetFloat("x", dir.x);
        anime.SetFloat("y", dir.y);
    }
}
