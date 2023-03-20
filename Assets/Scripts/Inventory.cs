using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

int CoinAmount = 4;
int WheatAmount = 0;
public int MaxWheatAmount = 20;
int PotatoAmount = 0;
public int MaxPotatoAmount = 20;
int CarrotAmount = 0;
public int MaxCarrotAmount = 20;

public enum ItemType {Coin, Wheat, Potato, Carrot}

[SerializeField]TextMeshProUGUI CoinText;
[SerializeField]TextMeshProUGUI WheatText;
[SerializeField]TextMeshProUGUI PotatoText;
[SerializeField]TextMeshProUGUI CarrotText;
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        CoinText.SetText(CoinAmount.ToString());
        WheatText.SetText(WheatAmount.ToString()+"/"+MaxWheatAmount.ToString());
        PotatoText.SetText(PotatoAmount.ToString()+"/"+MaxPotatoAmount.ToString());
        CarrotText.SetText(CarrotAmount.ToString()+"/"+MaxCarrotAmount.ToString());
    }

    public bool ModifyAmount(ItemType item, int amount)
    {
        if(amount > 0)
        {
        switch(item)
            {
                case(ItemType.Coin):
                {
                    CoinAmount += amount;
                    UpdateUI();
                    return true;
                }
                case(ItemType.Wheat):
                {
                    if(WheatAmount+amount <= MaxWheatAmount)
                    {
                        WheatAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
                case(ItemType.Carrot):
                {
                    if(CarrotAmount+amount <= MaxCarrotAmount)
                    {
                        CarrotAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
                case(ItemType.Potato):
                {
                    if(PotatoAmount+amount <= MaxPotatoAmount)
                    {
                        PotatoAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
            }
        UpdateUI();
        return false;
        }
        else
        {
            switch(item)
            {
                case(ItemType.Coin):
                {
                    if(CoinAmount+amount >= 0)
                    {
                        CoinAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
                case(ItemType.Wheat):
                {
                    if(WheatAmount+amount >= 0)
                    {
                        WheatAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
                case(ItemType.Carrot):
                {
                    if(CarrotAmount+amount >= 0)
                    {
                        CarrotAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
                case(ItemType.Potato):
                {
                    if(PotatoAmount+amount >= 0)
                    {
                        PotatoAmount += amount;
                        UpdateUI();
                        return true;
                    }
                    else
                    {
                        UpdateUI();
                        return false;
                    }
                }
            }
        UpdateUI();
        return false;
        }

    }
}
