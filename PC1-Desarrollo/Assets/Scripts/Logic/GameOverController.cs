using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [Header("Botones")]
    public Button btnBack;

    void Start()
    {
        btnBack.onClick.AddListener(() => goGameOver());

    }

    void goGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


}
