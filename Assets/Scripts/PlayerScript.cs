using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
  public static PlayerScript playerScript;

  Rigidbody2D rigid2d;
  Animator animator;
  PolygonCollider2D polygonCollider;
  bool clicked = false;
  //bool grounded = false;
  public float flyForceX = 1.0f;
  public float flyForceY = 8.0f;
  float maxVelocityX = 4.0f;
  float maxVelocityY = 15.0f;
  public bool dead = false; //死んだらtrue
  bool deadAnimation = true;
  StageDirectorScript stageDirectorScript;
  AudioSource deadSound;
  public LayerMask groundLayer;

  //カメラのStart関数でプレイヤーの位置を仕様する為、初期位置の設定はAwakeで行う
  void Awake() {
    playerScript = this;
  }

  void Start() {
    this.rigid2d = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
    this.stageDirectorScript = GameObject.Find("StageDirector").GetComponent<StageDirectorScript>();
    this.polygonCollider = GetComponent<PolygonCollider2D>();
    this.deadSound = GetComponent<AudioSource>();
  }

  void FixedUpdate() {
    if (!this.dead) {
      //グラウンド判定
      Vector2 linePos = transform.position;
      linePos.y -= 0.378f;
      bool[] grounded = new bool[2] { false, false };
      grounded[0] = Physics2D.Linecast(transform.position, linePos, groundLayer);
      linePos.y += 0.378f;
      linePos.y += 0.436f;
      grounded[1] = Physics2D.Linecast(transform.position, linePos, groundLayer);
      //加速処理
      if (this.clicked && this.rigid2d.velocity.y < this.maxVelocityY) {
        this.rigid2d.AddForce(new Vector2(0, this.flyForceY));
        if (!grounded[0] && !grounded[1] && this.rigid2d.velocity.x < this.maxVelocityX) {
          this.rigid2d.AddForce(new Vector2(this.flyForceX, 0));
        }
      }
    }
    else {
      this.polygonCollider.isTrigger = true;
      this.rigid2d.velocity = new Vector2(0, 0);
      transform.rotation = Quaternion.Euler(0, 0, 0);
      if (this.deadAnimation) {
        this.deadSound.PlayOneShot(deadSound.clip);
        this.animator.SetTrigger("Dead");
        this.deadAnimation = false;
      }
    }
    //クリアしていたら右に移動する
    if (this.stageDirectorScript.clear) {
      //this.rigid2d.bodyType = RigidbodyType2D.Kinematic;
      //this.rigid2d.velocity = new Vector2(0, 0);
      //transform.rotation = Quaternion.Euler(0, 0, 0);
      this.polygonCollider.isTrigger = true;
      this.rigid2d.velocity = new Vector2(5.0f, 0);
    }
  }

  void Update() {
    if (Input.GetMouseButton(0)) {
      this.clicked = true;
    }
    else {
      this.clicked = false;
    }
  }

  //private void OnCollisionStay2D(Collision2D col) {
  //  if (col.gameObject.tag == "Ground") {
  //    this.grounded = true;
  //  }
  //}

  //private void OnCollisionExit2D(Collision2D col) {
  //  if (col.gameObject.tag == "Ground") {
  //    this.grounded = false;
  //  }
  //}
}
