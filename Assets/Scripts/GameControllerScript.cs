using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameControllerScript : MonoBehaviour {

  PlayerScript playerScript;
  float deathAfterTime = 0;
  public bool saveEnabled = false;
  float adBeforeTime = 0;

  void Start() {
    this.playerScript = PlayerScript.playerScript;
  }

  void Update() {
    if (this.playerScript.dead) {
      if (Advertisement.IsReady() && AdControllerScript.Instance.adIntervalTime >= 300.0f) {
        this.adBeforeTime += Time.deltaTime;
        if (this.adBeforeTime >= 1.0f) {
          if (GameObject.Find("StageUI")) {
            GameObject.Find("StageUI").gameObject.SetActive(false);
          }
          AdControllerScript.Instance.adIntervalTime = 0;
          Advertisement.Show();
          return;
        }
        return;
      }

      if (!Advertisement.isShowing) {
        this.deathAfterTime += Time.deltaTime;
        if (this.deathAfterTime >= 2.5f) {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //画面クリックしたらリセット
        if (Input.GetMouseButtonUp(0)) {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
      }
    }
  }
}
