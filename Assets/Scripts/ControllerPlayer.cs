using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{


    public float speed = 1f; // speed Player
    public Vector3 destination; // coordenadas para onde o player deve se mover 
    public Quaternion initialRotation; // Rotação inicial do player






    // Start is called before the first frame update
    void Start()
    {
        // Rotação inicial do jogador
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Mouse
        bool MouseLeft = Input.GetMouseButtonDown(0);

        // Movimentation
        if (MouseLeft)
        {
            CheckPointDeslocation();
        }

        //Movimentation
        Move();

    }

    private void CheckPointDeslocation()
    {
        // lançar um raio no mundo de acordo com posição da camera e o click do mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Passar os parametros da colisão do raio para hit
        if (Physics.Raycast(ray, out hit))
        {
            // verificar se o objeto que o raio colidiu é da tag Ground
            if (hit.collider.CompareTag("Ground"))
            {
                Vector3 objectPosition = hit.transform.position;
                destination = objectPosition;
            }
        }
    }

    private void Move()
    {
        // Calcula a direção do movimento
        Vector3 direction = (destination - transform.position).normalized;

        // Verificar se o jogador atingiu o alvo
        if (Vector3.Distance(transform.position, destination) < 0.3f)
        {
            return;
        }

        // Move o jogador em direção à posição alvo
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Rotate();
    }

    private void Rotate()
    {
        // Calcula a direção do movimento
        Vector3 direction = (destination - transform.position).normalized;

        // Calcula a rotação para olhar em direção à posição alvo
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Aplica a rotação suavemente usando Slerp (Interpolação esférica)
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }

}
