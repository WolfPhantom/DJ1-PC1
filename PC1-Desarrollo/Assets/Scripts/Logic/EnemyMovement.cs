using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
 
    private Rigidbody2D body;
    public float velocidad;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        velocidad = velocidad == 0 ? -2 : velocidad;
        
    }

    
    void Update()
    {
        body.velocity = new Vector2(0.0f, velocidad);
    }
}
