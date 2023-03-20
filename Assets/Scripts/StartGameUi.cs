using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameUi : MonoBehaviour
{
[SerializeField] Button Exit;
[SerializeField] Button Starte;
Transform UI;

    void Start()
    {
        Exit.onClick.AddListener(RS);
        Starte.onClick.AddListener(MM);
    }

    void RS()
    {
        Application.Quit();
    }
    void MM()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

}
