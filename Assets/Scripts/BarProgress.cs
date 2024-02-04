using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarProgress : MonoBehaviour
{    /* ============VARIAVEIS============*/
    private UnityEngine.UI.Image barraDeProgresso;

    /* ============BarProgressModification============*/
    public void BarProgressAltered(int ProgressAtual, int ProgressMax)
    {
        barraDeProgresso.fillAmount = (float)ProgressAtual / ProgressMax;
    }

}
