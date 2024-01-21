using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trunk : MonoBehaviour
{
    private bool opened = false;
    public GameObject Bau; 

// Update is called once per frame
    private void Update()
    {
        // Verifica se o jogador está dentro do colisão  e pressionou a tecla "E"
        if (opened && Input.GetKeyDown(KeyCode.E))
        {
            // Lógica para o que acontece quando o jogador pressiona "E"
            Debug.Log("O TRUNK FOI ABERTO.");
        }
    }

    // Função chamada quando um Collider entra na colisão do Trunk
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto entrou 
        if (other.gameObject.tag == "Trunk")
        {
            // Atualiza a variável indicando que o jogador está dentro do colisão 
            opened = true;
            Debug.Log("true");
        }
    }

        // Função chamada quando um Collider sai da colisão do Trunk
        private void OnTriggerExit(Collider other)
        {
            // Verifica se o objeto saiu
            if (other.gameObject.tag == "Trunk")
            {

                 // Atualiza a variável indicando que o jogador está fota da colisão 
                opened = false;
                Debug.Log("False");
            }
        }


}
