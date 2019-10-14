using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOnigiriGeneraterScript : MonoBehaviour {

  public GameObject onigiri;
  float x;
  float time = 0;

  void Start() {

  }

  void Update() {
    time += Time.deltaTime;
    if (time >= 0.3f) {
      time = 0;
      GameObject onigiriInstance = Instantiate(onigiri) as GameObject;
      x = Random.Range(2.43f, 18.59f);
      onigiriInstance.transform.position = new Vector2(x, 3.54f);
    }
  }
}
