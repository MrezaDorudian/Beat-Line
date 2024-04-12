using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool isRight;
    private Vector3 currentDirection;
    public Text runeCountText;
    public CinemachineVirtualCamera virtualCamera;
    public Canvas blackScreenCanvas;

    public bool gameStarted = false;
    public AudioSource audioSource;

    private int runeCount = 0;
    
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // disable black screen canvas
        blackScreenCanvas.enabled = false;
        currentDirection = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // start moving
        if (gameStarted)
        {
            checkFall();
            move();
            transform.Translate(currentDirection * speed * Time.deltaTime);
            runeCountText.text = "Runes: " + runeCount + " / 3";
        }
    }

    void move()
    {

        if (count > 10 && count < 35)
        {
            // slowly change the rotation of the camera
            //virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY, -0.5f, Time.deltaTime);
            //camera slowly zooms out
            //virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, 60.0f, Time.deltaTime);
        }

        // get space input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            print(count);

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

    public IEnumerator reloadScene()
    {
        // wait for 5 seconds
        yield return new WaitForSeconds(2);

        // show black screen to indicate the scene is reloading
        blackScreenCanvas.enabled = true;
        yield return new WaitForSeconds(3);

        Application.LoadLevel(Application.loadedLevel);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("FirstScene"));



    }

    void checkFall()
    {
        if (transform.position.y < -1)
        {
            virtualCamera.Follow = null;

            // reload the scene after 5 seconds

            StartCoroutine("reloadScene");
        }
    }
}
