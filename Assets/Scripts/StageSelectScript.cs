using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour {

  public string number = "1";

  void Start() {
  
  }

  void Update() {

  }

  public void onClickAct() {
    SceneManager.LoadScene("stage" + number);
  }
}
