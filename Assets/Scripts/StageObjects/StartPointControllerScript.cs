using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPointControllerScript : MonoBehaviour {

  [System.NonSerialized]
  public Vector2 startPoint = new Vector2(6.04f, -46.04f);

  private void Awake() {
    if (GameObject.FindGameObjectsWithTag("StartPointController").Length > 1) {
      Destroy(this.gameObject);
      return;
    }
  }

  private void Start() {
    DontDestroyOnLoad(this);
    SceneManager.sceneLoaded += SceneLoaded;
  }

  void SceneLoaded(Scene nextScene, LoadSceneMode mode) {
    //プレイヤーを初期位置へ
    if (nextScene.name != "StageSelect" &&
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().saveEnabled) {
      GameObject player = GameObject.FindGameObjectWithTag("Player");
      player.transform.position = startPoint;
    }
  }
}
