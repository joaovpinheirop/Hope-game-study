using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControllerPlayer : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    [Header("Configurações do Jogador")]
    private bool isMove = true;
    public float currentEnergy = 100f;
    public float maxEnergy = 100f;
    public float spentEnergy = 0.02f;
    public float speed = 1f; // speed Player
    private Vector3 destination; // coordenadas para onde o player deve se mover 
    private Quaternion initialRotation; // Rotação inicial do player
    public float transitionRotation = 2f; // velocidade de rotação
    private string typeMovement; // tipo de movimento que o player ira executar
    private string ObjectColliderName;

    [Header("Canvas Bar menu")]
    public BarMenu barMenu;
    [SerializeField] private Image barEnergy;

    /* ============START============*/
    void Start()
    {
        // Rotação inicial do jogador
        initialRotation = transform.rotation;
        destination = transform.position;
        ObjectColliderName = null;
    }

    /* ============UPDATE============*/
    void Update()
    {
        // Get Mouse
        bool MouseLeft = Input.GetMouseButtonDown(0);
        bool MouseRight = Input.GetMouseButtonDown(1);

        // Lado mouse esquerdo para movimentasr player
        if (MouseLeft)
        {
            CheckPointDeslocation("Menu");
        }

        // Mouse lado direito para destruir objeto
        if (MouseRight)
        {
            CheckPointDeslocation("Move");
        }

        //Movimentation
        Move();

        // Energy
        EnergyTimer();
    }

    /* ============ClickScreen============*/
    private void CheckPointDeslocation(string operation)
    {
        // lançar um raio no mundo de acordo com posição da camera e o click do mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Passar os parametros da colisão do raio para hit
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 objectPosition = hit.transform.position;
            bool statusCanvasPlant = barMenu.statusCToPlants; // variavel externa bolena da barra de menu plantar
            bool statusCanvasRemove = barMenu.statusCRemoveTrash; // variavel externa booleana da barra de menu remover lixo

            // verificar se o objeto que o raio colidiu é da tag Ground
            if (hit.collider.CompareTag("Ground") && operation == "Move")
            {
                destination = objectPosition + new Vector3(0, objectPosition.y + 1, 0);
                barMenu.DesactivAllCanvas();
            }

            // verificar se o objeto que o raio colidiu é da tag Trash
            if (hit.collider.CompareTag("Trash") && operation == "Move")
            {
                destination = objectPosition + new Vector3(0, objectPosition.y + 1, 0);
                barMenu.DesactivAllCanvas();
            }

            // verificar se o objeto que o raio colidiu é da tag Player
            if (hit.collider.CompareTag("Player") && operation == "Menu")
            {
                switch (ObjectColliderName)
                {
                    case "Trash":
                        ToggleCanvas(barMenu.RemoveTash, ref statusCanvasRemove);
                        barMenu.statusCRemoveTrash = !barMenu.statusCRemoveTrash;
                        break;
                    case "Ground":
                        ToggleCanvas(barMenu.ToPlants, ref statusCanvasPlant);
                        barMenu.statusCToPlants = !barMenu.statusCToPlants;
                        break;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        ObjectColliderName = other.tag;

        if (other.CompareTag("Portal") && GameManager.Instance.isPortalActive)
        {
            SceneManager.LoadScene(GameManager.Instance.nameNextScene);
        }
    }

    /* ============MovePlayer============*/
    private void Move()
    {
        if (isMove)
        {
            // Calcula a direção do movimento
            Vector3 direction = (destination - transform.position).normalized;

            // Verificar se o jogador atingiu o alvo
            if (Vector3.Distance(transform.position, destination) < 0.3f)
            {
                initialRotatate();
                return;
            }

            // Move o jogador em direção à posição alvo
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            Rotate();
        }
    }

    /* ============RoatationPlayer============*/
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

    /* ============Canvas============*/
    void ToggleCanvas(Canvas canvas, ref bool status)
    {
        if (status == true)
        {
            canvas.enabled = false;
        }
        else if (status == false)
        {
            canvas.enabled = true;
        }
    }

    /* ============EnergyTimer============*/
    void EnergyTimer()
    {

        if (isMove == false)
            return;

        if (currentEnergy >= 0)
        {
            currentEnergy -= spentEnergy * Time.deltaTime;
        }

        currentEnergy = Mathf.Max(0f, currentEnergy);
        if (currentEnergy == 0f)
        {
            isMove = false;
        }
    }




}
