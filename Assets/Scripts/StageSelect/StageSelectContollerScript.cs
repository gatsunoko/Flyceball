﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectContollerScript : MonoBehaviour {

  public GameObject check;
  public GameObject[] stageObjects;
  //ステージ選択のクリック時にスワイプしてたらステージ選択クリックが発動しない為の
  [System.NonSerialized]
  public Vector3 cameraPosition;
  public Vector3 inputPosition;

  void Start() {
    //1,2,3は最初から解放
    for (int i = 1; i <= 3; i++) {
      string stage = "Stage" + i.ToString();
      if (PlayerPrefs.GetInt(stage) < 1) {
        PlayerPrefs.SetInt(stage, 1);
      }
    }
    //
    int stageClear;
    for (int i = 1; i <= 30; i++) {
      string stage = "Stage" + i.ToString();
      if (PlayerPrefs.HasKey(stage)) {
        stageClear = PlayerPrefs.GetInt(stage);
        if (stageClear == 2) {
          stageObjects[i - 1].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
          stageObjects[i - 1].GetComponent<StageSelectScript>().myEnabled = true;
          foreach (Transform childObject in stageObjects[i - 1].transform) {
            childObject.gameObject.GetComponent<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
          }
          GameObject checkInstance = Instantiate(check) as GameObject;
          checkInstance.transform.position = stageObjects[i - 1].transform.position;
        }
        else {
          stageObjects[i - 1].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
          stageObjects[i - 1].GetComponent<StageSelectScript>().myEnabled = true;
          foreach (Transform childObject in stageObjects[i - 1].transform) {
            childObject.gameObject.GetComponent<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
          }
        }
      }
      else {
        stageObjects[i - 1].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
          stageObjects[i - 1].GetComponent<StageSelectScript>().myEnabled = false;
        foreach (Transform childObject in stageObjects[i - 1].transform) {
          childObject.gameObject.GetComponent<TextMesh>().color = new Color(0.5f, 0.5f, 0.5f);
        }
      }
    }
  }
}
