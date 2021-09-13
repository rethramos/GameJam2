using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    private MissingItem itemBeingPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemBeingPickedUp != null && Input.GetMouseButtonDown(0))
        {
            Checklist.MarkAsFound(itemBeingPickedUp);
            Parameters p = new Parameters();
            p.PutExtra(FOUND_ITEM_KEY, itemBeingPickedUp.ItemName);
            EventBroadcaster.Instance.PostEvent(EventNames.ChecklistEvents.ON_ITEM_FOUND, p);
        }
    }

    private void FixedUpdate()
    {
        SelectItem();
        Debug.Log($"ITEM BEING PICKED UP: {itemBeingPickedUp}");
    }

    private void SelectItem()
    {
        Ray ray = cam.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 5f, layerMask))
        {
            MissingItem hitItem = hitInfo.collider.GetComponent<MissingItem>();

            if (hitItem == null)
            {
                itemBeingPickedUp = null;
            }
            else if (hitItem != null && hitItem != itemBeingPickedUp)
            {
                itemBeingPickedUp = hitItem;
            }
        } else
        {
            itemBeingPickedUp = null;
        }

        Debug.Log($"PICKED UP ITEM: {itemBeingPickedUp}");
    }

    public static string FOUND_ITEM_KEY { get => "FOUND_ITEM"; }
}
