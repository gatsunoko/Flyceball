using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour {

  //　SoundOptionキャンバスを設定
  [SerializeField]
  private GameObject soundOptionUI;
  [SerializeField]
  private AudioMixer audioMixer;
  [SerializeField]
  private GameObject sliderObject;
  private Slider slider;

  private void Start() {
    soundOptionUI.SetActive(false);
    slider = sliderObject.GetComponent<Slider>();
    if (PlayerPrefs.HasKey("AudioVolume")) {
      slider.value = PlayerPrefs.GetFloat("AudioVolume");
    }
    else {
      slider.value = 0;
    }
  }

  public void SetMaster(float volume) {
    audioMixer.SetFloat("Master", slider.value);
    PlayerPrefs.SetFloat("AudioVolume", slider.value);
  }
}
