using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    //-----PLantar-----
    public List<GameObject> plants;  // Lista de plantas
    public float cooldown = 0f;
    public float interval = 1f;
    public bool isToPlant = false;

    //-----Destruição de lixo-----
    public bool isShoting = false; // status do tiro
    public GameObject objectDestroy;

    // --------------------------------------------------------Start ---------------------------------------------------------
    void Start()
    {
        var controllerPlayer = this.GetComponent<ControllerPlayer>();
    }

    // --------------------------------------------------------Update---------------------------------------------------------
    // Update is called once per frame
    void Update()
    {

        if (isToPlant == false)
            return;

        if (isToPlant == true && cooldown >= 0)
        {
            cooldown -= Time.fixedDeltaTime;

        }


        cooldown = Mathf.Max(0f, cooldown);

        if (cooldown == 0f)
        {
            toPlants("toPlant");
        }



    }


    // --------------------------------------------------------Verificar colisão com Trash---------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual colidiu possui uma tag específica (opcional).
        if (other.CompareTag("Trash"))
        {
            isShoting = true;
            objectDestroy = other.gameObject;

        }
        if (other.CompareTag("Plants"))
        {
            isToPlant = false;
        }


    }
    // --------------------------------------------------------Verificar a falta da colisão---------------------------------------------------------
    void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto com o qual colidiu possui uma tag específica (opcional).
        if (other.CompareTag("Trash"))
        {
            isShoting = false;

        }



    }
    // --------------------------------------------------------------Plantar--------------------------------------------------------------------------
    public void toPlants(String typeOperation)
    {


        if (typeOperation == "toPlant")
        {
            Instantiate(plants[0], transform.position - new Vector3(0, 1, 0), transform.rotation);
        }
        if (typeOperation == "startTimer")
        {
            cooldown = interval;
        }
    }
}



