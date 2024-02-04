using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{

    public Button btnStart;
    public Button btnExit;
    public Button btnTutorial;
    void Start()
    {
        btnStart.onClick.AddListener(ClickBtnStart);
        btnExit.onClick.AddListener(ClickBtnExit);
        btnTutorial.onClick.AddListener(clickTutorial);
        Screen.fullScreen = true;
    }



    void ClickBtnStart()
    {
        SceneManager.LoadScene("Level01");
    }
    void ClickBtnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    void clickTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
