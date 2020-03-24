using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    
    public float Speed;


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //functions
    void PlayerMovement()
    {


        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float y = 0;

        if (Input.GetKey(KeyCode.Space)) 
        {

            y += 2;
        
        }

        Vector3 movingPlayer = new Vector3(hor, y, ver) * Speed;

        transform.Translate(movingPlayer, Space.Self);

    }


}