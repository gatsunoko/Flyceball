using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
  }
}
