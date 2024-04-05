using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LaneGenerator : MonoBehaviour
{

    public GameObject player;
    public GameObject startingArea;
    public GameObject point;
    public CinemachineVirtualCamera virtualCamera;

    public float laneStaticDimension = 3.0f;

    private ArrayList laneObjects = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        generate();
        Destroy(startingArea, 10);
    }

    // Update is called once per frame
    void Update()
    {
        destroy();
    }

    void generate()
    {

        Vector3 previousPosition = startingArea.transform.position;
        Vector3 previousScale = startingArea.transform.localScale;

        //string[] lanes = {"002:12", "004:20", "005:6", "008:6", "009:7", "010:0", "010:6", "011:9", "016:6" };
        //int[] lanes = { 180, 208, 108, 295, 90, 86, 82, 106, 438 };
        float[] lanes = {
            3.50f, 5.14f, 2.67f, 7.33f, 2.17f, 2.12f, 2.02f, 2.62f, 11.81f, 4.84f,
            5.09f, 10.17f, 1.98f, 2.32f, 2.07f, 12.52f, 2.00f, 1.93f, 1.85f, 1.85f,
            2.05f, 6.72f, 2.1f, 2.0f, 2.2f, 2.3f, 9.65f, 2.44f, 1.95f, 1.85f,
            15.14f, 2.15f, 1.04f, 0.96f, 2.05f, 4.8f, 6.96f, 0.99f, 0.99f, 0.94f,
            0.99f, 1.5f, 13.28f, 2.94f, 2.42f, 2.35f, 2.17f, 2.86f, 1.8f, 3.00f,
            100.0f
        };



        for (int i = 0; i < lanes.Length; i++)
        {


            float length = lanes[i];
            print(length);

            GameObject laneObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //give a RGB color to the lane
            laneObject.GetComponent<Renderer>().material.color = new Color(0.434f, 0.877f, 0.562f);

            if (i % 2 == 0)
            {
                if (i == 0)
                {
                    laneObject.transform.position = new Vector3(0, 0, (previousPosition.z + previousScale.z / 2) + length);
                    laneObject.transform.localScale = new Vector3(laneStaticDimension, 1, length * 2);
                    previousPosition = laneObject.transform.position;
                    previousScale = laneObject.transform.localScale;
                }
                else
                {
                    laneObject.transform.position = new Vector3((previousPosition.x + previousScale.x / 2) - laneStaticDimension / 2, 0, (previousPosition.z + previousScale.z / 2) + length);
                    laneObject.transform.localScale = new Vector3(laneStaticDimension, 1, length * 2);
                    previousPosition = laneObject.transform.position;
                    previousScale = laneObject.transform.localScale;
                }
            }
            else
            {
                laneObject.transform.position = new Vector3((previousPosition.x + previousScale.x / 2) + length, 0, (previousPosition.z + previousScale.z / 2) - laneStaticDimension / 2);
                laneObject.transform.localScale = new Vector3(length * 2, 1, laneStaticDimension);
                previousPosition = laneObject.transform.position;
                previousScale = laneObject.transform.localScale;
            }
            laneObjects.Add(laneObject);            
        }
    }



    void destroy()
    {
        for (int i = 0; i < laneObjects.Count; i++)
        {
            if (laneObjects.Count < 5)
            {
                
                virtualCamera.m_Lens.OrthographicSize += 0.00004f;
                // get current camera background color
                Color currentColor = Camera.main.backgroundColor;
                // make it lighter gradually
                Camera.main.backgroundColor = Color.Lerp(currentColor, Color.white, 0.00004f);
                // stop following the player
                virtualCamera.Follow = null;

            }
            GameObject laneObject = (GameObject)laneObjects[i];
            if ((player.transform.position.z - laneObject.transform.position.z > 30) && (player.transform.position.x - laneObject.transform.position.x > 1 || player.transform.position.x - laneObject.transform.position.x < -1))
            {
                Destroy(laneObject);
                laneObjects.RemoveAt(i);
            } else if ((player.transform.position.x - laneObject.transform.position.x > 30) && (player.transform.position.z - laneObject.transform.position.z > 1 || player.transform.position.z - laneObject.transform.position.z < -1))
            {
                Destroy(laneObject);
                laneObjects.RemoveAt(i);
            }
        }

    }
}
