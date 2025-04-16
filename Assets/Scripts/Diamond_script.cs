using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond_script : MonoBehaviour
{
    public int level;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex +1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);     
        }
    }
}