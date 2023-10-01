using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(currHealth <= 0f){
            handleDeath();
        }
        Debug.Log(currHealth);
    }

    void handleDeath(){
        if(gameObject.name == "Character") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else Destroy(gameObject);
    }
}
