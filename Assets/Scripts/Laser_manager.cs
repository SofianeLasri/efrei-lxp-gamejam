using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser_manager : MonoBehaviour
{
    public GameObject cage;
    public GameObject player;
    public float dropSpeed = 5f;

    private bool isDropping = false;
    private bool hasTouchedGround = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivateDeath();
        }

        // Si la cage touche le sol
        if (isDropping && other.gameObject.CompareTag("ground"))
        {
            hasTouchedGround = true;
            isDropping = false;
            Debug.Log("Cage a touché le sol, arrêt de la descente.");
        }
    }

    private void ActivateDeath()
    {
        isDropping = true;
        hasTouchedGround = false;
    }

    private void Update()
    {
        // Suivre le joueur en X
        Vector3 cagePosition = cage.transform.position;
        cagePosition.x = player.transform.position.x;
        cage.transform.position = cagePosition;

        // Descente vers le joueur
        if (isDropping)
        {
            Vector3 targetPosition = new Vector3(cage.transform.position.x, player.transform.position.y, cage.transform.position.z);
            cage.transform.position = Vector3.MoveTowards(cage.transform.position, targetPosition, dropSpeed * Time.deltaTime);

            // Si on atteint le joueur et qu’on n’a pas touché le sol → recharger la scène
            if (!hasTouchedGround && Mathf.Abs(cage.transform.position.y - player.transform.position.y) < 0.5f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}