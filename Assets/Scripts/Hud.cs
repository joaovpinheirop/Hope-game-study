using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    [SerializeField] private Text textPlants;
    [SerializeField] private Text textTrash;
    [SerializeField] private Text textCoin;
    [SerializeField] private Image barEnergy;
    [Header("Referencias")]
    [SerializeField] private ControllerPlayer controllerPlayer;

    /* ============START============*/
    void Start()
    {
        controllerPlayer = FindObjectOfType<ControllerPlayer>();
    }

    /* ============UPDATE============*/
    void Update()
    {
        // Get values Game manager
        string coin = GameManager.Instance.Coins.ToString();
        string trash = GameManager.Instance.Trash.ToString();
        string plants = GameManager.Instance.Plants.ToString();

        //Get Values Controller Player
        float energycurrenty = controllerPlayer.currentEnergy;
        float maxEnergy = controllerPlayer.maxEnergy;

        // transform of canvas
        ChangeTextTrash(trash);
        ChangeTextCoin(coin);
        ChangeTextPlants(plants);
        BarProgressAltered((int)energycurrenty, (int)maxEnergy);
    }

    /* ============ChargeTextTrash============*/
    public void ChangeTextTrash(string newText)
    {
        // Verifica se o componente Text está presente
        if (textTrash != null)
        {
            // Altera o texto para o novo texto fornecido
            textTrash.text = newText;
        }
        else
        {
            Debug.LogError("Text component not assigned. Assign the Text component in the Inspector.");
        }
    }

    /* ============ChangeTextCoin============*/
    public void ChangeTextCoin(string newText)
    {
        // Verifica se o componente Text está presente
        if (textCoin != null)
        {
            // Altera o texto para o novo texto fornecido
            textCoin.text = newText;
        }
        else
        {
            Debug.LogError("Text component not assigned. Assign the Text component in the Inspector.");
        }
    }

    /* ============ChangeTextPlants============*/
    public void ChangeTextPlants(string newText)
    {
        // Verifica se o componente Text está presente
        if (textPlants != null)
        {
            // Altera o texto para o novo texto fornecido
            textPlants.text = newText;
        }
        else
        {
            Debug.LogError("Text component not assigned. Assign the Text component in the Inspector.");
        }
    }

    /* ============BarProgressAltered============*/
    public void BarProgressAltered(int currentyEnergy, int maxEnergy)
    {
        barEnergy.fillAmount = (float)currentyEnergy / maxEnergy;
        switch (barEnergy.fillAmount)
        {
            case 1f:
                barEnergy.color = Color.green;
                break;
            case 0.75f:
                barEnergy.color = Color.yellow;
                break;
            case 0.50f:
                barEnergy.color = new Color(1f, 0.5f, 0f);
                break;
            case 0.25f:
                barEnergy.color = Color.red;
                break;
        }
    }
}
