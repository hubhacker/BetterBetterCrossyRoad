using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;        // Reference to the player's transform
    // public Vector3 offset = new Vector3(-5f, 5f, 0f); // Relative offset behind and above the player
    public float smoothSpeed = 5f;  // Smooth damping

    private float initialY;

    void Start()
    {
        // Store initial y position so camera doesn't follow player in those directions
        initialY = transform.position.y;
    }

    void LateUpdate()
    {
        // Follow player only in x and z direction
        Vector3 desiredPosition = new Vector3(player.position.x, initialY, player.position.z - 3); // + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}