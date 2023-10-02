using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestStuff : MonoBehaviour
{
    public string[] chestInventory;
    public GameObject chestUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateChest(){
        chestUI.SetActive(true);
        chestUI.GetComponent<inventoryManager>().fillChest(chestInventory);
    }

    public void deactivateChest(){
        chestUI.SetActive(false);
    }
}

