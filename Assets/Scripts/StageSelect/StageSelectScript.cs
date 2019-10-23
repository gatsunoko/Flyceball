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
    Vector3 distance = stageSelectControllerScript.inputPosition - Input.mousePosition;
    float distanceX = Mathf.Abs(distance.x);
    float distanceY = Mathf.Abs(distance.y);
    Vector3 cameraDistance = stageSelectControllerScript.cameraPosition - mainCamera.transform.position;
    float CameraDistanceX = Mathf.Abs(cameraDistance.x);
    float CameraDistanceY = Mathf.Abs(cameraDistance.y);

    if (CameraDistanceX < 20.0f && CameraDistanceY < 20.0f &&
        distanceX < 35.0f && distanceY < 35.0f) {
      if (myEnabled) {
        PlayerPrefs.SetFloat("cameraX", mainCamera.transform.position.x);
        PlayerPrefs.SetFloat("cameraY", mainCamera.transform.position.y);
        SceneManager.LoadScene("stage" + number);
      }
    }
  }
}
