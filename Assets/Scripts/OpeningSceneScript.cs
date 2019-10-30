using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneScript : MonoBehaviour {

  public GameObject text;
  float time = 0;
  AudioSource openingSE;

  private void Start() {
    text.transform.position = new Vector2(0.28f, 0.07f);
    openingSE = GetComponent<AudioSource>();
    openingSE.PlayOneShot(openingSE.clip);
  }

  void Update() {
    time += Time.deltaTime;
    if (time > 2.5f) {
      SceneManager.LoadScene("stageSelect");
    }

    if (time >= 1.0f && text.transform.position.y < 3.44f) {
      text.transform.Translate(new Vector2(0, 0.1f));
    }
  }
}
