using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrash : MonoBehaviour
{
    /* ============START============*/
    //-----Destruição de lixo----- //
    [Header("Configuração da destruição do lixo")]
    [Tooltip("Intervalo de tempo para lixo ser destruido")] public float interval = 1f;
    [SerializeField] private float cooldown = 0f;
    [SerializeField] private bool isRemoveTrash = false;
    [SerializeField] private GameObject ObjectTrash;
    [SerializeField] private BarMenu barMenu;
    private float PowerCanon = 1.4f;
    private int TrashLevel;
    private ControllerPlayer controllerPlayer;

    /* ============START============*/
    void Start()
    {
        controllerPlayer = FindObjectOfType<ControllerPlayer>();
        barMenu = FindAnyObjectByType<BarMenu>();
    }

    /* ============UPDATE============*/
    void Update()
    {
        Timer();
    }

    /* ============Verificar colisão com Trash============*/
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual colidiu possui uma tag específica (opcional).
        if (other.CompareTag("Trash"))
        {
            TrashLevel = other.gameObject.GetComponent<Trash>().Level;
            ObjectTrash = other.gameObject;
            interval = TrashLevel * PowerCanon;
        }
    }

    /* ============RemoveTrash============*/
    public void Remove(String typeOperation)
    {
        if (typeOperation == "removeTrash")
        {
            Destroy(ObjectTrash);
            GameManager.Instance.Trash += 1;
            controllerPlayer.currentEnergy += 3;
        }
        else if (typeOperation == "startTimer")
        {
            cooldown = interval;
            isRemoveTrash = true;
        }
    }

    /* ============Timer============*/
    void Timer()
    {
        if (isRemoveTrash == false)
            return;

        if (isRemoveTrash == true && cooldown >= 0)
        {
            cooldown -= Time.fixedDeltaTime;
        }

        barMenu.BarProgressAltered((int)cooldown, (int)interval);
        cooldown = Mathf.Max(0f, cooldown);

        if (cooldown == 0f)
        {
            Remove("removeTrash");
            isRemoveTrash = false;
            barMenu.barProgres.enabled = !barMenu.barProgres.enabled;
        }
    }
}
