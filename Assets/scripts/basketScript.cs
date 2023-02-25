using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketScript : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    GameManager gameManagerScript;
    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<DuckScript>(out DuckScript duckScript))
        {
            Destroy(duckScript.gameObject);
            gameManagerScript.GetPoints(1);
            Debug.Log(gameManagerScript.score);
        }
    }
}
