using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
[SerializeField] TextMeshProUGUI WeaponUPGcost;
[SerializeField] Transform Player;
[SerializeField] Transform InventoryUI;
[SerializeField] Button SellW;
[SerializeField] Button SellC;
[SerializeField] Button SellP;

[SerializeField] Button MaxW;
[SerializeField] Button MaxP;
[SerializeField] Button MaxC;
[SerializeField] Button MaxHP;
[SerializeField] Button SPD;

[SerializeField] Button Wep;
[SerializeField] Sprite[] WeaponSprites;
[SerializeField] Transform[] Weapons;
int CurrentWeaponClass = 0;

    void Start()
    {
        SellW.onClick.AddListener(SW);
        SellC.onClick.AddListener(SC);
        SellP.onClick.AddListener(SP);

        MaxW.onClick.AddListener(MW);
        MaxP.onClick.AddListener(MP);
        MaxC.onClick.AddListener(MC);

        SPD.onClick.AddListener(SPEED);
        MaxHP.onClick.AddListener(HP);

        Wep.onClick.AddListener(UpgradeWeapon);
    }

    void SW()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Wheat, -1))
        {
            InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, 5);
        }
    }
    void SC()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Carrot, -1))
        {
            InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, 3);
        }
    }
    void SP()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Potato, -1))
        {
            InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, 1);
        }       
    }
    ///////////////////////////////////////////////////////////////////////
    void MW()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -60))
        {
            InventoryUI.GetComponent<Inventory>().MaxWheatAmount += 5;
            InventoryUI.GetComponent<Inventory>().UpdateUI();
        }
    }
    void MC()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -20))
        {
            InventoryUI.GetComponent<Inventory>().MaxCarrotAmount += 5;  
            InventoryUI.GetComponent<Inventory>().UpdateUI();          
        }
    }
    void MP()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -40))
        {
            InventoryUI.GetComponent<Inventory>().MaxPotatoAmount += 5;   
            InventoryUI.GetComponent<Inventory>().UpdateUI();           
        }
        
    }

    void SPEED()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -80))
        {
            Player.GetComponent<PlayerController>().PlayerSpeed += Player.GetComponent<PlayerController>().PlayerSpeed*0.1f;
        }
    }
    void HP()
    {
        if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -80))
        {
            Player.GetComponent<HealthSystem>().healthAmountMax += Player.GetComponent<HealthSystem>().healthAmountMax*0.1f;
        }        
    }

    void UpgradeWeapon()
    {
        switch(CurrentWeaponClass)
        {
            case(0):
            {
                if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -50))
                {
                    CurrentWeaponClass = 1;
                    Wep.transform.Find("Image").GetComponent<Image>().sprite = WeaponSprites[1];
                    WeaponUPGcost.text = "75";
                    Weapons[0].gameObject.SetActive(false);
                    Weapons[1].gameObject.SetActive(true);
                }                      
            }
            break;
            case(1):
            {
                if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -75))
                {
                    CurrentWeaponClass = 2;
                    Wep.transform.Find("Image").GetComponent<Image>().sprite = WeaponSprites[2];
                    WeaponUPGcost.text = "125";
                    Weapons[1].gameObject.SetActive(false);
                    Weapons[2].gameObject.SetActive(true);
                }                      
            }
            break;
            case(2):
            {
                if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -125))
                {
                    CurrentWeaponClass = 3;
                    Wep.transform.Find("Image").GetComponent<Image>().sprite = WeaponSprites[3];
                    WeaponUPGcost.text = "150";
                    Weapons[2].gameObject.SetActive(false);
                    Weapons[3].gameObject.SetActive(true);
                }                      
            }
            break;
            case(3):
            {
                if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Coin, -150))
                {
                    CurrentWeaponClass = 4;
                    Wep.gameObject.SetActive(false);
                    Weapons[3].gameObject.SetActive(false);
                    Weapons[4].gameObject.SetActive(true);
                }                      
            }
            break;
        }
    }
    
}
