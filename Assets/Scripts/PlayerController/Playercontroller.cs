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
    private bool isFacingRight = true;
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
    private AudioClip playerHurt;
    [SerializeField]
    private AudioClip swordSwing;
    [SerializeField]
    private AudioClip levelCompleted;
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

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=40;

    //shooting
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float shootingInterval = 0.5f;
    public float bulletSpeed = 10.0f;

    private float nextShootTime = 0.0f;
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
         
        }
       /* if(Input.GetMouseButtonDown(0) && isGrounded)
        {
           
            PlayerAttack();
            _playerAnimation.attack();
           
        }*/
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerAttack();
            _playerAnimation.attack();
            AudioManager.Instance.swordSwingSound(swordSwing);

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.time >= nextShootTime)
            {
                if (Input.GetKeyDown(KeyCode.Return)) // You can use any other input key you prefer
                {
                    Shoot();
                    nextShootTime = Time.time + shootingInterval;
                }
            }

        }

    }
    private void FixedUpdate()
    {
        
        if (!isFalling)
        {
            move = Input.GetAxisRaw("Horizontal");
           if(move > 0)
            {
                isFacingRight = true;
            }
            else if(move < 0)
            {
                isFacingRight = false;
            }
            
            //isMoving = true;
            rgdPlayer.gravityScale = gravityScale;
            _playerAnimation.flipPlayer(move);
            rgdPlayer.velocity = new Vector2(move * speed, rgdPlayer.velocity.y);
            _playerAnimation.movement(move);
        }
    }

    private void Shoot()
    {
        // Create a bullet and set its velocity
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        // Determine the bullet's direction based on player's facing direction
        Vector2 shootDirection = isFacingRight ? Vector2.right : Vector2.left;
        bulletRb.velocity = shootDirection * bulletSpeed;
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
            AudioManager.Instance.playeDeath(playerDeath);
            StartCoroutine(playGameOverDelay());
            // _gameOverController.PlayerDied();

        }

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "LevelComplete")
        {
           // Debug.Log("LEvelComplete");
            StartCoroutine(LoadLevel(nextSceneLoad));
            AudioManager.Instance.levelComplete(levelCompleted);
        }else if(target.gameObject.tag == "switch")
        {
            
            GameObject obj = GameObject.Find("Wall"); // Replace "ObjectName" with the name of the GameObject you want to find
            if (obj != null)
            {
                obj.GetComponent<AlphaAnimation>().Play();
            }

            target.gameObject.SetActive(false);
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
       // Debug.Log("Player was hit");
      //  _playerAnimation.playerDead(playerState);
        Damage();
    }
    public void Damage()
    {
        // Debug.Log("hurt");
        _lives--;
        //Debug.Log(_lives);
        _playerAnimation.playerHurt();
        LifeController.instance.UpdateLives(_lives);
        AudioManager.Instance.playerHurtSound(playerHurt);
        
       
        if (_lives < 0)
        {

            Debug.Log("Player Killed by the EnemyChomper ");
            LifeController.instance.UpdateLives(_lives);
        }
        else if (_lives == 0)
        {

            Debug.Log("dead");
            _playerAnimation.playerDead(true);
            //UIManager.instance.restartCurrentScene();
           
            AudioManager.Instance.playeDeath(playerDeath);
            StartCoroutine(playGameOverDelay());
            // _gameOverController.PlayerDied();
            
            // Debug.Log("Remaining Lives : " + _lives);
        }

    }
    private IEnumerator playGameOverDelay()
    {
        yield return new WaitForSeconds(2f);
        _gameOverController.PlayerDied();
        Time.timeScale = 0f;
    }
    private void PlayerAttack()
    {

        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
         foreach(Collider2D enemy in hitEnemies)
         {
             Debug.Log("we hit " + enemy.name);
             enemy.GetComponent<MeleeEnemy>().TakeDamage(attackDamage);
         }
  
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
