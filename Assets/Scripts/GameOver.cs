using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Called by "Play Again?" button in GameOver scene
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
