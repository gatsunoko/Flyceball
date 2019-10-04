using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCameraScript : MonoBehaviour {

  public Vector3 spritePositionStart;
  public Vector3 spritePositionEnd;
  GameObject mainCamera;
  Vector2 mainCameraPosition;
  CameraScript mainCameraScript;

  void Start() {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    mainCameraScript = mainCamera.GetComponent<CameraScript>();
  }

  void Update() {
    mainCameraPosition = mainCamera.transform.position;
    //メインカメラの現在位置から後景エリアの残り割合を調べる
    float pEndX = mainCameraScript.xUpper - mainCameraScript.xLower;
    float currentPlayerPosition = (mainCameraScript.xUpper - mainCameraPosition.x) / pEndX;
    currentPlayerPosition = 1 - currentPlayerPosition;
    //プレイヤーの位置に合わせて後景カメラの位置調整
    float cameraDiff = (spritePositionEnd.x - spritePositionStart.x) * currentPlayerPosition;
    cameraDiff = spritePositionStart.x + cameraDiff;
    transform.position = new Vector3(cameraDiff, spritePositionStart.y, -10);
  }
}
