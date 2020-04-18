using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collector : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D collider2D;
    private List<string> tags = new List<string>(){"Candy"};
    public GameObject gameControllerGO;
    public GameController gameControllerScript;
    void Start()
    {
        gameControllerGO = GameObject.Find("GameController");
        gameControllerScript = gameControllerGO.GetComponent<GameController>();
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject ga = other.gameObject;
        if(tags.IndexOf(ga.tag) > -1){
            ga.SetActive(false);
            gameControllerScript.vidas -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
