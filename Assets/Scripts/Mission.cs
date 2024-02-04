using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    public int Trash = 0;
    public int Plants = 0;
    public Text textPlantMission;
    public Text textTrashMission;


    /* ============UPDATE============*/
    void Update()
    {
        float plantsInventory = GameManager.Instance.Plants;
        float trashInventory = GameManager.Instance.Trash;


        textPlantMission.text = "- Plant  " + plantsInventory + " / " + Plants + " trees across the map";
        textTrashMission.text = "- Destroy  " + trashInventory + " / " + Trash + " trash on the map";

        if (plantsInventory == Plants && trashInventory == Trash)
        {
            GameManager.Instance.isPortalActive = true;
        }
    }
}
