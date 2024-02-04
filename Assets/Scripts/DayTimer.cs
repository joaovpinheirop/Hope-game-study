using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
    /* ============VARIAVEIS============*/
    public float dayDuration = 60f; // duração do dia em segundos

    private Light sunLight;

    private float currentTime = 0f;

    void Start()
    {
        sunLight = GetComponent<Light>();
    }
    /* ============UPDATE============*/

    void Update()
    {
        currentTime += Time.deltaTime;

        float rotationAngle = currentTime / dayDuration * 360f;
        transform.rotation = Quaternion.Euler(new Vector3(rotationAngle, 140f, 0));
    }
}
