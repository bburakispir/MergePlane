using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CREATION OF BOXES AND ADDING VALUES SCRIPT
public class BoxClick : MonoBehaviour {
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    public GameObject box;

    public PlaneDrag value;
  

    //WARNING: THE VALUES SHOULD NOT BE LIKE THIS BECAUSE WHENEVER MERGING AN OBJECT WILL DISCREASE THE POINT. FOR EXP: 4 - 4 = 8 POINTS. 5 = 5 POINTS.
    // IT IS LIKE THIS BECAUSE STUDY CASE WAS MENTIONED THAT THE VALUES HAS TO BE RIGHT WITH THE NUMBER OF THE BALLS.
    void Start ()//Attachin values to the player
    {
        p1.GetComponent<PlaneDrag>().value = 1;
        p2.GetComponent<PlaneDrag>().value = 2 * (p1.GetComponent<PlaneDrag>().value) + p1.GetComponent<PlaneDrag>().value;
        p3.GetComponent<PlaneDrag>().value = 2 * (p2.GetComponent<PlaneDrag>().value) + p2.GetComponent<PlaneDrag>().value;
        p4.GetComponent<PlaneDrag>().value = 2 * (p3.GetComponent<PlaneDrag>().value) + p3.GetComponent<PlaneDrag>().value;
        p5.GetComponent<PlaneDrag>().value = 2 * (p4.GetComponent<PlaneDrag>().value) + p4.GetComponent<PlaneDrag>().value;
        p6.GetComponent<PlaneDrag>().value = 2 * (p5.GetComponent<PlaneDrag>().value) + p5.GetComponent<PlaneDrag>().value;
        p7.GetComponent<PlaneDrag>().value = 2 * (p6.GetComponent<PlaneDrag>().value) + p6.GetComponent<PlaneDrag>().value;
        p8.GetComponent<PlaneDrag>().value = 2 * (p7.GetComponent<PlaneDrag>().value) + p7.GetComponent<PlaneDrag>().value;
       /* p9.GetComponent<PlaneDrag>().value = 2 * (p8.GetComponent<PlaneDrag>().value) + p8.GetComponent<PlaneDrag>().value;
        p10.GetComponent<PlaneDrag>().value = 2 * (p9.GetComponent<PlaneDrag>().value) + p9.GetComponent<PlaneDrag>().value;
        p11.GetComponent<PlaneDrag>().value = 2 * (p10.GetComponent<PlaneDrag>().value) + p10.GetComponent<PlaneDrag>().value;
        p12.GetComponent<PlaneDrag>().value = 2 * (p11.GetComponent<PlaneDrag>().value) + p11.GetComponent<PlaneDrag>().value;
        p13.GetComponent<PlaneDrag>().value = 2 * (p12.GetComponent<PlaneDrag>().value) + p12.GetComponent<PlaneDrag>().value;
        p14.GetComponent<PlaneDrag>().value = 2 * (p13.GetComponent<PlaneDrag>().value) + p13.GetComponent<PlaneDrag>().value;
        p15.GetComponent<PlaneDrag>().value = 2 * (p14.GetComponent<PlaneDrag>().value) + p14.GetComponent<PlaneDrag>().value;
        p16.GetComponent<PlaneDrag>().value = 2 * (p15.GetComponent<PlaneDrag>().value) + p15.GetComponent<PlaneDrag>().value;
        p17.GetComponent<PlaneDrag>().value = 2 * (p16.GetComponent<PlaneDrag>().value) + p16.GetComponent<PlaneDrag>().value;*/
    }
    void OnMouseUp()// CREATE THE BOXES, ASSIGN THEM TO THE PARENTS AND DESTROY THEM.
    {
        int playerNum = Random.Range(1,4);
        if (playerNum==1)
        {
            var temple=Instantiate(p1, transform.position, Quaternion.identity);
            temple.transform.parent = box.transform.parent;
 
        }
        else if (playerNum == 2)
        {
            var temple=Instantiate(p2, transform.position, Quaternion.identity);
            temple.transform.parent = box.transform.parent;
        }
        else if (playerNum == 3)
        {
            var temple= Instantiate(p3, transform.position, Quaternion.identity);
            temple.transform.parent = box.transform.parent;
        }
        Destroy(box);
    }

}
