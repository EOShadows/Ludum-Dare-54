using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anime;
    private Rigidbody2D rb;
    private Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        direction = GetComponent<Direction>();
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetFloat("horizontal", rb.velocity.x);
        anime.SetFloat("vertical", rb.velocity.y);
        anime.SetFloat("xDir", direction.getDirection().x);
        anime.SetFloat("yDir", direction.getDirection().y);
    }
}
