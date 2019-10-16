using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {

  PlayerScript playerScript;

  void Start() {
    this.playerScript = PlayerScript.playerScript;
  }

  private void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.tag == "Player") {
      //this.playerScript.dead = true;
    }
  }
}
