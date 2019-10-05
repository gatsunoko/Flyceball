using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurukuruFromTimeScript : MonoBehaviour {
  public bool left = true;
  [SerializeField]
  float time = 3.0f;
  float rotAngle = 360f;
  float variation;
  float rot;
  //ずれを修正する為に一周終わったら時間になったら初期位置にリセットする為の変数
  [System.NonSerialized]
  public bool reseted = false;
  Quaternion defaultRotate;

  void Start() {
    variation = rotAngle / time;
    //ずれ修正の
    defaultRotate = transform.localRotation;
  }

  void Update() {
    //ずれを修正する処理
    if (reseted) {
      transform.localRotation = defaultRotate;
      reseted = false;
    }
    //回転処理
    if (left) {
      transform.Rotate(0, 0, variation * Time.deltaTime);
    }
    else {
      transform.Rotate(0, 0, variation * Time.deltaTime * -1);
    }
    rot += variation * Time.deltaTime;
    if (rot >= rotAngle) {
      rot = 0f;
    }
  }
}
