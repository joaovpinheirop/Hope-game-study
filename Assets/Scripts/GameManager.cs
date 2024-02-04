using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  /* ============VARIAVEIS============*/
  public static GameManager Instance { get; private set; }
  [Header(" Game manager")]
  public int Coins = 0;
  public int Trash = 0;
  public int Plants = 0;
  private Mission mission;
  public bool isPortalActive = false;
  public String nameNextScene;

  /* ============Start============*/
  void Start()
  {
    mission = FindAnyObjectByType<Mission>();

  }

  // /* ============UPDATE============*/
  // void Update()
  // {
  //   Plants = Mathf.Max(mission.Plants, Plants);
  //   Trash = Mathf.Max(mission.Trash, Trash);
  // }
  // /* ============Awake============*/
  void Awake()
  {
    // Destruir a instance antiga 
    if (Instance != null && Instance != this)
    {
      Destroy(this);
    }
    else
    {
      Instance = this;
    }

  }
}
