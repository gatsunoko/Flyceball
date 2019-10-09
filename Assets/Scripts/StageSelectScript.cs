using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour {

  public string number = "1";
  public bool myEnabled = true;

  void Start() {
  
  }

  void Update() {

  }

  public void onClickAct() {
    if (myEnabled) {
      SceneManager.LoadScene("stage" + number);
    }
  }
}
