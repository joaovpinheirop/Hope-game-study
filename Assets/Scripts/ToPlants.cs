using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ToPlants : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    //-----PLantar-----
    [Header("Configurações de Sistema de Plantas")]
    public List<GameObject> plants;  // Lista de plantas
    [Tooltip("Intervalo de tempo para a planta ser plantada")] public float interval = 1f;
    [SerializeField] private float cooldown = 0f;
    private bool isToPlant = false;
    [Header("Game Manager")]
    [SerializeField] private BarMenu barMenu;
    private Mission mission;

    /* ============START============*/
    void Start()
    {
        barMenu = FindObjectOfType<BarMenu>();
        mission = FindObjectOfType<Mission>();
    }

    /* ============UPDATE============*/
    void Update()
    {
        Timer();
    }

    /* ============VerifColisionTrash============*/
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plants"))
        {
            isToPlant = false;
        }
    }

    /* ============toPlant============*/
    public void toPlants(String typeOperation)
    {
        if (typeOperation == "toPlant")
        {
            Instantiate(plants[0], transform.position - new Vector3(0, 1, 2), transform.rotation);

            GameManager.Instance.Plants += 1;
        }
        if (typeOperation == "startTimer" && GameManager.Instance.Plants < mission.Plants)
        {
            cooldown = interval;
            isToPlant = true;
        }
    }

    /* ============TIMER============*/
    private void Timer()
    {
        if (isToPlant == false)
            return;

        if (isToPlant == true && cooldown >= 0)
        {
            cooldown -= Time.fixedDeltaTime;
        }

        barMenu.BarProgressAltered((int)cooldown, (int)interval);
        cooldown = Mathf.Max(0f, cooldown);

        if (cooldown == 0f)
        {
            toPlants("toPlant");
            isToPlant = false;
        }
    }
}
