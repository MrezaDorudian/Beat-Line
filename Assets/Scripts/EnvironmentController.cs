using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public PlayerController player;
    public GameObject[] environmentObjects;
    // float arraylist to store the random values for the environment objects
    private float[] randomValuesX = new float[3];
    private float[] randomValuesY = new float[3];
    private float[] randomValuesZ = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        // get the environment objects
        environmentObjects = GameObject.FindGameObjectsWithTag("Environment");

        // generate random values for the environment objects
        for (int i = 0; i < environmentObjects.Length; i++)
        {
            randomValuesX[i] = Random.Range(-0.0001f, 0.0005f);
            randomValuesY[i] = Random.Range(0.001f, 0.002f);
            randomValuesZ[i] = Random.Range(-0.001f, 0.0005f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // make the environment objects fly to the air slowly and in towards different directions
        if (player.gameStarted)
        {
            for (int i = 0; i < environmentObjects.Length; i++)
            {
                environmentObjects[i].transform.position = new Vector3(environmentObjects[i].transform.position.x + randomValuesX[i], environmentObjects[i].transform.position.y + randomValuesY[i], environmentObjects[i].transform.position.z + randomValuesZ[i]);
            }
        }
    }
}
