using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    [SerializeField] private float points;
    [SerializeField]private TextMeshProUGUI  textMeshPro;
    private Rigidbody rb;
    private float totalPoints;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

    }

    private void OnTriggerEnter(Collider other)
    {      

        if (other.gameObject.CompareTag("projectile"))
        {
            totalPoints += points; 
            Debug.Log(totalPoints);
            textMeshPro.text = totalPoints.ToString();
        }
    }

}
