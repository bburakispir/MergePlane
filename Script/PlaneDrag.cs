using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]
//The Script which has to be in every Plane(Balls) and shows us the selected Planes.
public class PlaneDrag : MonoBehaviour
{
    public int value; // plane Point values

    void OnMouseEnter()
    {
        transform.parent.parent.GetComponent<InventoryController>().selectedPlane = this.transform;
    }
    void OnMouseExit()
    {
        if (!transform.parent.parent.GetComponent<InventoryController>().canDragPlane) //if not holding an object
        transform.parent.parent.GetComponent<InventoryController>().selectedPlane = null; //Plane has to be null because if not where ever we click on screen will call this object.
    }
}