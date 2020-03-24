using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPesonCameraController : MonoBehaviour
{

    //Variables
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public Transform Obstruction;
    float zoomSpeed = 2f;





    // Start is called before the first frame update
    void Start()
    {
    
        //hides curser upon running
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Obstruction = Target;

    }

    private void LateUpdate()
    {

        CamControl();

        //ViewObstructed();

    }

    //Roation and movement of camera
    void CamControl() 
    {

        mouseX += Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;


        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);


        if (Input.GetKey(KeyCode.LeftShift))
        {

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        }
        else
        {

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);

        }


    }

    //function
    void ViewObstructed() 
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {

            if (hit.collider.gameObject.tag != "Player") 
            {

                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;


                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f) 
                {

                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                
                }


            }
            else
            {

                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;


                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                {

                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);

                }

            }

        }
       
    }

}
