using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingManagement : MonoBehaviour
{
    private Animator anime;

    public lightFollowMouse lookDir;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetFloat("lookAngle", (lookDir.angle / 360));

        if (Input.GetButtonDown("Fire1"))
        {
            anime.SetTrigger("attack");
        }
    }
}
