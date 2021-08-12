using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateScript;

public class CharController : MonoBehaviour
{
    /*
     * public GameObject touchArea;

    public Vector2 startPos;

    public float yBoundry;
    public float negYBoundry;

    //-----------------------

    private Camera mainCam;

    private float speed = 16.0f;

    private bool canMove;  */

    public GameObject gameManager;
    

    private float speed = 15.0f;

    public float xBoundry;
    public float negXBoundry;

    public Transform levelEnd;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<ManagerScript>().gameState == GameState.Playing)
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -5.0f);

        if (transform.position.z <= levelEnd.position.z)
            gameManager.GetComponent<ManagerScript>().gameState = GameState.Won;

        if (Input.GetAxis("Horizontal") != 0)
        {
            // Debug.Log(Input.GetAxis("Horizontal"));
            transform.position = new Vector3((transform.position.x - (Input.GetAxis("Horizontal") * speed * Time.deltaTime)), transform.position.y, transform.position.z);
        }

        #if MOBILE_INPUT

        switch (gameManager.GetComponent<GameManager>().gameState)
        {
            case GameStateScript.GameState.Playing :
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);         
            
                    switch (touch.phase)
                    {
                        // Record initial touch position.
                        case TouchPhase.Began:                   
                            startPos = touch.position;

                            Debug.Log("Began: " + mainCam.ScreenToWorldPoint(startPos));// + "pixel: " + startPos);
                            Debug.Log("TouchArea: " + touchArea.transform.position);
                            //Debug.Log(touchArea.GetComponent<CircleCollider2D>().OverlapPoint(mainCam.ScreenToWorldPoint(startPos)));

                            if (touchArea.GetComponent<CircleCollider2D>().OverlapPoint(mainCam.ScreenToWorldPoint(startPos))) //touchArea.GetComponent<CircleCollider2D>().bounds.Contains(startPos))
                            {
                                Debug.Log("ContainsFinger");
                                canMove = true;
                            }
               
                            break;
                
                        // Determine direction by comparing the current touch position with the initial one.
                        case TouchPhase.Moved:
                        case TouchPhase.Stationary:
                            if (canMove)
                            {

                                transform.position = new Vector3(transform.position.x, mainCam.ScreenToWorldPoint(touch.position).y, transform.position.z);

                                /*direction = touch.position - startPos;
                                Debug.Log("Moved to: " + direction.normalized.y + " in norm pixels, and " + mainCam.ScreenToWorldPoint(direction.normalized).y + " in world space.");*/
                            }

                            break;
                
                        // Report that a direction has been chosen when the finger is lifted.
                        case TouchPhase.Ended:
                            Debug.Log("Ended");
                            canMove = false;
                            break;
                    }
                }
                break;
            }
        #endif

        if (transform.position.x > xBoundry)
            transform.position = new Vector3(xBoundry, transform.position.y, transform.position.z);

        if (transform.position.x < negXBoundry)
            transform.position = new Vector3(negXBoundry, transform.position.y, transform.position.z);
    }
}
