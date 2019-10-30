using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    public Text boxValueText;
    public GameObject shopPanel;
    public Button shopPanelCross;
    
    // Use this for initialization
    void Start()
    {
        boxValueText.text = "SHOP";
    }
    public void ExitShop()
    {
            shopPanel.gameObject.SetActive(false);
    }
    public void ButtonClick()
    {
            shopPanel.gameObject.SetActive(true);
            shopPanelCross.gameObject.SetActive(true);
    }
}
