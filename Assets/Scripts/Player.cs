using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D MyRigidBody;

    //reference score e replay button
    public Score scoreText;
    public GameObject ReplayBtn;

    void Start()
    {
        Time.timeScale = 1;
        MyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MyRigidBody.velocity = Vector2.up * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            print("Score Up");
            scoreText.ScoreUp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            //game over
            Time.timeScale = 0;
            ReplayBtn.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }
}
