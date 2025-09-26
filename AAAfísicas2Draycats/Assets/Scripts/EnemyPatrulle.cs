using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrulle : MonoBehaviour
{
    public GameObject bulletPrefab;   
    public Transform firePoint;       
    public float fireRate = 2f;      
    public float bulletSpeed = 5f;    
    public bool shootRight = true;   
    public float rayUp=0.6f;
    public float rayLenght = 0.6f;
    private float fireTimer;
    public LayerMask playerlayer;



    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
        DetectatPisoton();
        DetectarLados();
    }

    void Shoot()
    {
   
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (shootRight)
        {
            rb.velocity = Vector2.right * bulletSpeed;
        }
        else
        {
            rb.velocity = Vector2.left * bulletSpeed;
        }
    }

     void DetectatPisoton()
     {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, rayUp, playerlayer);
        if (hitUp.collider != null)
        {
            Player.player.enemysCount++;
            Destroy(gameObject);
          
        }
     }

    void DetectarLados()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayLenght, playerlayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayLenght, playerlayer);
        if(hitLeft.collider != null || hitRight.collider !=null) 
        {

            Player.player.RestartLevel();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.up*rayUp);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * rayLenght);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLenght);
    }




}
