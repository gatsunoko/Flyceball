using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControlScript : MonoBehaviour {

  float time;
  public float resetTime = 3;
  public GameObject[] controleObjects;
  List<MoveObjectFromTimeScript> moveObjectScripts = new List<MoveObjectFromTimeScript>();
  List<KurukuruFromTimeScript> kurukuruScripts = new List<KurukuruFromTimeScript>();
  List<ScaleChangeScript> scaleChangeScripts = new List<ScaleChangeScript>();

  void Start() {
    foreach (GameObject controleObject in controleObjects) {
      if (controleObject.GetComponent<MoveObjectFromTimeScript>()) {
        moveObjectScripts.Add(controleObject.GetComponent<MoveObjectFromTimeScript>());
      }
      if (controleObject.GetComponent<KurukuruFromTimeScript>()) {
        kurukuruScripts.Add(controleObject.GetComponent<KurukuruFromTimeScript>());
      }
      if (controleObject.GetComponent<ScaleChangeScript>()) {
        scaleChangeScripts.Add(controleObject.GetComponent<ScaleChangeScript>());
      }
    }
  }

  void Update() {
    time += Time.deltaTime;
    if (time >= resetTime) {
      time = 0;
      foreach(MoveObjectFromTimeScript moveObjectScript in moveObjectScripts) {
        moveObjectScript.reseted = true;
      }
      foreach(KurukuruFromTimeScript kurukuruScript in kurukuruScripts) {
        kurukuruScript.reseted = true;
      }
      foreach (ScaleChangeScript scaleChangeScript in scaleChangeScripts) {
        scaleChangeScript.reseted = true;
      }
    }
  }
}
