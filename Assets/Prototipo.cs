using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototipo : MonoBehaviour
{   
    public GameObject bola1, bola2;

    Rigidbody2D rb1;

    int velX, velY;
    /*
    public float distMax;
    float distX, distY;
    */

    // Start is called before the first frame update
    void Start(){
        rb1 = bola1.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            
            // Up and Down
            if(Input.GetKey(KeyCode.W))
                velY += 3;
            if(Input.GetKey(KeyCode.S))
                velY -= 3;

            // Left and Right
            if(Input.GetKey(KeyCode.A)){
                velX -= 3;
                velY -= 2;
            }
            if(Input.GetKey(KeyCode.D)){
                velX += 3;
                velY -= 2;
            }

            rb1.velocity = new Vector2(velX,velY);

            velX = 0;
            velY = 0;
        }

        if(Input.GetKeyUp(KeyCode.Space))
            Debug.Log( "Space key was released." );
        /*
        distX = Mathf.Abs(bola1.transform.position.x) + Mathf.Abs(bola2.transform.position.x);
        distY = Mathf.Abs(bola1.transform.position.y) + Mathf.Abs(bola2.transform.position.y);

        if(distMax < Mathf.Sqrt(distX*distX + distY*distY))
            bola1.transform.position.x = bola1.transform.position.x - 0.1;
        else
            Debug.Log("Sergio");
        */
    }  
}
