using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molino : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mov;
    public float velocity = -10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mov.Rotate(0f, 0f, velocity*Time.deltaTime);
    }
}
