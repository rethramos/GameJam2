using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Checklist
{
    private static List<MissingItem> itemsToFind = new List<MissingItem>();

    public static void AddToChecklist(MissingItem item)
    {
        itemsToFind.Add(item);
        //MissingItem missingItem = item.GetComponent<MissingItem>();
        Debug.Log($"Added {item.ItemName}. items: {itemsToFind}");
    }

    //public static void MarkAsFound(MissingItem item)
    //{
    //    itemsToFind.Find(el => el.ItemName == item.ItemName).IsFound = true;
    //}

    public static List<MissingItem> GetAllItems()
    {
        return itemsToFind;
    }
}
