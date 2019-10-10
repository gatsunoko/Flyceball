using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

  AudioSource goalSound;
  StageDirectorScript stageDirectorScript;
  public string thisStage = "1";
  public string nextStage = "4";

  void Start() {
    this.goalSound = GetComponent<AudioSource>();
    this.stageDirectorScript = GameObject.Find("StageDirector").GetComponent<StageDirectorScript>();
  }

  private void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.tag == "Player" && !this.stageDirectorScript.clear) {
      this.goalSound.PlayOneShot(goalSound.clip);
      this.stageDirectorScript.clear = true;
      PlayerPrefs.SetInt("Stage" + thisStage, 2);
      if (PlayerPrefs.GetInt("Stage" + nextStage) != 2) {
        PlayerPrefs.SetInt("Stage" + nextStage, 1);
      }
    }
  }
}
