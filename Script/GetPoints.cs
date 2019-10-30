using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPoints : MonoBehaviour {

    // THE SCRIPT WHICH HAS SCORE,AVERAGE SCORE AND POINT SLOTS.

    public int score;
    public int average;
    public GameObject pointSlot1;
    public GameObject pointSlot2;
    public GameObject pointSlot3;
    public GameObject pointSlot4;

    public Text scoreText;
    public Text averageText;

    void Awake()
    {
        average = 0;
        score = 0;
        scoreText.text ="Score: "+score.ToString();
        averageText.text = average.ToString()+"/sec";
        StartCoroutine(Example());
    }

    // Update is called once per frame
    void GainPoint()  //High score and average score
     {
            average = 0;
             if (pointSlot1.transform.childCount != 0)
                {
            getAverage(pointSlot1);
            getValue(pointSlot1);
                }
            if (pointSlot2.transform.childCount != 0)
            {
            getAverage(pointSlot2);
            getValue(pointSlot2);

            }
            if (pointSlot3.transform.childCount != 0)
            {
            getAverage(pointSlot3);
            getValue(pointSlot3);

            }
            if (pointSlot4.transform.childCount != 0)
            {
                getAverage(pointSlot4);
                getValue(pointSlot4);
            }
           

            scoreText.text = "Score: " + score.ToString();
            averageText.text = average.ToString()+"/sec" ;
    }
    void getValue(GameObject slot)// add values to the score
    {
        score += slot.transform.GetChild(0).gameObject.GetComponent<PlaneDrag>().value;
    }
    void getAverage(GameObject slot) //calculates the average score point each second.
    {
        average += slot.transform.GetChild(0).gameObject.GetComponent<PlaneDrag>().value;
    }
    IEnumerator Example() // loop for unlimited time
    {
        GainPoint();
        yield return new WaitForSeconds(1);
        StartCoroutine(Example2());
    }
    IEnumerator Example2() // loop for unlimited time
    {
        GainPoint();
        yield return new WaitForSeconds(1);
        StartCoroutine(Example());

    }
}
