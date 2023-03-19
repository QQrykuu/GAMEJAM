using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Farmland : MonoBehaviour
{
[SerializeField] SpriteRenderer tilled;
[SerializeField] SpriteRenderer crop;
[SerializeField] Sprite[] Potato;
[SerializeField] Sprite[] Carrot;
[SerializeField] Sprite[] Wheat;
[SerializeField] bool IsTilled;
[SerializeField] GameObject TillUI;
[SerializeField] Button TillButton;
[SerializeField] GameObject PlantUI;
[SerializeField] Transform InventoryUI;
[SerializeField] Button PButton;
[SerializeField] Button CButton;
[SerializeField] Button WButton;
float timerMax = 30f;
float timer = 0;   
int stage =0;
public enum CropType {Nothing, Potato, Carrot, Wheat}
public CropType SetCrop;
    void Start()
    {
        tilled.enabled = IsTilled;
        crop.enabled = false;
        SetCrop = CropType.Nothing;
        TillUI.SetActive(false);
        PlantUI.SetActive(false);

        TillButton.onClick.AddListener(TillFarmland);
        CButton.onClick.AddListener(PlantCarrot);
        PButton.onClick.AddListener(PlantPotato);
        WButton.onClick.AddListener(PlantWheat);

    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer < 30 && timer > 15)
            {
                stage = 0;
            }
            else if(timer >=0)
            {
                stage = 1;
            }
        }
        else
        {
            stage = 2;
        }

        if(SetCrop != CropType.Nothing)
        {
            switch(SetCrop)
            {
                case(CropType.Potato):
                {
                    crop.sprite = Potato[stage];
                }
                break;
                case(CropType.Carrot):
                {
                    crop.sprite = Carrot[stage];
                }
                break;
                case(CropType.Wheat):
                {
                    crop.sprite = Wheat[stage];
                }
                break;
            }
        }
    }

    void TillFarmland()
    {
        //add cost
        IsTilled = true;
        tilled.enabled = true;
        TillUI.SetActive(false);
        PlantUI.SetActive(true);//might be a problem
    }

    public void PlantCrop(CropType select)
    {
        if((IsTilled) && (SetCrop == CropType.Nothing))
        {
            TillUI.SetActive(false);
            PlantUI.SetActive(false);
            tilled.enabled = true;
            SetCrop = select;

            switch(SetCrop)
            {
                case(CropType.Potato):
                    crop.enabled = true;
                    crop.sprite = Potato[0];
                    SetCrop = CropType.Potato;
                break;
                case(CropType.Carrot):
                    crop.enabled = true;
                    crop.sprite = Carrot[0];
                    SetCrop = CropType.Carrot;
                break;
                case(CropType.Wheat):
                    crop.enabled = true;
                    crop.sprite = Wheat[0];
                    SetCrop = CropType.Wheat;                    
                break;

            }

            timer = timerMax;
        }
    }

    void OnMouseEnter()
    {
        if(!IsTilled)
        {
            TillUI.SetActive(true);
        }
        else
        {
            if(SetCrop == CropType.Nothing)
            {
                PlantUI.SetActive(true);
            }
        }
    }
    void OnMouseExit()
    {       
        if(!IsTilled)
        {
            TillUI.SetActive(false);
        }
        else
        {
            PlantUI.SetActive(false);            
        }
    }

    void PlantCarrot()
    {
        PlantCrop(CropType.Carrot);
    }
    void PlantPotato()
    {
        PlantCrop(CropType.Potato);        
    }
    void PlantWheat()
    {
        PlantCrop(CropType.Wheat);        
    }
    
    void OnMouseDown()
    {
        Debug.Log(SetCrop);
        Debug.Log(timer);
        if(SetCrop != CropType.Nothing && timer <= 0)
        {
            switch(SetCrop)
            {
                case(CropType.Potato):
                    if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Potato, 1))
                    {
                        SetCrop = CropType.Nothing;
                        crop.enabled = false;
                    }
                    else
                    {
                        Debug.Log("inventory full");
                    }
                break;
                case(CropType.Wheat):
                    if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Wheat, 1))
                    {
                        SetCrop = CropType.Nothing;
                        crop.enabled = false;
                    }
                    else
                    {
                        Debug.Log("inventory full");
                    }
                break;
                case(CropType.Carrot):
                    if(InventoryUI.GetComponent<Inventory>().ModifyAmount(Inventory.ItemType.Carrot, 1))
                    {
                        SetCrop = CropType.Nothing;
                        crop.enabled = false;
                    }
                    else
                    {
                        Debug.Log("inventory full");
                    }
                break;

            }
        }
    }
}
