using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

// Create an abstract class Item
abstract class Item : MonoBehaviour
{
    public abstract void activate();
    /*
     * 
     * ���¡�������ŧ� OnTriggerEnter � Player class
     * 
     * �������Ҿ����������� Collider target
     * 
    if (target.gameObject.CompareTag("Item")) {

            // Get access to target (Item) items
            // Assume that target any items got a tag "Item"
            target.GetComponent<Item>().activate(this);
            Destroy(target.gameObject);
    }
    */
}
