using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool isRight;
    private Vector3 currentDirection;
    public Text runeCountText;
    public CinemachineVirtualCamera virtualCamera;

    private int runeCount = 0;
    
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // start moving
        move();
        transform.Translate(currentDirection * speed * Time.deltaTime);
        runeCountText.text = "Runes: " + runeCount + " / 3";
    }

    void move()
    {
        // get space input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            print(count);
            //if (count == 10)
            //{
                // set cinemachine camera position to -3, -3, -3
                //virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(3, 8, -3);
                // set cinemachine camera rotation to 0, 0, 0
                //virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = new Vector3(15, 20, 0);
            //}
            // change direction
            if (isRight)
            {
                currentDirection = new Vector3(0, 0, 1);
            }
            else
            {
                currentDirection = new Vector3(1, 0, 0);
            }
            isRight = !isRight;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rune"))
        {
            runeCount++;
            print("Rune collected");
            Destroy(other.gameObject);
        }
    }
}
