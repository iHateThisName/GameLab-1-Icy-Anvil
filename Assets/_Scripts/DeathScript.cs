using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    //public Transform startPos;
    public Vector3 playerStartPos;
    public GameObject playerPref;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Die");
            Destroy(other.gameObject);
            Instantiate(playerPref, playerStartPos, Quaternion.identity);
        }
    }
   
}
