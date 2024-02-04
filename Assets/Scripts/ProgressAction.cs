using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressAction : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    private int progressAtual;
    private int progressMax;
    [SerializeField] private BarProgress barProgress;

    /* ============START============*/
    void Start()
    {
        barProgress = FindAnyObjectByType<BarProgress>();
        progressAtual = 0;
        barProgress.BarProgressAltered(progressAtual, progressMax);
    }
}
