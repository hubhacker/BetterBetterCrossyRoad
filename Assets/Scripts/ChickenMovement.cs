using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float jumpDuration = 0.2f;
    public float jumpHeight = 0.5f;
    private bool isJumping = false;
    public int score = 0;
    private int maxZdistance = 0;
    public DisplayScore displayScore;
    // private bool isInWater = false;

    [SerializeField]
    GameObject _chicken;

    private void Start()
    {
        SnapToGrid();
    }


    public void Jump(Vector3 direction)
    {
        if (isJumping) return;

        if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction);

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction;

        endPos = new Vector3(Mathf.Round(endPos.x), endPos.y, Mathf.Round(endPos.z));

        StartCoroutine(JumpRoutine(startPos, endPos));
    }

    private IEnumerator JumpRoutine(Vector3 start, Vector3 end)
    {
        isJumping = true;
        float elapsed = 0f;

        while (elapsed < jumpDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / jumpDuration);

            Vector3 pos = Vector3.Lerp(start, end, t);
            pos.y += Mathf.Sin(t * Mathf.PI) * jumpHeight;

            transform.position = pos;
            yield return null;
        }

        transform.position = end;
        SnapToGrid();
        isJumping = false;
    }

    private void SnapToGrid()
    {
        Vector3 p = transform.position;
        transform.position = new Vector3(Mathf.Round(p.x), p.y, Mathf.Round(p.z));
        if(Mathf.Round(p.z) > maxZdistance)
        {
            maxZdistance = Mathf.RoundToInt(p.z);
            score++;
            DisplayScore displayScore = FindObjectOfType<DisplayScore>();
            displayScore.UpdateScore(maxZdistance);
            Debug.Log("Score: " + score);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "obstacle")
        {
            Debug.Log("collided with lambda");
            // game ends
            Destroy(_chicken.gameObject);
            Time.timeScale = 0;
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Water"))
           {
               Debug.Log("touched water layer - chicken drowns. game over");
               // game ends
                Destroy(_chicken.gameObject);
                Time.timeScale = 0;
           }
    }
}
