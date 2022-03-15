using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
     [SerializeField] private Stack inventoryOne;
    // Start is called before the first frame update
    void Start()
    {
        inventoryOne = new Stack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddInventoryOne(GameObject item)
    {
        inventoryOne.Push(item);
    }

    public GameObject GetInventoryOne()
    {
        return inventoryOne.Pop() as GameObject;
    }
    public void SeeInventoryOne()
    {
        Debug.Log(inventoryOne.ToString());
        foreach (var item in inventoryOne)
        {
            Debug.Log(item.ToString());
        }
    }
    public bool InventoryOneHas()
    {
        return inventoryOne.Count > 0;
    }
}
