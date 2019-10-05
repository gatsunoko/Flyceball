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
  public Vector3 defaultPosition;
  public bool constantSpeed = false;
  public float constantSpeedTime = 3.0f;

  private void Start() {
    transform.position = destination[destination.Length - 1];
    //一定の速度で動かす場合の処理
    if (constantSpeed) {
      System.Array.Resize(ref time, destination.Length);
      //合計距離を求める
      float sumDistance = 0;
      int c = 0;
      foreach(Vector3 des in destination) {
        if (c < destination.Length - 1) {
          sumDistance += Vector3.Distance(destination[c], destination[c + 1]);
        }
        else {
          sumDistance += Vector3.Distance(destination[c], destination[0]);
        }
        c++;
      }
      //各距離の合計距離に対する割合を求める
      float d;
      c = 0;
      foreach(float t in time) {
        if (c < destination.Length - 1) {
          d = Vector3.Distance(destination[c], destination[c + 1]) / sumDistance;
        }
        else {
          d = Vector3.Distance(destination[c], destination[0]) / sumDistance;
        }
        time[c] = constantSpeedTime * d;
        //time[c] = d;
        c++;
      }
    }
    //初期化セット
    startPosition = transform.position;
    startTime = Time.timeSinceLevelLoad;
    defaultPosition = transform.position;
  }

  void FixedUpdate() {
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
      if (dx > 0.03 || dy > 0.03) {
        int t = 0;
        if (i == 0) {
          t = time.Length - 1;
        }
        else if (i > 0) {
          t = i - 1;
        }
        var diff = Time.timeSinceLevelLoad - startTime;

        var rate = diff / time[t];
        transform.position = Vector3.Lerp(startPosition, destination[i], rate);

        if (diff >= time[t]) {
          transform.position = destination[i];
          startTime = Time.timeSinceLevelLoad;
          startPosition = transform.position;
          if (i < destination.Length) {
            i++;
          }
          else {
            i = 0;
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
