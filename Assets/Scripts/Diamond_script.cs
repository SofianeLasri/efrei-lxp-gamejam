using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond_script : MonoBehaviour
{
    private int _level;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);     
        }
    }
}