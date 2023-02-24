using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<DuckScript>(out DuckScript duckScript))
        {
            Destroy(duckScript.gameObject);
        }
    }
}
