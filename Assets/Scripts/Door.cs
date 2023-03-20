using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{
[SerializeField]Transform Player;
[SerializeField]Transform DoorControl;
[SerializeField]Transform CostUI;
[SerializeField] int OpenCost;
[SerializeField] Button Unlock;
[SerializeField] Transform InventoryUI;
TextMeshProUGUI BtnTxt;
public bool unlocked;

    void Start()
    {
        Unlock.onClick.AddListener(UnlockDoor);
        BtnTxt = Unlock.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        BtnTxt.SetText(" Unlock: "+ OpenCost);
        CostUI.gameObject.SetActive(false);
    }
    void Update()
    {
        if(unlocked)
        {
            if(Player !=null)
            {
                if(Vector2.Distance(transform.position, Player.position) < 2)
                {
                    DoorControl.gameObject.SetActive(false);
                }
                else
                {
                    DoorControl.gameObject.SetActive(true);                   
                }
            }
        }
    }

    void OnMouseEnter()
    {
        if(!unlocked)
        {
            CostUI.gameObject.SetActive(true);
        }
    }
    void OnMouseExit()
    {       
        if(!unlocked)
        {
            CostUI.gameObject.SetActive(false);
        }
    }

    void UnlockDoor()
    {        
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -OpenCost))
        {
            unlocked = true;
            CostUI.gameObject.SetActive(false);
        }
    }
    
}
