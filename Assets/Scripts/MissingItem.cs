using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    private bool isFound;

    // Start is called before the first frame update
    void Start()
    {
        isFound = false;
        Checklist.AddToChecklist(this);
        Debug.Log("MissingItem instantiated. " + itemName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsFound { get => isFound; set => isFound = value; }

    public string ItemName { get => itemName; set => itemName = value; }
}
