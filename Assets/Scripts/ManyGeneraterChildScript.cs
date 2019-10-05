using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyGeneraterChildScript : MonoBehaviour {

  int count = 0;
  public Vector2[] destination;
  public Vector2[] Speed;
  bool xArrival = false;
  bool yArrival = false;
  bool destroy = false;
  public bool destinationPresent = true;

  void Start() {
  }

  void Update() {
    transform.Translate(new Vector2(Speed[count].x * Time.deltaTime * Time.timeScale, Speed[count].y * Time.deltaTime * Time.timeScale));
    // 削除判定trueで子オブジェクトなかったら削除
    if (this.destroy && transform.childCount == 0) {
      Destroy(this.gameObject);
    }
    if (this.destroy) {
      transform.DetachChildren();
    }
  }

  private void LateUpdate() {
    if (destinationPresent) {
      if (Speed[count].x > 0) {
        if (transform.position.x >= destination[count].x) {
          transform.position = new Vector2(destination[count].x, transform.position.y);
          xArrival = true;
        }
      }
      else if (Speed[count].x < 0) {
        if (transform.position.x <= destination[count].x) {
          transform.position = new Vector2(destination[count].x, transform.position.y);
          xArrival = true;
        }
      }
      else {
        xArrival = true;
      }
      if (Speed[count].y > 0) {
        if (transform.position.y >= destination[count].y) {
          transform.position = new Vector2(transform.position.x, destination[count].y);
          yArrival = true;
        }
      }
      else if (Speed[count].y < 0) {
        if (transform.position.y <= destination[count].y) {
          transform.position = new Vector2(transform.position.x, destination[count].y);
          yArrival = true;
        }
      }
      else {
        yArrival = true;
      }

      if (xArrival && yArrival) {
        count++;
        if (count >= destination.Length) {
          Destroy(gameObject);
        }
        xArrival = false;
        yArrival = false;
      }
    }
  }

  private void OnTriggerExit2D(Collider2D col) {
    if (col.gameObject.tag == "Player") {
      transform.DetachChildren();
    }
  }
}
