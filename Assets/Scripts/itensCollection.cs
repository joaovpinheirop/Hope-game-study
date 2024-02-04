using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensCollection : MonoBehaviour
{
  /* ============VARIAVEIS============*/

  /* ============ColisionItem============*/
  private void OnTriggerEnter(Collider objeto)
  {
    // Verifica se o objeto colidido tem a tag "Madeira,Plastico e Ferro"
    if (objeto.gameObject.tag == "GarbageResidue" || objeto.gameObject.tag == "Coin")
    {
      // Destroi o objeto colidido após um pequeno atraso (0.1 segundos)
      Destroy(objeto.gameObject, 0.1f);
    }

    string item = objeto.gameObject.tag;

    switch (item)
    {
      case "GarbageResidue":
        GameManager.Instance.Trash += 1;
        break;
      case "Coin":
        GameManager.Instance.Coins += 1;
        break;
    }
  }
}