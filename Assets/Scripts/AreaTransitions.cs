using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour {
  private CameraController camView;
  public Vector2 newMinPosition;
  public Vector2 newMaxPosition;

  void Start() {
    camView = Camera.main.GetComponent<CameraController>();
  }

  void Update() {

  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
        camView.minPosition = newMinPosition;
        camView.maxPosition = newMaxPosition;
    }
  }
}
