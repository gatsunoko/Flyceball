using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChangeScript : MonoBehaviour {

  public Vector2 smallSize;
  public Vector2 bigSize;
  public float toSmallTime = 2.0f;
  public float toBigTime = 2.0f;
  float time = 0;
  bool goBig = true;
  [System.NonSerialized]
  public bool reseted = false;

  void Start() {
  
  }

  void Update() {
    if (reseted) {
      time = 0;
      goBig = true;
      transform.localScale = smallSize;
      reseted = false;
    }
    time += Time.deltaTime;
    float timeRatio;
    if (goBig) {
      timeRatio = time / toBigTime;
      transform.localScale = Vector3.Lerp(smallSize, bigSize, time / toBigTime);
      if (transform.localScale.x >= bigSize.x && transform.localScale.y >= bigSize.y) {
        time = 0;
        goBig = false;
      }
    }
    else {
      timeRatio = time / toSmallTime;
      transform.localScale = Vector3.Lerp(bigSize, smallSize, time / toSmallTime);
      if (transform.localScale.x <= smallSize.x && transform.localScale.y <= smallSize.y) {
        time = 0;
        goBig = true;
      }
    }
  }
}
