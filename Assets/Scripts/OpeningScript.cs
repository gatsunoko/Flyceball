using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScript : MonoBehaviour {
  [RuntimeInitializeOnLoadMethod()]
  static void Init() {
    //Screen.SetResolution(800, 480, true, 30);
    Application.targetFrameRate = 60;
  }
}
