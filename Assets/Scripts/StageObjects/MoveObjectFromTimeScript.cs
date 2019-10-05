using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectFromTimeScript : MonoBehaviour {
  public Vector3[] destination;
  int i = 0;
  public float[] time;
  //コピペ元にあった
  private float startTime;
  private Vector3 startPosition;
  [System.NonSerialized]
  public bool reseted = false;
  Vector3 defaultPosition;

  private void Start() {
    startPosition = transform.position;
    startTime = Time.timeSinceLevelLoad;
    defaultPosition = transform.position;
  }

  void Update() {
    if (reseted) {
      i = 0;
      transform.position = defaultPosition;
      startPosition = transform.position;
      startTime = Time.timeSinceLevelLoad;
      reseted = false;
    }
    //移動処理
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

        //transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.Translate(new Vector2(key_x * speed * 0.02f, key_y * speed * 0.02f));
        //transform.rotation = Quaternion.Euler(0, 0, defaultAngleZ);

        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time[i]) {
          transform.position = destination[i];
        }

        var rate = diff / time[i];
        //var pos = curve.Evaluate(rate);

        transform.position = Vector3.Lerp(startPosition, destination[i], rate);

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
        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
        i++;
      }
    }
    else {
      startTime = Time.timeSinceLevelLoad;
      startPosition = transform.position;
      i = 0;
    }
  }
}
