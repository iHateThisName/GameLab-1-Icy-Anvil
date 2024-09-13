using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    [SerializeField] private EnumScene scene = EnumScene.MainMenu;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Goal");
            GameManager.Instance.LoadScene(scene);
        }
    }
}
