using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxButtonScript : MonoBehaviour {

    //BUTTON SCRIPT

    public Button button;
    public InventoryController Button;
    public GetPoints hScore;
    public Text BoxValueText;
    public int valueOfBox= 10;


	void Start () {

        BoxValueText.text = "" + valueOfBox.ToString();
    }
	
	public void ButtonClick()
    {
        
        if (hScore.gameObject.GetComponent<GetPoints>().score >= valueOfBox)
        {
            hScore.gameObject.GetComponent<GetPoints>().score -= valueOfBox;
            Button.gameObject.GetComponent<InventoryController>().BoxCreate();
            BoxValueText.text = "" + valueOfBox.ToString();
            valueOfBox = (valueOfBox * 1 / 3) + valueOfBox;
            hScore.scoreText.text = "Score: " + hScore.score.ToString();
        }
        else
        {
            Debug.Log("NEED MORE POINTS");
        }

    }
}
