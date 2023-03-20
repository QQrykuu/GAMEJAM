using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
[SerializeField] Transform InventoryUI;
[SerializeField] Button SellW;
[SerializeField] Button SellC;
[SerializeField] Button SellP;

    void Start()
    {
        SellW.onClick.AddListener(SW);
        SellC.onClick.AddListener(SC);
        SellP.onClick.AddListener(SP);
    }

    void SW()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Wheat, -1))
        {
            InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, 1);
        }
    }
    void SC()
    {
        
    }
    void SP()
    {
        
    }
}
