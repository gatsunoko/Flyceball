using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDirectorScript : MonoBehaviour {

  public bool clear = false;
  float clearAfterTime = 0;

  void Update() {
    if (this.clear) {
      this.clearAfterTime += Time.deltaTime;
      if (this.clearAfterTime >= 3.0f) {
        SceneManager.LoadScene("StageSelect");
      }
    }
  }
}
