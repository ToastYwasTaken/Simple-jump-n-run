using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// The class handles everything concerning the Player.
/// Contains movement, jump, sprint, handling userinput, 
/// displaying UI elements, handling scene management, 
/// powerups, deathzone, collision and trigger events
/// </summary>
public class Player : MonoBehaviour
{
    #region Variables
    public float accelleration;
    public float jumpHeight;
    public SceneManagement sceneManager;

    public AudioSource aSource;
    public AudioClip aClip;
    public GameObject dash;
    public List<ePowerUp> activePowerUps;
    public int health;

    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private int jumpCounter = 0;

    private Vector3 spawnPostition;
    private Quaternion spawnQuaternion;
    private float deathZoneHeight = -40f;
    private Rigidbody playerRigidbody;
    private const int maxJumps = 2;
    private const float sprintMultiplier = 70f;
    private const float maxSpeed = 800;
    private const float maxSpeedSprint = 2000;
    #endregion

    public enum ePowerUp{DoubleJump, Health, Sprint, None}


    // Start is called before the first frame update
    void Start()
    {
        //assigning spawn point
        spawnPostition = transform.position;
        spawnQuaternion = transform.rotation;

        playerRigidbody = GetComponent<Rigidbody>();
        //setting starting health
        health = 3;
        //new empty powerup list
        activePowerUps = new List<ePowerUp>();
        //assigning audiosource
        aSource = GetComponent<AudioSource>();
        //assigning default for dash false
        dash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Loose Condition%
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            sceneManager.LoadMainMenu();
        }

        //Sprint
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)
            && activePowerUps.Contains(ePowerUp.Sprint))
        {
            //limiting sprint speed 
            if (playerRigidbody.velocity.sqrMagnitude < maxSpeedSprint) 
            {
            playerRigidbody.AddForce(transform.forward * accelleration
                * sprintMultiplier * Time.deltaTime, ForceMode.Acceleration);
            dash.SetActive(true);
            }
        } else dash.SetActive(false);



        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            aSource.pitch = 1f;
            aSource.PlayOneShot(aClip);
            playerRigidbody.AddForce(transform.up * jumpHeight 
                * Time.deltaTime, ForceMode.Impulse);
            jumpCounter--;
            isGrounded = false;
        }

        //Double jump
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0 
            && activePowerUps.Contains(ePowerUp.DoubleJump))
        {
            aSource.pitch = 1.3f;
            aSource.PlayOneShot(aClip);
            playerRigidbody.AddForce(transform.up * jumpHeight 
                * Time.deltaTime, ForceMode.Impulse);
            jumpCounter--;
        }

        //death zone
        if (transform.position.y < deathZoneHeight)
        {
            transform.position = spawnPostition;
            transform.rotation = spawnQuaternion;
            health--;   //remove life
        }

        
    }
    private void FixedUpdate()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            //Speedcheck
            if (playerRigidbody.velocity.sqrMagnitude < maxSpeed)
            {
                playerRigidbody.AddForce(transform.forward * accelleration);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Speedcheck
            if (playerRigidbody.velocity.sqrMagnitude < maxSpeed)
            {
                playerRigidbody.AddForce(transform.right * -accelleration);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Speedcheck
            if (playerRigidbody.velocity.sqrMagnitude < maxSpeed)
            {
                playerRigidbody.AddForce(transform.forward * -accelleration);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Speedcheck
            if (playerRigidbody.velocity.sqrMagnitude < maxSpeed)
            {
                playerRigidbody.AddForce(transform.right * accelleration);
            }
        }
    }

    /// <summary>
    /// handling collisions by tags
    /// </summary>
    /// <param name="collision">collision between the two objects 
    /// (refer to other object with 'collision.gameObject')</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")   
        {
            isGrounded = true;
            jumpCounter = maxJumps;
        }
        if(collision.gameObject.tag == "Goal")
        {
            sceneManager.LoadLevel(3);
        }
    }

    /// <summary>
    /// Checks if both colliding objects have their assigned name, 
    /// adds then the powerups accordingly. 
    /// Destroys the other gameobject at last.
    /// NOTE: For simplification health is handled as powerup, 
    /// even tho it doesn't affect the player's abilities; just his health.
    /// </summary>
    /// <param name="other">collider of other object</param>
    private void OnTriggerEnter(Collider other)
    {
        if (this.name == "Player")
        {
            if (other.name == "PowerUpJump")
            {
                activePowerUps.Add(ePowerUp.DoubleJump);
                Destroy(other.gameObject);
            }
            else if (other.name == "PowerUpHealth")
            {
                activePowerUps.Add(ePowerUp.Health);
                Destroy(other.gameObject);
            }
            else if (other.name == "PowerUpSprint")
            {
                activePowerUps.Add(ePowerUp.Sprint);
                Destroy(other.gameObject);
            }
        }
    }

}
