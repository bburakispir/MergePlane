using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBalls : MonoBehaviour {

   /* public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;
    public GameObject prefab10;
    public GameObject prefab11;
    public GameObject prefab12;
    public GameObject prefab13;
    public GameObject prefab14;
    public GameObject prefab15;*/

    public int numberToCreate;
    public GameObject ParentPanel;
    public List<Sprite> Sprites = new List<Sprite>();

    
	// Use this for initialization
	void Start () {

        Populate();
        
	}
	
	// Update is called once per frame
    void Populate()
    {
        int a = 55;
        int b = 55;
        foreach (Sprite currentSprite in Sprites)
        {
            GameObject NewObj = new GameObject();
            NewObj.transform.position = new Vector3(transform.position.x-a,transform.position.y-b,transform.position.z);
            b += 120;
            Image NewImage = NewObj.AddComponent<Image>();
            NewImage.color = new Color(100, 100, 100, 255);
            NewImage.sprite = currentSprite;
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            NewObj.SetActive(true);
            
        }

        /*Instantiate(prefab,transform);
        Instantiate(prefab2, transform);
        Instantiate(prefab3, transform);
        Instantiate(prefab4, transform);
        Instantiate(prefab5, transform);
        Instantiate(prefab6, transform);
        Instantiate(prefab7, transform);
        Instantiate(prefab8, transform);
        Instantiate(prefab9, transform);
        Instantiate(prefab10, transform);
        Instantiate(prefab11, transform);
        Instantiate(prefab12, transform);
        Instantiate(prefab13, transform);
        Instantiate(prefab14, transform);
        Instantiate(prefab15, transform);*/
    }
    }

