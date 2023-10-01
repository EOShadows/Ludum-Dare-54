using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    float currHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    public void takeDamage(float damage){
        currHealth -= damage;
        Debug.Log(currHealth);
    }
}
