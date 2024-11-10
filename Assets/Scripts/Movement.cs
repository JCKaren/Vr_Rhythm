using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float speed = 2;
    //private Vector3 scale = Vector3.one;
    //private Vector3 spawnPosition;
    //private Vector3 spawnRotation;
    [SerializeField] private GameObject cubo;


    // Start is called before the first frame update
    void Start()
    {
        cubo = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, -1*(speed * Time.deltaTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el cubo colisiona con un objeto llamado "Muro"
        if (other.gameObject.CompareTag("Wall"))
        {
            // Destruir este objeto
            Destroy(gameObject);
        }
    }
}
