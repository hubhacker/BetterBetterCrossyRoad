using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource deathSound;
    public GameObject gameOverUI; // Optional: if you want to show game over screen

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if colliding with a moving block (tag or layer)
        if (collision.gameObject.CompareTag("MovingBlock"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Use this if you're using triggers instead of collisions
        if (other.CompareTag("MovingBlock"))
        {
            Die();
        }
    }

    void Die()
    {
        // Stop background music
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
        
        // Play death sound
        if (deathSound != null)
        {
            deathSound.Play();
        }
        
        // Optional: Show game over screen
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        
        // Optional: Disable player controls or destroy chicken
        // GetComponent<PlayerController>().enabled = false;
    }
}