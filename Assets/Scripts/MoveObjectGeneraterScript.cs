using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectGeneraterScript : MonoBehaviour {

  public GameObject generateObject;
  public float generateDelayTime = 3.0f;
  float delayTime = 100.0f;
  public Vector2[] destination;
  public Vector2[] Speed;

  void Start() {
    GetComponent<SpriteRenderer>().enabled = false;
  }

  void Update() {
    delayTime += Time.deltaTime;
    if (delayTime > generateDelayTime) {
      delayTime = 0;
      //生成
      var parent = this.transform;
      GameObject floorInstance = Instantiate(generateObject, parent) as GameObject;
      floorInstance.transform.position = new Vector2(transform.position.x, transform.position.y);

      ManyGeneraterChildScript floorInstanceScript = floorInstance.GetComponent<ManyGeneraterChildScript>();
      floorInstanceScript.destination = this.destination;
      floorInstanceScript.Speed = this.Speed;
    }
  }

}
