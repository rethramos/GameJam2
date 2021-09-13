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
        Debug.Log("MissingItem instantiated. " + itemName);
        isFound = false;
        Checklist.AddToChecklist(this);

        Parameters p = new Parameters();
        p.PutExtra(ITEM_KEY, itemName);
        EventBroadcaster.Instance.PostEvent(EventNames.ChecklistEvents.ON_CHECKLIST_ADD, p);

        Outline outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        Color32 color32 = new Color32(192, 50, 50, 255);
        outline.OutlineColor = color32;
        outline.OutlineWidth = 10f;
        outline.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(!isFound);
    }

    public static string ITEM_KEY { get => "ITEM"; }

    public bool IsFound { get => isFound; set => isFound = value; }

    public string ItemName { get => itemName; set => itemName = value; }

    public override string ToString()
    {
        return ItemName;
    }
}
