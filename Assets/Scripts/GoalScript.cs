using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

  AudioSource goalSound;
  StageDirectorScript stageDirectorScript;

  void Start() {
    this.goalSound = GetComponent<AudioSource>();
    this.stageDirectorScript = GameObject.Find("StageDirector").GetComponent<StageDirectorScript>();
  }

  private void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.tag == "Player" && !this.stageDirectorScript.clear) {
      this.goalSound.PlayOneShot(goalSound.clip);
      this.stageDirectorScript.clear = true;
      if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name) || PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < 2) {
        for (int i = 1; i <= 30; i++) {
          if (!PlayerPrefs.HasKey("Stage" + i.ToString()) || PlayerPrefs.GetInt("Stage" + i.ToString()) < 1) {
            PlayerPrefs.SetInt("Stage" + i.ToString(), 1);
            break;
          }
        }
      }
      PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 2);
    }
  }
}
