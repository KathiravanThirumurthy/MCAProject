using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    [SerializeField]
    private ScoreManager _scoreController;
    [SerializeField]
    private Gameover _gameOverController;
    [SerializeField]
    private float speed;
    private Rigidbody2D rgdPlayer;
    private Playeranimation _playerAnimation;
    
    [SerializeField]
    private float _jumpForce;
    // Checking the player is grounded
    private bool isGrounded;
    // Checking for the crouch animation is happening
    private bool isCrouch;
    //No. of lives
    [SerializeField]
    private int _lives;

    [SerializeField]
    private AudioClip keyPickup;
    [SerializeField]
    private AudioClip playerDeath;
    [SerializeField]
    private float gravityScale = 3f;
    [SerializeField]
    private bool isFalling = false;
    [SerializeField]
    private bool isMoving = false;
    private float move;
    private int nextSceneLoad;
    [SerializeField]
    private Animator transistion;
    [SerializeField]
    private float transistionTime = 15f;
    void Awake()
    {
        Time.timeScale = 1f;
        rgdPlayer = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<Playeranimation>();
       // _scoreController = GameObject.Find().GetComponent<ScoreManager>();
       // Debug.Log(_scoreController);
        // Intialising variables to check for Grounded and crouch
        isGrounded = false;
        isCrouch = false;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!isFalling)
        {
            move = Input.GetAxisRaw("Horizontal");
            rgdPlayer.gravityScale = gravityScale;
            _playerAnimation.flipPlayer(move);
            rgdPlayer.velocity = new Vector2(move * speed, rgdPlayer.velocity.y);
            _playerAnimation.movement(move);
        }*/
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Checking the player is grounded
            if (isGrounded )
            {
                //adding velocity to the player in the y direction to jump
                rgdPlayer.velocity = new Vector2(rgdPlayer.velocity.x, _jumpForce);
                // when the player is in air it Space bar shouldnt be pressed 
                isGrounded = false;
                isFalling = false;
                // calling the jumping method from the PlayerAnimation Script
                _playerAnimation.jumping(true);
            }
          /* else
            {
                isFalling = true;
            }*/
           
        }
        
        

        /* if (isGrounded)
         {
             isFalling = false;

             if (Input.GetKeyDown(KeyCode.Space))
             {
                 //adding velocity to the player in the y direction to jump
                 rgdPlayer.velocity = new Vector2(rgdPlayer.velocity.x, _jumpForce);
                 // when the player is in air it Space bar shouldnt be pressed 
                 isGrounded = false;
                 isFalling = false;
                 // calling the jumping method from the PlayerAnimation Script
                 _playerAnimation.jumping(true);
             }
         }
         else
         {
             isFalling = true;
         }*/


    }
    private void FixedUpdate()
    {
        /*  if (!isFalling && isGrounded)
          {
              move = Input.GetAxisRaw("Horizontal");
              rgdPlayer.gravityScale = gravityScale;
              _playerAnimation.flipPlayer(move);
              rgdPlayer.velocity = new Vector2(move * speed, rgdPlayer.velocity.y);
              _playerAnimation.movement(move);
          }*/
        if (!isFalling)
        {
            move = Input.GetAxisRaw("Horizontal");
            //isMoving = true;
            rgdPlayer.gravityScale = gravityScale;
            _playerAnimation.flipPlayer(move);
            rgdPlayer.velocity = new Vector2(move * speed, rgdPlayer.velocity.y);
            _playerAnimation.movement(move);
        }
    }
    // checking the player for collision with the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player collides with Ground with tag "Platform"
        if (collision.gameObject.tag == "Platform")
        {
            // to check Grounded
            isGrounded = true;
            // calling the jumping method from the PlayerAnimation Script to jump
            _playerAnimation.jumping(false);
        }
        else if (collision.gameObject.tag == "Deathline")
        {
            Debug.Log("Dead");
            _playerAnimation.playerDead(true);
            StartCoroutine(playGameOverDelay());
            // _gameOverController.PlayerDied();

        }

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "LevelComplete")
        {
            Debug.Log("LEvelComplete");
            StartCoroutine(LoadLevel(nextSceneLoad));
        }

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transistion.SetTrigger("Start");
        yield return new WaitForSeconds(transistionTime);
        SceneManager.LoadScene(levelIndex);
        if (levelIndex >= PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", levelIndex);
        }
    }
    public void pickUpKey(int score)
    {
        // Debug.Log("Score:" + score);
        _scoreController.incrementScore(score);
         AudioManager.Instance.PlayCollectable(keyPickup);
    }

    public void playerDead(bool playerState)
    {
        Debug.Log("Player was hit");
      //  _playerAnimation.playerDead(playerState);
        Damage();
    }
    public void Damage()
    {
        Debug.Log("Damage");
        _lives--;
        LifeController.instance.UpdateLives(_lives);

        if (_lives < 0)
        {

            Debug.Log("Player Killed by the EnemyChomper ");
            LifeController.instance.UpdateLives(_lives);
        }
        else if (_lives == 0)
        {

            _playerAnimation.playerDead(true);
            //UIManager.instance.restartCurrentScene();
           
          //  AudioManager.Instance.playeDeath(playerDeath);
            StartCoroutine(playGameOverDelay());
            // _gameOverController.PlayerDied();
            
            // Debug.Log("Remaining Lives : " + _lives);
        }

    }
    private IEnumerator playGameOverDelay()
    {
        yield return new WaitForSeconds(3f);
        _gameOverController.PlayerDied();
        Time.timeScale = 0f;
    }
}
