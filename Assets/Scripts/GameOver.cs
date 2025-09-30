using UnityEngine;
using UnityEngine.SceneManagement; // Importación agregada

public class GameOver : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            perder();
        }
    }

    void perder()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
