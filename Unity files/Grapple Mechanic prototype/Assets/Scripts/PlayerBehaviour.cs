using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

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

    private Rigidbody self;
    private bool isInRange = false;
    private Transform m_colliderTransform = null;
    private Rigidbody m_colliderRigid;
    private HingeJoint hinge;
    private AudioSource playerSound;
    private bool connected = false;
    private bool canConnect = false;
    private bool movementEnabled = true;

    private ParticleSystem trail;

    [SerializeField]
    private Sprite lifeloss;

    private bool LevelFinished;

    public Image life1;
    public Image life2;
    public Image life3;
    public Image life4;
    public Image life5;


    private int life  = 5;

    [SerializeField]
    private GameObject gameOverSprite;
    [SerializeField]
    private GameObject next;







    // Use this for initialization
    void Start()
    {
        playerSound = GetComponent<AudioSource>();
        self = GetComponent<Rigidbody>();
        LevelFinished = false;
        next.SetActive(false);
        

        trail = GetComponent<ParticleSystem>();
        trail.Stop();
        gameOverSprite.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            self.AddForce(0.0f, 0.0f, Input.GetAxis("Horizontal") * speed);

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                trail.Play();
            }
            else
            {
                trail.Stop();
            }



            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isInRange)
                    if (!connected)
                        Connect();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (isInRange)
                    DisConnect();
            }
        }
        switch (life) {
            case 4:
                life1.sprite = lifeloss;
                break;
            case 3:
                life2.sprite = lifeloss;

                break;
            case 2:
                life3.sprite = lifeloss;

                break;
            case 1:
                life4.sprite = lifeloss;

                break;
            case 0:
                life5.sprite = lifeloss;
                gameOverSprite.SetActive(true);
                movementEnabled = false;
                break;
            
        }

        if (LevelFinished)
        {
            if (Input.GetKey(KeyCode.E))
            {
                int randomLevel = Random.Range(1, 3);

                SceneManager.LoadScene(randomLevel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grapple Point"))
        {
            canConnect = true;
            m_colliderTransform = other.GetComponent<Transform>();
            m_colliderRigid = other.GetComponent<Rigidbody>();
            m_colliderRigid.isKinematic = false;
            if (other.GetComponent<Light>())
            {
                other.GetComponent<Light>().color = Color.blue;
            }
            isInRange = true;
        }
        else if (other.CompareTag("Finish"))
        {
            LevelFinished = true;
            next.SetActive(true);

        }
        else 
        {
            connected = false;
            DisConnect();
            
                life = life - 1;
                print("Life Lost - " + life);
                playerSound.clip = fail;
                playerSound.Play();
                if(life != 0)
                    SendMessage("Reset");            
                else
                {
                    gameOverSprite.SetActive(true);

                    print("Game Over");
                }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!connected)
        {
            canConnect = false;
            if (other.GetComponent<Light>())
            {
                other.GetComponent<Light>().color = Color.red;
            }
            isInRange = false;
            m_colliderRigid.isKinematic = true;
        }
    }

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

    private void DisConnect()
    {
        if (canConnect)
        {
            speed = 5.0f;
            Destroy(transform.GetComponent<HingeJoint>());
            playerSound.clip = detach;
            playerSound.Play();
            connected = false;
            //trail.Stop();


        }
    }

    private void Reset()
    {
        self.velocity = new Vector3(0.0f, 0.0f, 0.0f);

    }
}
