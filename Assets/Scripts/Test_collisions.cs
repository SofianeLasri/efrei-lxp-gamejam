using System;
using UnityEngine;

public class Test_collisions : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Quelque chose est entré en collision avec moi !");
    }
}
