using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inventoryManager : MonoBehaviour
{
    public GameObject currentSelectedItem;
    public string[] inventory;
    public GameObject[] invPrefabs;
    public GameObject alternateInventoryUI;

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
        else if(alternateInventoryUI.GetComponent<inventoryManager>().currentSelectedItem){
            alternateInventoryUI.GetComponent<inventoryManager>().currentSelectedItem.transform.SetParent(newParent.transform, false);
            alternateInventoryUI.GetComponent<inventoryManager>().currentSelectedItem = null;
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void fillChest(string[] chestInv){
        if(inventory.Length == 0){
            inventory = chestInv;
            populateChest();
        }
    }

    void populateChest(){
        Debug.Log("Populating Chest with: " + inventory);
        int index = 0;
        foreach(string item in inventory){
            foreach(GameObject prefab in invPrefabs){
                if(item == prefab.name){
                    GameObject newItem = Instantiate(prefab);
                    newItem.transform.SetParent(transform.GetChild(index));
                    newItem.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
                    index += 1;
                }
            }
        }
    }
}
