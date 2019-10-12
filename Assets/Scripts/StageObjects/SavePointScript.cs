using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointScript : MonoBehaviour {

  public Vector2 myPoint;
  public GameObject StartPointController;
  StartPointControllerScript startPointControllerScript;

  void Start() {
    startPointControllerScript = StartPointController.GetComponent<StartPointControllerScript>();
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Player") {
      startPointControllerScript.startPoint = myPoint;
    }
  }
}
