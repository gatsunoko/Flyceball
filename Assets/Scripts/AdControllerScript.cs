using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdControllerScript : SingletonMonoBehaviourFast<AdControllerScript> {

  public float adIntervalTime = 300.0f;

  void Start() {
    DontDestroyOnLoad(this);
  }

  void Update() {
    this.adIntervalTime += Time.deltaTime;
  }
}
