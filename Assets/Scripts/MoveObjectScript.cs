using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour {
  public Vector3[] destination;
  int i = 0;
  public float speed = 10.0f;
  float defaultAngleZ = 0;

  private void Start() {
    defaultAngleZ = transform.eulerAngles.z;
  }

  void FixedUpdate() {
    if (i < destination.Length) {
      //目的地の方向を求める
      Vector2 direction = destination[i] - transform.position;

      //歩行処理
      float dx = Mathf.Abs(direction.x);
      float dy = Mathf.Abs(direction.y);
      if (dx > 0.02 || dy > 0.02) {
        float key_x = 0;
        float key_y = 0;
        if (direction.x > 0) {
          key_x = 1.0f;
        }
        else if (direction.x < 0) {
          key_x = -1.0f;
        }
        else {
          key_x = 0;
        }
        if (direction.y > 0) {
          key_y = 1.0f;
        }
        else if (direction.y < 0) {
          key_y = -1.0f;
        }
        else {
          key_y = 0;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(new Vector2(key_x * speed * 0.02f, key_y * speed * 0.02f));
        transform.rotation = Quaternion.Euler(0, 0, defaultAngleZ);

        //目的地通り過ぎた時に目的地まで戻す
        if (direction.x > 0) {
          if (destination[i].x < transform.position.x) {
            transform.position = new Vector2(destination[i].x, transform.position.y);
          }
        }
        else if (direction.x < 0) {
          if (destination[i].x > transform.position.x) {
            transform.position = new Vector2(destination[i].x, transform.position.y);
          }
        }
        if (direction.y > 0) {
          if (destination[i].y < transform.position.y) {
            transform.position = new Vector2(transform.position.x, destination[i].y);
          }
        }
        else if (direction.y < 0) {
          if (destination[i].y > transform.position.y) {
            transform.position = new Vector2(transform.position.x, destination[i].y);
          }
        }
      }
      else {
        i++;
      }
    }
    else {
      i = 0;
    }
  }
}
