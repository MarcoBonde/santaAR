using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D MyRigidBody;

    //reference score e replay button
    public Score scoreText;
    public GameObject ReplayBtn;

    bool shouldGoUp;

    void Start()
    {
        Time.timeScale = 1;
        MyRigidBody = GetComponent<Rigidbody2D>();
        shouldGoUp = false;
        FaceExpressionManager.Singleton.ShouldFly.AddListener(ShouldFly);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shouldGoUp = true;
        }
        if (shouldGoUp) {
            flyUp();
        }
    }
    void ShouldFly()
    {
        shouldGoUp = true;
    }
    private void flyUp()
    {
        MyRigidBody.velocity = Vector2.up * speed;
        shouldGoUp = false;
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}