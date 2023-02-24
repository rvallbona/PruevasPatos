using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class grabDuck : MonoBehaviour
{
    bool canGrab = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<DuckScript>(out DuckScript duckScript) && canGrab)
        {
            duckScript.LameDuck(this.gameObject.transform);
            canGrab = false;
        }
        else
        {
            canGrab = true;
        }
    }
}
