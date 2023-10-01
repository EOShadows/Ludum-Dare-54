using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managePress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passChild(){
        if(transform.childCount > 0) transform.parent.GetComponent<inventoryManager>().changeSelection(transform.GetChild(0).gameObject);
        else transform.parent.GetComponent<inventoryManager>().moveItem(transform);
    }
}
