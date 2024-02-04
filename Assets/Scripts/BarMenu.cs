using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMenu : MonoBehaviour
{

    // ============VARIAVEIS============*/
    [Header("Configurações da barra de menu")]
    public Transform mainCam;
    [Header("Configurações da barra plantas")]
    public bool statusCToPlants = false;
    public Canvas ToPlants;
    public Button buttonToPlant;
    [Header("Configurações da barra Trash")]
    public bool statusCRemoveTrash = false;
    public Canvas RemoveTash;
    public Button buttonRemoveTrash;
    [Header("Configurações da barra progress")]
    public Canvas barProgres;
    public Image imgbarProgres;

    [Header("Referencia de onde esta os scripts")]
    public ToPlants toPlants;
    public RemoveTrash removeTrash;

    /* ============Start============*/
    void Start()
    {
        // pegar a camera como referencia
        mainCam = Camera.main.transform;
        // Adicionar evento no botão de plantar
        buttonToPlant.onClick.AddListener(OnButtonClickToPlants);
        buttonRemoveTrash.onClick.AddListener(OnButtonClickRemoveTrash);
        DesactivAllCanvas();
    }

    /* ============UPDATE============*/
    void Update()
    {
        transform.LookAt(transform.position + mainCam.forward);
    }

    /* ============BUTTONS============*/
    public void OnButtonClickToPlants()
    {
        toPlants.toPlants("startTimer");
        ToPlants.enabled = false;
        barProgres.enabled = true;
    }
    public void OnButtonClickRemoveTrash()
    {
        removeTrash.Remove("startTimer");
        RemoveTash.enabled = false;
        barProgres.enabled = true;
    }
    /* ============CANVAS============*/
    // Progress bar interaction timer
    public void BarProgressAltered(int currentyProgress, int maxProgress)
    {
        imgbarProgres.fillAmount = (float)currentyProgress / maxProgress;
    }

    // desactive all canvas enable
    public void DesactivAllCanvas()
    {
        ToPlants.enabled = false;
        RemoveTash.enabled = false;
    }
}
