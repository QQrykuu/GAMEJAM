using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
[SerializeField]Transform Player;
[SerializeField]Transform DoorControl;
public bool unlocked;
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
}
