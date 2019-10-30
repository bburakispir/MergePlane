using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Script which has to be in every slot and shows us the selected slots.
public class SlotController : MonoBehaviour {
    void OnMouseEnter()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = this.transform;
    }
    void OnMouseExit()
    {
        transform.parent.GetComponent<InventoryController>().selectedSlot = null;
    }

}
