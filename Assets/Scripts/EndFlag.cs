using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool finalLevel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (finalLevel == true)
            {
                // Go back to the menu scene
                SceneManager.LoadScene(0);
            }
            else
            {
                // Move on to the next level
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
