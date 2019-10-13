using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerChangeScript : MonoBehaviour {
  public string layerName;
  public int sortingOrder;

  void Update() {
    GetComponent<MeshRenderer>().sortingLayerName = layerName;
    GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
  }
}
