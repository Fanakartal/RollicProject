using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static GameStateScript;

public class CharController : MonoBehaviour
{
    /*
     * public GameObject touchArea;

    //-----------------------

    

    private float speed = 16.0f;

     */

    public GameObject gameManager;
    
    private Camera mainCam;
    public Vector2 touchStartPos;
    private bool canMove; 

    private float speed = 15.0f;

    public float xBoundry;
    public float negXBoundry;

    public Transform levelEnd;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        mainCam = Camera.main;

        canMove = false;

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<ManagerScript>().gameState == GameStateScript.GameState.Playing)
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -5.0f);
        
        //if(gameManager.GetComponent<ManagerScript>().gameState != GameState.Playing)
        //    GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        if (transform.position.z <= levelEnd.position.z)
            gameManager.GetComponent<ManagerScript>().gameState = GameState.Waiting;

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetAxis("Horizontal") != 0)
        {
            // Debug.Log(Input.GetAxis("Horizontal"));
            transform.position = new Vector3((transform.position.x - (Input.GetAxis("Horizontal") * speed * Time.deltaTime)), transform.position.y, transform.position.z);
        }
#endif

#if UNITY_IOS || UNITY_ANDROID

        switch (gameManager.GetComponent<ManagerScript>().gameState)
        {
            case GameState.Playing :
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);         
            
                    switch (touch.phase)
                    {
                        // Record initial touch position.
                        case TouchPhase.Began:                   
                            touchStartPos = touch.position;

                            Debug.Log("Began: " + mainCam.ScreenToWorldPoint(touchStartPos));// + "pixel: " + startPos);
                            
                            canMove = true;

                            break;
                
                        // Determine direction by comparing the current touch position with the initial one.
                        case TouchPhase.Moved:
                        case TouchPhase.Stationary:
                            if (canMove)
                            {

                                transform.position = new Vector3(mainCam.ScreenToWorldPoint(touch.position).x,  
                                    0.0f, 0.0f);

                                /*direction = touch.position - startPos;
                                Debug.Log("Moved to: " + direction.normalized.y + " in norm pixels, and " + mainCam.ScreenToWorldPoint(direction.normalized).y + " in world space.");*/
                            }

                            break;
                
                        // Report that a direction has been chosen when the finger is lifted.
                        case TouchPhase.Ended:
                            Debug.Log("Ended at" + mainCam.ScreenToWorldPoint(touch.position));
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
