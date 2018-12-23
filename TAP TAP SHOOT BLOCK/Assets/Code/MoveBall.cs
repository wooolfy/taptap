using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{

    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //SoundManager.instance.PlaySingle();

        

        if (col.gameObject.name == "player1" || col.gameObject.name == "player2")
        {
            // play hit music
            //FindObjectOfType<AudioManager>().Play("hitRacket");
            Vector2 newDirection;
            if (col.transform.position.y > 0)
            {
                newDirection = new Vector2(HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x), -1).normalized;
            } else
            {
                newDirection = new Vector2(HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x), 1).normalized;
            }
            GetComponent<Rigidbody2D>().velocity = newDirection * speed;
            this.speed *= 1.05f;
            if (this.speed > 15)
            {
                this.speed = 15;
            }
        }

        if (col.gameObject.name == "border_bottom" || col.gameObject.name == "border_up")
        {
            //FindObjectOfType<GameManager>().GameStop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (col.gameObject.name == "brick")
        {
            //FindObjectOfType<GameManager>().GameStop();
            Destroy(col.gameObject);
        }
    }


    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x); // racketWidth);
    }
}