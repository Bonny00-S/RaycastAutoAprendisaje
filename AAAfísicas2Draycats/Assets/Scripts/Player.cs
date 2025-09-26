using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movent")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("RayCast")]
    public float rayLenght = 1f;
    public LayerMask groundLayer;


    [Header("Life")]
    public int Life = 3;

    private Rigidbody2D rb;
    public int enemysCount=0;
    public Animator anim;

    public static Player player;
    GameObject pasaje;
    GameObject plataforma;
    public Image lifebar;
    private void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        pasaje = GameObject.FindGameObjectWithTag("Pasaje");
        plataforma = GameObject.FindGameObjectWithTag("PlataformMovent");
        plataforma.SetActive(false);


    }
    void Start()
    {
   
    }

    void VerifiEnemy()
    {
       if (enemysCount == 2)
       {
          pasaje.SetActive(false);
       }
       else if(enemysCount == 3) 
       {
          
           plataforma.SetActive(true);
       }
        
    }

    void Update()
    {
        Movement();
        Jump(); 
      VerifiEnemy();
    
    }

    void Movement()
    {
        
        float move = Input.GetAxis("Horizontal");
        if (move == 0)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", true);
        }
        else
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", false);
        }
        rb.velocity= new Vector2(move*moveSpeed,rb.velocity.y);
    }

    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded()) 
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    bool IsGrounded()
    {
          
        return Physics2D.Raycast(transform.position,Vector2.down,rayLenght,groundLayer);
    }
    bool HitLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, rayLenght, groundLayer);
    }
    bool HitRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right ,rayLenght, groundLayer);
    }

   public void Damage()
    {
        Life -= 1;

        lifebar.fillAmount -= lifebar.fillAmount/Life;
        if (Life == 1)
        {
            RestartLevel(); 

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("winn");
        }
     

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawLine(transform.position,transform.position+Vector3.down*rayLenght);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * rayLenght);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLenght);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }





}
