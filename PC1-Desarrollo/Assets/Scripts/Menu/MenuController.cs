using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Botones")]
    public Button btnPlay;

    void Start()
    {
        btnPlay.onClick.AddListener(() => goGame());
       
    }

    void goGame() {
        SceneManager.LoadScene("Game");
    }

 


}
