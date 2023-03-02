using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [Header("Bomb Settings")]
    [SerializeField] float speed = 5f;
    [Header("Bomb Route Settings")]
    [SerializeField] int startPos = 0;
    [SerializeField] GameObject[] destinations;
    [SerializeField] GameObject magnet;
    int actPosition = 0;
    int nextPosition = 0;
    bool grabed = false;
    Rigidbody rb;
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
            CatchedBomb();
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
            nextPosition += 3;
            if (nextPosition > destinations.Length - 1)
            {
                nextPosition -= destinations.Length;
            }
        }
    }
    void CatchedBomb()
    {
        this.gameObject.transform.position = magnet.transform.position + new Vector3(0, -1, 0);
        rb.useGravity = false;
        Debug.Log("BUM");
    }
    public void LameBomb(Transform parent)
    {
        grabed = true;
        this.gameObject.transform.parent = parent;
    }
    public void ReleaseBomb(Transform parent)
    {
        this.gameObject.transform.parent = null;
    }
}
