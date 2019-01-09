using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    /// <summary>
    /// This large script controls the character. This controls the in-game UI, grapple attachment
    /// </summary>

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private GameObject barrierObject;

    [SerializeField]
    private AudioClip attach;

    [SerializeField]
    private AudioClip detach;

    [SerializeField]
    private AudioClip fail;

    [SerializeField]
    private Text score;

    [SerializeField]
    private Text Highscore;

    [SerializeField]
    private Transform playerResetLocation;

    private Transform selfTransform;
    private Rigidbody self;
    private bool isInRange = false;
    private Transform m_colliderTransform = null;
    private Rigidbody m_colliderRigid;
    private HingeJoint hinge;
    private AudioSource playerSound;
    private bool connected = false;
    private bool canConnect = false;
    private bool movementEnabled = true;
    private bool respawn = true;

    [SerializeField]
    private Sprite lifeloss;

    private bool LevelFinished;

    [SerializeField]
    private Image life1;
    [SerializeField]
    private Image life2;
    [SerializeField]
    public Image life3;
    [SerializeField]
    public Image life4;
    [SerializeField]
    public Image life5;


    

    [SerializeField]
    private GameObject gameOverSprite;
    [SerializeField]
    private GameObject next;

    

    
    








    // Use this for initialization
    void Start()
    {


        selfTransform = GetComponent<Transform>();
        playerResetLocation = selfTransform;
        playerSound = GetComponent<AudioSource>();
        self = GetComponent<Rigidbody>();
        LevelFinished = false;
        next.SetActive(false);

        SendMessage("UpdateScore");
        

        
        gameOverSprite.SetActive(false);
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (movementEnabled) //if the player has not reached the end of the level, movement controls are enabled
        {
            self.AddForce(0.0f, 0.0f, Input.GetAxis("Horizontal") * speed);           

            //When the player is presses the space key while in range of a grapple point, the score increases by 10 and calls the method "Connect()"
            //When the space key is released, it calls the method "Disconnect()"

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if (isInRange)
                {
                    if (!connected)
                    {
                        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
                        SendMessage("UpdateScore");
                        Connect();
                    }
                }
                

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (isInRange)
                    DisConnect();
            }
        }

        //When losing a life or advancing a level, the UI hearts are changed to the empty heart sprite.
        //When the player runs out of lives, movement controls are disabled and the Game Over UI appears
        switch (PlayerPrefs.GetInt("Lives")) {
            case 4:
                life1.sprite = lifeloss;
                break;
            case 3:
                life1.sprite = lifeloss;
                life2.sprite = lifeloss;

                break;
            case 2:
                life1.sprite = lifeloss;
                life2.sprite = lifeloss;
                life3.sprite = lifeloss;

                break;
            case 1:
                life1.sprite = lifeloss;
                life2.sprite = lifeloss;
                life3.sprite = lifeloss;
                life4.sprite = lifeloss;

                break;
            case 0:
                life5.sprite = lifeloss;
                movementEnabled = false;
                gameOverSprite.SetActive(true);                
                break;              
            
        }

        
        //When the player makes contact with the finishing platform and the E key is pressed, the player advances to 1 of 5 levels chosen at random and the score is increased by 100
        if (LevelFinished)
        {
            if (Input.GetKey(KeyCode.E))
            {
                int randomLevel = Random.Range(1, 5);

                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);

                print(PlayerPrefs.GetInt("Score"));

                SendMessage("UpdateScore");

                SceneManager.LoadScene(randomLevel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //When the player object collides with the grapple point collider, the transform and rigidbody of the point is acquired and is made non-kinematic, meaning it can be moved with force
        //The colour of the point is also changed to visually indicate the to the player that they are in range and can attach to it
        //Since the player object can rotate freely around a point that is set just above it, it can sometimes rotate outside of the collider which causes a bug where you can attach to the same point even when you should be out of range
        if (other.CompareTag("Grapple Point")) 
            
        {
            canConnect = true;
            m_colliderTransform = other.GetComponent<Transform>();
            m_colliderRigid = other.GetComponent<Rigidbody>();
            m_colliderRigid.isKinematic = false;
            if (other.GetComponent<Light>())
            {
                other.GetComponent<Light>().color = Color.cyan;
            }
            isInRange = true;
        }
        //if the player collides with the finishing platform, a prompt appears, indicating that the player can advance to the next level
        else if (other.CompareTag("Finish"))
        {
            LevelFinished = true;
            next.SetActive(true);

        }
        //If the player collides with anything else (such as terrain or hazards) the player automatically disconnects from a grapple point if it is connected, reduces the number of lives by 1, plays a failure sound effect and spawns the player back at the start
        else 
        {
            connected = false;
            DisConnect();

            int tempLives = PlayerPrefs.GetInt("Lives");

            tempLives = tempLives - 1;           
            
            print("Life Lost - " + tempLives);

            PlayerPrefs.SetInt("Lives", tempLives);

            playerSound.clip = fail;
            playerSound.Play();
            if(tempLives > 0)
            {
                
                print("respawn");
                SendMessage("Reset");
                
                
            }                           
            else
            {
                gameOverSprite.SetActive(true);

                print("Game Over");
            }
        }
        
    }
    //When the player object leaves a grapple collider, it changes the colour of the point object to its default colour and makes the point kinematic again
    private void OnTriggerExit(Collider other)
    {
        if (!connected)
        {
            canConnect = false;
            if (other.GetComponent<Light>())
            {
                other.GetComponent<Light>().color = Color.blue;
            }
            isInRange = false;
            m_colliderRigid.isKinematic = true;
        }
    }

    //This method boosts the speed of the player, plays an attachment sound effect and spawns a hinge component on the player object an sets the connectedbody field of the component to the rigidbody of the grapple point.
    private void Connect()
    {
        if (canConnect)
        {
            speed = 10.0f;
            playerSound.clip = attach;
            playerSound.Play();

            gameObject.AddComponent<HingeJoint>();
            hinge = transform.GetComponent<HingeJoint>();
            hinge.connectedBody = m_colliderRigid;
            hinge.enablePreprocessing = false;

            

            connected = true;
        }
    }

    //This method reverts the speed back to default and deletes the hinge joint component, releasing the player from the point.
    private void DisConnect()
    {
        if (canConnect)
        {
            speed = 5.0f;
            Destroy(transform.GetComponent<HingeJoint>());
            playerSound.clip = detach;
            playerSound.Play();
            connected = false;


        }
    }

    //This method resets the player's velocity to zero, preventing the player from gaining unwanted momentum when respawning
    private void Reset()
    {
        self.velocity = new Vector3(0.0f, 0.0f, 0.0f);     


    }

    //this method updates the score playerpref variable and updates the UI score
    private void UpdateScore()
    {

        int tempScore = PlayerPrefs.GetInt("Score");
        

        score.text = "Score - " + tempScore;

        
    }

    //this method checks to see if the score variable is higher or equal to the highest score and changes it if true
    private void UpdateHighScore()
    {
        int tempScore = PlayerPrefs.GetInt("Score");
        int tempHighScore = PlayerPrefs.GetInt("Highscore");

        if(tempScore >= tempHighScore)
        {
            tempHighScore = tempScore;
        }
        score.text = "HighScore - " + tempHighScore;

    }

}
