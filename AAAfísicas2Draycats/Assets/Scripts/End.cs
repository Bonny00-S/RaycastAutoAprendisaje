using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public LayerMask playerlayer;
    public float rayUp = 0.6f;
    public float rayLenght = 0.6f;
    GameObject Win;
    void Start()
    {
        Win = GameObject.FindGameObjectWithTag("Win");
        Win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectatPisoton();
        DetectarLados();
    }

    void DetectatPisoton()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, rayUp, playerlayer);
        if (hitUp.collider != null)
        {
            WinI();

        }
    }

    void DetectarLados()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayLenght, playerlayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayLenght, playerlayer);
        if (hitLeft.collider != null || hitRight.collider != null)
        {

            WinI();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * rayUp);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * rayLenght);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLenght);
    }


    void WinI()
    {
        Win.SetActive(true);
        Time.timeScale = 0f;
    }
}
