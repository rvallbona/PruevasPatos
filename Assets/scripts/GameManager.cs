using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public void GetPoints(int points)
    {
        score += points;
    }
}
