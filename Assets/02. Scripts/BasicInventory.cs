using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInventory : MonoBehaviour {

    #region Singleton

    public static BasicInventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of BasicInventory found!");
            return;
        }
        instance = this; 
    }

    #endregion  

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public int space = 20;

    public List<BasicItem> items = new List<BasicItem>();

    public bool Add(BasicItem item)
    {
        //if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(BasicItem item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
