using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelFarm : MonoBehaviour
{
    public GameObject currentBlockType;

    public float depth = -5f;

    public float freq = 10f;
    public float amp = 10f;

    

    private Vector3 myPos;

    // Start is called before the first frame update
    void Start()
    {

        generateTerrain();
        
    }

    void generateTerrain() 
    {

        myPos = this.transform.position;
        

        int cols = 100;
        int rows = 100;

        float y;

        for (int x = 0; x < cols; x++) 
        {

            for (int z = 0; z < rows; z++)
            {

                //setting y to the value of the derived perlin noise
                y = Mathf.PerlinNoise((myPos.x + x)/freq, (myPos.z + z)/freq ) * amp;

                //y = Mathf.Floor(y);

                GameObject newBlock = GameObject.Instantiate(currentBlockType);

                newBlock.transform.position = new Vector3(myPos.x + x, y, myPos.z + z);



                /*for (float i = 0; y > depth; y--) 
                {


                    GameObject newBlockUnderground = GameObject.Instantiate(currentBlockType);

                    newBlockUnderground.transform.position = new Vector3(myPos.x + x, y-i, myPos.z + z);

                }*/
                


              
            }
        }
        //end nested for loop
    } 
}
