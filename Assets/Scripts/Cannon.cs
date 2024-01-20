using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{


    // Lista de plantas
    public List<GameObject> plants;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Destroi o objeto com o qual colidiu.
            Instantiate(plants[0], transform.position * 1f, transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual colidiu possui uma tag específica (opcional).
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
        }
    }
}



