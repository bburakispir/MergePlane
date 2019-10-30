using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public Transform selectedPlane, selectedSlot, selectedBox, originalSlot;
    public GameObject slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9;
    public GameObject box;
    public int random;
    
    private Vector3 screenPoint;
    private Vector3 offset;

    public bool canDragPlane=false;

    public BoxClick boxclick;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedPlane!=null) //IF FIRST CLICK OF MOUSE IF WE RE ON SOME OF PLANES(BALLS)
        {
            canDragPlane = true; //THE PARAMETER THAT SHOWS US WE'RE DRAGGING SMTH.
            originalSlot = selectedPlane.parent; //MAKES THE ORIGINAL SLOT TO COME BACK THIS SLOT IF NOT GOING A SLOT.
        
            //selectedPlane.GetComponent<Collider>().enabled = false; // TO NOT COLLIDE WITH OTHER PLANES(BALLS)

            screenPoint = Camera.main.WorldToScreenPoint(selectedPlane.transform.position); //CALCULATES THE MOUSE POSITIONS FOR DRAGGING THE PLANE(BALL)
            offset = selectedPlane.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            SetPlaneColliders(false);
        }
        if (Input.GetMouseButton(0) && selectedPlane != null && canDragPlane) //IF DRAGGING BLOCK IF PLANE(BALL) SELECTED IF DRAGGING PLANE(BALL)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); 
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            selectedPlane.transform.position = curPosition; 

        }
        else if (Input.GetMouseButtonUp(0) && selectedPlane != null && canDragPlane!=false)//IF MOUSE RELEASE IF PLANE(BALL) SELECTED IF DRAGGIN PLANE(BALL)
        {
            canDragPlane = false;
            SetPlaneColliders(true);
            if (selectedSlot == null) //IF THERE IS NO SLOT WHEN MOUSE RELEASED
            {
                selectedPlane.parent = originalSlot; //COME BACK ORIGINAL SLOT
                selectedPlane.localPosition = Vector3.back; 
               // selectedPlane.GetComponent<Collider>().enabled = true;
                selectedPlane = null;
            }
            else //IF THERE IS A SLOT WHEN MOUSE RELEASED
            {
                selectedPlane.parent = selectedSlot; //MAKE THE PLANE(BALL) CHID OF SELECTED SLOT
                selectedPlane.localPosition = Vector3.back; // CHANGE LOCATION


                selectedSlot.GetChild(0).parent = originalSlot; // CHANGE SLOTS OF PLANES(BALLS)
                originalSlot.GetChild(0).localPosition = Vector3.back;
                selectedPlane.parent = selectedSlot;
                selectedPlane.localPosition = Vector3.back;

                if (selectedSlot.childCount!=0 && originalSlot.childCount!=0 && selectedSlot!=originalSlot) // IF SELECTED SLOT HAS CHILD IF PREVIOUS SLOT HAS CHILD AND IF THEY'RE NOT SAME SLOTS
                {
                    if (originalSlot.GetChild(0).transform.gameObject.tag == selectedSlot.GetChild(0).transform.gameObject.tag)//IF CHILDS ARE SAME
                    {
                        NextLevel(); //Next Level creation function
                    }
                }
                if (selectedPlane!=null)
                {
                   // selectedPlane.GetComponent<Collider>().enabled = true;
                }
            }
        }
    }

    public void NextLevel()//LEVEL UPGRADE DESTROY OLD PLANES(BALLS) CREATE UPGRATED PLANE(BALL)
    {
            if (selectedSlot.GetChild(0).transform.gameObject.tag == "p1")
            {
            PlaneCreate(boxclick.p2);
            }
            else if (selectedSlot.GetChild(0).transform.gameObject.tag == "p2")
            {
            PlaneCreate(boxclick.p3);
            }
            else if (selectedSlot.GetChild(0).transform.gameObject.tag == "p3")
            {
            PlaneCreate(boxclick.p4);
            }
            else if (selectedSlot.GetChild(0).transform.gameObject.tag == "p4")
            {
            PlaneCreate(boxclick.p5);
            }
            else if (selectedSlot.GetChild(0).transform.gameObject.tag == "p5")
            {
            PlaneCreate(boxclick.p6);
            }
            else if (selectedSlot.GetChild(0).transform.gameObject.tag == "p6")
            {
            PlaneCreate(boxclick.p7);
            }
            else if (selectedSlot.GetChild(0).transform.gameObject.tag == "p7")
            {
            PlaneCreate(boxclick.p8);
            }
    }
    public void PlaneCreate(GameObject plane) //Plane(Ball) Creation
    {
        var temple = Instantiate(plane, selectedSlot.position, Quaternion.identity);
        temple.transform.parent = selectedSlot;
        temple.transform.localPosition = Vector3.back;
        DestroyPreviousPlanes();
    }
    public void DestroyPreviousPlanes() //Destroy lower level planes
    {
        DestroyImmediate(originalSlot.GetChild(0).gameObject);
        DestroyImmediate(selectedSlot.GetChild(0).gameObject);
    }
    void SetPlaneColliders(bool b) //CHANGE GAMEOBJECT COLLIDERS FOR NOT COLLISIONS
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p1")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p2")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p3")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p1")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p2")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p3")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p4")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p5")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p6")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p7")) { plane.GetComponent<Collider>().enabled = b; }
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("p8")) { plane.GetComponent<Collider>().enabled = b; }
        
    }

    public void BoxCreate()
    {
        GameObject[] transArray;
        transArray = new GameObject[9];
        int i = 0;

        if (isEmpty(slot1) == true) { transArray[i] = slot1; i++; }// THE ALGORITHM:
        if (isEmpty(slot2) == true) { transArray[i] = slot2; i++; }
        if (isEmpty(slot3) == true) { transArray[i] = slot3; i++; }
        if (isEmpty(slot4) == true) { transArray[i] = slot4; i++; }
        if (isEmpty(slot5) == true) { transArray[i] = slot5; i++; }//FIND EMPTY SLOTS, PUT THEM IN AN ARRAY, GET RANDOM VALUE FROM 0 TO ARRAY LENGTH, CREATE THE BOX THERE
        if (isEmpty(slot6) == true) { transArray[i] = slot6; i++; }
        if (isEmpty(slot7) == true) { transArray[i] = slot7; i++; }
        if (isEmpty(slot8) == true) { transArray[i] = slot8; i++; }
        if (isEmpty(slot9) == true) { transArray[i] = slot9; i++; }// THIS ALGORITHM DOESN'T PUT BUSY SLOTS TO THE RANDOM AND PREVENTS COLLISIONS

        if (i != 0){
            random = Random.Range(0, i);
            BoxSlotAttach(transArray[random]);
        }
        if (i==0)
        {
            Debug.Log("ALL SLOTS ARE FULL!");
        }
    }
    public bool isEmpty(GameObject slot)
    {
        if (slot.transform.childCount==0)
        {
            return true;
        }
        return false;
    }

    public void BoxSlotAttach(GameObject slot)
    {
            Vector3 slotPosition = new Vector3(slot.transform.position.x, slot.transform.position.y, box.transform.position.z);
            var temple = Instantiate(box, slotPosition, box.transform.rotation);
            temple.transform.parent = slot.transform;
    }
    IEnumerator Example() // loop for unlimited time
    {
        BoxCreate();
        yield return new WaitForSeconds(6);
        StartCoroutine(Example2());
    }
    IEnumerator Example2()
    {
        BoxCreate();
        yield return new WaitForSeconds(6);
        StartCoroutine(Example());
    }
}