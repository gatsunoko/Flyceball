﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipeScript : MonoBehaviour {

  Vector3 start;
  Vector3 end;
  Vector3 startPosition;
  float deltaX = 0f;
  float maxY = 0.25f;
  float minY = -10.55f;
  public GameObject upArrow;
  public GameObject downArrow;

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      start = Input.mousePosition;
      startPosition = transform.position;
    }
    if (Input.GetMouseButton(0)) {
      end = Input.mousePosition;
      deltaX = (start - end).y;
      deltaX = deltaX * 0.025f;
      float cameraY = Mathf.Clamp(startPosition.y + deltaX, minY, maxY);
      transform.position = new Vector3(startPosition.x, cameraY, startPosition.z);
    }
    if (transform.position.y < maxY) {
      upArrow.SetActive(true);
    }
    else {
      upArrow.SetActive(false);
    }
    if (transform.position.y > minY) {
      downArrow.SetActive(true);
    }
    else {
      downArrow.SetActive(false);
    }
  }
}