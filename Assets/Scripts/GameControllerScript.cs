using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

  PlayerScript playerScript;
  float deathAfterTime = 0;

  void Start() {
    this.playerScript = PlayerScript.playerScript;
  }

  void Update() {
    if (this.playerScript.dead) {
      this.deathAfterTime += Time.deltaTime;
      if (this.deathAfterTime >= 2.5f) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
  }
}
