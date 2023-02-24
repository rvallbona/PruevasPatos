using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject[] destinations;
    [SerializeField] GameObject magnet;
    [SerializeField] float speed = 5f;
    int actPosition = 0;
    int nextPosition = 0;
    [SerializeField] int startPos = 0;
    bool grabed = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextPosition = startPos;
        grabed = false;
    }
    private void Update()
    {
        if (!grabed)
        {
            CalculateNextPoint();
            GoToPoint(destinations[nextPosition].transform);
        }
        else if (grabed)
        {
            this.gameObject.transform.position = magnet.transform.position + new Vector3(0,-1,0);
            rb.useGravity = false;
        }
    }
    void GoToPoint(Transform nextPoint)
    {
        transform.LookAt(nextPoint.transform);
        rb.velocity = transform.forward * speed;
    }
    void CalculateNextPoint()
    {
        if (Vector3.Distance(this.transform.position, destinations[nextPosition].transform.position) < 0.1f)
        {
            actPosition = nextPosition;
            Debug.Log(actPosition);
            nextPosition += 3;
            if (nextPosition > destinations.Length - 1)
            {
                nextPosition -= destinations.Length;
            }
        }
    }
    public void LameDuck(Transform parent)
    {
        grabed = true;
        this.gameObject.transform.parent = parent;
    }
    public void ReleaseDuck(Transform parent)
    {
        this.gameObject.transform.parent = null;
    }
}