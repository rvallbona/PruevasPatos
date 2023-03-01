using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject puntuacion;
    TextMeshProUGUI textPuntuacion;
    int scoreUI;
    private void Start()
    {
        textPuntuacion = puntuacion.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        scoreUI = gameManager.score;
        textPuntuacion.text = "Puntos: " + scoreUI.ToString();
        Debug.Log(textPuntuacion.text);
    }
}
