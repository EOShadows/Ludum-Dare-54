using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inventoryManager : MonoBehaviour
{
    public GameObject currentSelectedItem;
    public void changeSelection(GameObject selectItem){
        Debug.Log("Selecting item: " + selectItem);
        currentSelectedItem = selectItem;
    }

    public void moveItem(Transform newParent){
        if(currentSelectedItem){
            Debug.Log("Moving item to slot: " + newParent);
            currentSelectedItem.transform.SetParent(newParent.transform, false);
            currentSelectedItem = null;
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
}
