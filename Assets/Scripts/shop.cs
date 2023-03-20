using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
[SerializeField] private Transform Inventory;
[SerializeField] private Transform Player;
[SerializeField] private Transform ShopUI;
bool ShopOpened = false;

    void Start()
    {
        updateUI();
    }
    private void OnMouseDown()
    {
        if(ShopOpened == false)
        {
            if(Vector2.Distance(transform.position, Player.transform.position) < 3)
            {
                ShopOpened = true;
                updateUI();                
            }
            else{
                ShopOpened = false;
                updateUI();
            }
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            ShopOpened = false;
            updateUI();
        }
    }

    void updateUI()
    {
        if(ShopOpened)
        {
            ShopUI.gameObject.SetActive(true);
        }
        else
        {
            ShopUI.gameObject.SetActive(false);
        }
    }
}
