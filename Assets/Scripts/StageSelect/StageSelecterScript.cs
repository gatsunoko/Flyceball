﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecterScript : MonoBehaviour {

  public GameObject[] stages;
  public float paddingX = 1.0f;
  public float paddingY = 1.0f;

  void Update() {
    int x = 1;
    float y = 1.0f;
    foreach (GameObject stage in stages) {
      stage.transform.position = new Vector2(paddingX * x, y);
      x++;
      if (x > 5) {
        x = 1;
        y = y - paddingY;
      }
    }
  }
}
