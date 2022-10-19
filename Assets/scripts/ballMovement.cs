using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int verticalForce = 600;
    public int horizontalForce = 120;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(horizontalForce, 0));

        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.transform.tag == "LeftBound" || Col.transform.tag == "RightBound"){
            horizontalForce *= -1;
            rb.AddForce(new Vector2(horizontalForce, 0));
        }else if (Col.transform.tag == "BottomBound"){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(horizontalForce, verticalForce));
        }
    }
}
