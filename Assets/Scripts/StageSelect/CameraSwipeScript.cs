using System.Collections;
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

  private void Start() {
    if (PlayerPrefs.HasKey("cameraY")) {
      transform.position = new Vector3(9.91f, PlayerPrefs.GetFloat("cameraY"), -10.0f);
    }
  }

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
      transform.position = new Vector3(9.91f, cameraY, -10.0f);
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
