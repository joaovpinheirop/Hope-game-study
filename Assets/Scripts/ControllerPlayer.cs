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
    private Quaternion initialRotation; // Rotação inicial do player
    public float transitionRotation = 2f;
    private string typeMovement;

    // --------------------------------------------------------Start---------------------------------------------------------
    void Start()
    {
        // Rotação inicial do jogador
        initialRotation = transform.rotation;
    }

    // --------------------------------------------------------Update---------------------------------------------------------
    void Update()
    {
        // Get Mouse
        bool MouseLeft = Input.GetMouseButtonDown(0);
        bool MouseRight = Input.GetMouseButtonDown(1);

        // Lado mouse esquerdo para movimentasr player
        if (MouseLeft)
        {
            CheckPointDeslocation("Move");

        }
        // Mouse lado direito para destruir objeto
        if (MouseRight)
        {
            CheckPointDeslocation("Destroy");
        }

        if (Input.GetKey(KeyCode.W) && typeMovement == "Plant")
        {
            this.GetComponent<Cannon>().isToPlant = true;
            this.GetComponent<Cannon>().toPlants("startTimer");
        }

        //Movimentation
        Move();
    }

    // --------------------------------------------------------DeslocamentoPlayer----------------------------------------------

    private void CheckPointDeslocation(string operation)
    {
        // lançar um raio no mundo de acordo com posição da camera e o click do mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Passar os parametros da colisão do raio para hit
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 objectPosition = hit.transform.position;
            // verificar se o objeto que o raio colidiu é da tag Ground
            if (hit.collider.CompareTag("Ground") && operation == "Move")
            {
                destination = objectPosition + new Vector3(0, objectPosition.y + 1, 0);
                TypeMove("Plant");
            }
            // verificar se o objeto que o raio colidiu é da tag Ground
            if (hit.collider.CompareTag("Trash") && operation == "Destroy")
            {
                destination = objectPosition + new Vector3(0, objectPosition.y + 1, 0);
                TypeMove("Destroy");

            }
        }
    }

    // --------------------------------------------------------DeslocamentoPlayer----------------------------------------------
    private void Move()
    {
        // Calcula a direção do movimento
        Vector3 direction = (destination - transform.position).normalized;

        // Verificar se o jogador atingiu o alvo
        if (Vector3.Distance(transform.position, destination) < 0.3f)
        {
            initialRotatate();
            if (typeMovement == "Destroy")
            {
                Destroy(this.GetComponent<Cannon>().objectDestroy);
            }
            return;
        }

        // Move o jogador em direção à posição alvo
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Rotate();
    }
    // ---------------------------------------------------------RotaçãoPlayer--------------------------------------------------
    private void Rotate()
    {
        // Calcula a direção do movimento
        Vector3 direction = (destination - transform.position).normalized;

        // Calcula a rotação para olhar em direção à posição alvo
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z), Vector3.up);

        // Aplica a rotação suavemente usando Slerp (Interpolação esférica)
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * transitionRotation);
    }

    public void initialRotatate()
    {
        // Aplica a rotação suavemente usando Slerp (Interpolação esférica)
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * transitionRotation);
    }

    // -------------------------------------------------------TypeMove-----------------------------------------------------
    void TypeMove(string type)
    {
        typeMovement = type;
    }

}
