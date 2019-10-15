using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour {

  public string number = "1";
  public bool myEnabled = true;
  public GameObject mainCamera;
  public GameObject stageSelectController;
  StageSelectContollerScript stageSelectControllerScript;

  private void Start() {
    stageSelectControllerScript = stageSelectController.GetComponent<StageSelectContollerScript>();
  }

  public void OnClickStart() {
    stageSelectControllerScript.cameraPosition = mainCamera.transform.position;
    stageSelectControllerScript.inputPosition = Input.mousePosition;
  }

  public void OnClickEnd() {
    if (stageSelectControllerScript.cameraPosition == mainCamera.transform.position &&
        stageSelectControllerScript.inputPosition == Input.mousePosition) {
      if (myEnabled) {
        SceneManager.LoadScene("stage" + number);
      }
    }
  }
}
