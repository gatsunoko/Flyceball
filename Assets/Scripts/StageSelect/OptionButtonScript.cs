using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtonScript : MonoBehaviour {

  Vector3 startPosition;
  [SerializeField]
  GameObject optionUI;

  public void OnClickStart() {
    startPosition = Input.mousePosition;
  }

  public void OnClickEnd() {
    Vector3 distance = startPosition - Input.mousePosition;
    float distanceX = Mathf.Abs(distance.x);
    float distanceY = Mathf.Abs(distance.y);

    if (distanceX < 20.0f && distanceY < 20.0f) {
      if (!optionUI.activeSelf) {
        optionUI.SetActive(true);
      }
      else {
        optionUI.SetActive(false);
      }
    }
  }
}
