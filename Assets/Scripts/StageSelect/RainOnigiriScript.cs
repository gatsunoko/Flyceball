using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOnigiriScript : MonoBehaviour {

  void Update() {
    if (transform.position.y <= -10.10497f) {
      Destroy(gameObject);
    }
  }
}
