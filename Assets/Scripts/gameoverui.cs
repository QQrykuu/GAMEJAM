using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverui : MonoBehaviour
{
[SerializeField] Transform player;
[SerializeField] Button Restart;
[SerializeField] Button MainMenu;
Transform UI;

    void Start()
    {
        UI = transform.Find("UI");
        UI.gameObject.SetActive(false);

        Restart.onClick.AddListener(RS);
        MainMenu.onClick.AddListener(MM);
    }
    void Update()
    {
        if(player.GetComponent<HealthSystem>().healthAmount <= 0)
        {
            Time.timeScale = 0;
            UI.gameObject.SetActive(true);            
        }
    }

    void RS()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    void MM()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

}
