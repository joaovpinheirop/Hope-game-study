using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCAm : MonoBehaviour
{

    /* ============VARIAVEIS============*/
    public Transform target; // Referencia de qual objeto a camera vai seguir
    public Vector3 offset = new Vector3(0f, 2f, -5f);  // Distância da câmera em relação ao jogador

    /* ============UPDATE============*/

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            // Define a nova posição da câmera
            transform.position = desiredPosition;

            // Certifique-se de que a câmera está sempre olhando para o jogador
            transform.LookAt(target);
        }
    }
}
