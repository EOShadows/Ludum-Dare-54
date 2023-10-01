using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageMenu : MonoBehaviour
{
    public GameObject inventory;
    public GameObject flashlight;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            inventory.SetActive(!inventory.activeSelf);
            flashlight.SetActive(!flashlight.activeSelf);
            if(Time.timeScale == 1f) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }
    }
}
