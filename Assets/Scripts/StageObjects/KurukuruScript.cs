using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurukuruScript : MonoBehaviour {

  Vector2 defaultPosition;
  Rigidbody2D rigid2d;
  public float moveSpeed = 0.5f;

  void Start() {
    this.rigid2d = GetComponent<Rigidbody2D>();
    defaultPosition = new Vector2(transform.position.x, transform.position.y);
  }

  private void FixedUpdate() {
    transform.Rotate(new Vector3(0f, 0f, moveSpeed));
  }
}
