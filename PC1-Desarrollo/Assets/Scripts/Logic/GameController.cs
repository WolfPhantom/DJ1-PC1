using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    
    [Header("Obstacles Prefabs")]
    public List<GameObject> elementos = new List<GameObject>();
    [Header("Start position element")]
    
    [Header("HUD")]
    public Text txtScore;
   

    private List<GameObject> pool = new List<GameObject>();
    private float generationTime = 4f;
    public float score = 0f;
    public float vidas = 5;
    private float timeElapsed = 0f;
    void Start()
    {

        generatePoolObjects();
    }

    void generatePoolObjects() {
        int scale = 4;
        for (int i=0;i< elementos.Count;i++) {
            for (int j=0;j< elementos.Count; j++) {
                GameObject ga = Instantiate(elementos[i], new Vector3(Random.Range(-4.0f,4.0f), 0.0f, 1.0f), Quaternion.identity);
                scale = ga.tag == "Candy" ? 1 : -1;
                ga.transform.localScale = new Vector3(0.5f*scale, 0.5f, 1.0f);
                ga.SetActive(false);
                pool.Add(ga);
            }
        }
    }
        

    public string getScore(){
        return score.ToString();
    }

  
   
    void Update()
    {
        timeElapsed += Time.deltaTime;
        //print("TIEMPO: " + timeElapsed);
        txtScore.text = score.ToString();

        if (timeElapsed >= generationTime) {
            print("hello");
           timeElapsed = 0f;
           GetFirstDead();
        }
        if (vidas == 0) 
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void GetFirstDead() {
       while(true){
           print("getFirstDead");
           int index = Random.Range(0,pool.Count);
           if(!pool[index].activeInHierarchy){
               print("Become active");
               pool[index].SetActive(true);
               pool[index].transform.position 
                            = new Vector3(Random.Range(-4.0f, 4.0f), transform.position.y,0);
                break;
           }else{
               index = Random.Range(0,pool.Count);
           }
       }
    }

    GameObject getNext() {
        int index = Random.Range(0, elementos.Count - 1);
        return elementos[index];
    }
}
