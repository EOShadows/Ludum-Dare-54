using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    float currHealth;
    public float maxHealth;
    float maxFlashTime = 0.2f;
    float currFlashTime;
    bool tookDamage = false;
    public Color hurtColor;
    Color mainColor;
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        currFlashTime = maxFlashTime;
        rend = GetComponent<SpriteRenderer>();
        mainColor = rend.color;
    }

    void Update(){
        if(tookDamage){
            currFlashTime -= Time.deltaTime;
            if(currFlashTime <= 0f){
                tookDamage = false;
                rend.color = mainColor;
                currFlashTime = maxFlashTime;
            }
        }
    }

    public void takeDamage(float damage){
        currHealth -= damage;

        tookDamage = true;
        rend.color = hurtColor;

        if(currHealth <= 0f){
            handleDeath();
        }
        Debug.Log(currHealth);
    }

    void handleDeath(){
        if(gameObject.name == "Character") SceneManager.LoadScene("DeathMenu");
        else Destroy(gameObject);
    }
}
