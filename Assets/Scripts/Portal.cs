using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    public Color novaCorEmissao = Color.green;
    private Material material;


    /* ============START============*/
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    /* ============UPDATE============*/
    void Update()
    {
        if (GameManager.Instance.isPortalActive)
        {
            material.SetColor("_EmissionColor", novaCorEmissao);
            material.color = novaCorEmissao;
        }
    }
}
