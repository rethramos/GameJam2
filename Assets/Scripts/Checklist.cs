using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Checklist
{
    private static List<MissingItem> itemsToFind = new List<MissingItem>();
    private static int nFound = 0;

    public static void AddToChecklist(MissingItem item)
    {
        itemsToFind.Add(item);
        PrintItems();
    }

    public static void MarkAsFound(MissingItem item)
    {
        itemsToFind.Find(el => el.ItemName == item.ItemName).IsFound = true;
        nFound++;
    }

    public static List<MissingItem> GetAllItems()
    {
        return itemsToFind;
    }

    private static void PrintItems()
    {
        List<string> itemNames = new List<string>();
        
        foreach (MissingItem item in itemsToFind)
        {
            itemNames.Add(item.ItemName);
        }

        Debug.Log("ITEMS:" + string.Join(",",itemNames));
    }

    public static bool AllFound()
    {
        return nFound == itemsToFind.Count;
    }

}
