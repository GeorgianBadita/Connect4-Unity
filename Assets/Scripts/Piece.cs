using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    //destination coordinates for piece
    public float xDest;
    public float yDest;

    //Piece speed
    float speed;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != xDest || transform.position.y != yDest)
        {
            speed = 3.5f;
            transform.position = Vector3.Lerp(transform.position, new Vector3(xDest, yDest, -Camera.main.transform.position.z),speed*Time.deltaTime);
        }   
    }
}
