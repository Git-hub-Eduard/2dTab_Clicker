using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShopCanvas;
    
    
    public void OpenShop()
    {
        ShopCanvas.SetActive(true);
    }
    public void CloseShop()
    {
        ShopCanvas.SetActive(false);
    }
}
