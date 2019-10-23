using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipeScript : MonoBehaviour {

  Vector3 start;
  Vector3 end;
  Vector3 startPosition;
  float deltaX = 0f;
  float maxY = 0.25f;
  float minY = -10.55f;
  public GameObject upArrow;
  public GameObject downArrow;
  // マウスホイールの回転値を格納する変数
  private float scroll;
  public float speed = 1f;

  private void Start() {
    if (PlayerPrefs.HasKey("cameraX") && PlayerPrefs.HasKey("cameraY")) {
      transform.position = new Vector3(PlayerPrefs.GetFloat("cameraX"), PlayerPrefs.GetFloat("cameraY"), -10.0f);
    }
  }

  void Update() {
    float cameraY;
    //スワイプ移動
    if (Input.GetMouseButtonDown(0)) {
      start = Input.mousePosition;
      startPosition = transform.position;
    }
    if (Input.GetMouseButton(0)) {
      end = Input.mousePosition;
      deltaX = (start - end).y;
      deltaX = deltaX * 0.025f;
      cameraY = Mathf.Clamp(startPosition.y + deltaX, minY, maxY);
      transform.position = new Vector3(startPosition.x, cameraY, startPosition.z);
    }

    //マウスホイール移動
    scroll = Input.GetAxis("Mouse ScrollWheel");
    transform.position += new Vector3(0, scroll * speed, 0);
    cameraY = Mathf.Clamp(transform.position.y, minY, maxY);//上下の限界を超えないように
    transform.position = new Vector3(transform.position.x, cameraY, -10.0f);

    //上下に移動できる時は矢印表示
    if (transform.position.y < maxY) {
      upArrow.SetActive(true);
    }
    else {
      upArrow.SetActive(false);
    }
    if (transform.position.y > minY) {
      downArrow.SetActive(true);
    }
    else {
      downArrow.SetActive(false);
    }
  }
}
