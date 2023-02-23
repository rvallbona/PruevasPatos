using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class grabDuck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<DuckScript>(out DuckScript duckScript))
        {
            duckScript.LameDuck(this.gameObject.transform);
        }
    }
}
