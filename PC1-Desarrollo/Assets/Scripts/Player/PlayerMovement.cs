using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D collider2D;
    private List<string> tags = new List<string>() { "Candy" };
    private float speed = 8f;
    private float maxVelocity = 4f;
    private Rigidbody2D body2D;
    private Animator animator;

    public GameObject gameControllerGO;
    public GameController gameControllerScript;
    private void Awake()
    {
        gameControllerGO = GameObject.Find("GameController");
        gameControllerScript = gameControllerGO.GetComponent<GameController>();
        collider2D = GetComponent<BoxCollider2D>();
        body2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
        PlayerWalkKeyboard();
    }

    void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(body2D.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            
        }
        else
        {
            
            body2D.velocity = Vector2.zero;
        }
        print(forceX);
        body2D.AddForce(new Vector2(forceX, 0));

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject ga = other.gameObject;
        if (tags.IndexOf(ga.tag) > -1)
        {
            ga.SetActive(false);
            gameControllerScript.score += 1;
            print(gameControllerScript.score);
        }
    }

}