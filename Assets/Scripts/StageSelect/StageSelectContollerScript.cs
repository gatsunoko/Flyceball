using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectContollerScript : MonoBehaviour {

  public GameObject check;
  public GameObject[] stageObjects;
  //ステージ選択のクリック時にスワイプしてたらステージ選択クリックが発動しない為の
  [System.NonSerialized]
  public Vector3 cameraPosition;
  public Vector3 inputPosition;
  //トップロゴ
  public GameObject titleText;
  public GameObject titleTextClear;
  bool clear = true;

  void Start() {
    Screen.SetResolution(800, 480, false, 60);
    //1,2,3は最初から解放
    for (int i = 1; i <= 3; i++) {
      string stage = "Stage" + i.ToString();
      if (PlayerPrefs.GetInt(stage) < 1) {
        PlayerPrefs.SetInt(stage, 1);
      }
    }
    int stageClear;
    for (int i = 1; i <= 30; i++) {
      string stage = "Stage" + i.ToString();
      if (PlayerPrefs.HasKey(stage)) {
        stageClear = PlayerPrefs.GetInt(stage);
        if (stageClear == 2) {
          StageButtonChange(i, true, 1.0f);
          //クリアした場所にはチェックボタンをつける
          GameObject checkInstance = Instantiate(check) as GameObject;
          checkInstance.transform.position = stageObjects[i - 1].transform.position;
        }
        else {
          StageButtonChange(i, true, 1.0f);
          clear = false;
        }
      }
      else {
        StageButtonChange(i, false, 0.5f);
        clear = false;
      }
    }
    if (clear) {
      titleText.SetActive(false);
      titleTextClear.SetActive(true);
    }
    else {
      titleText.SetActive(true);
      titleTextClear.SetActive(false);
    }
  }

  void StageButtonChange(int number, bool enabled, float color) {
    stageObjects[number - 1].GetComponent<SpriteRenderer>().color = new Color(color, color, color);
    stageObjects[number - 1].GetComponent<StageSelectScript>().myEnabled = enabled;
    foreach (Transform childObject in stageObjects[number - 1].transform) {
      childObject.gameObject.GetComponent<TextMesh>().color = new Color(color, color, color);
    }
  }
}
