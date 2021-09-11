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
    }

    private void FixedUpdate()
    {
        SelectItem();   
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
}
