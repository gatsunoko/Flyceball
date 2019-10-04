using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

  GameObject player;
  public float xLower;
  public float xUpper;
  public float yLower;
  public float yUpper;
  float maxVelocityX = 5.0f;

  void Start(){
    this.player = PlayerScript.playerScript.gameObject;
    //初期位置をプレイヤーポジション
    float camX = Mathf.Clamp(this.player.transform.position.x + 2.0f, xLower, xUpper);
    float camY = Mathf.Clamp(this.player.transform.position.y, yLower, yUpper);
    transform.position = new Vector3(camX, camY, transform.position.z);
  }

  private void FixedUpdate() {
    Vector3 playerPos = this.player.transform.position;
    float camX = Mathf.Clamp(playerPos.x + 2.0f, xLower, xUpper);
    float camY = Mathf.Clamp(playerPos.y, yLower, yUpper);

    transform.Translate(new Vector2((camX - transform.position.x) * 5.0f * Time.deltaTime,
      (camY - transform.position.y) * 5.0f * Time.deltaTime));
  }

  void Update() {

  }
}
