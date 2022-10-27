using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  private Rigidbody2D playerRB;

  [SerializeField]
  private float movementSpeed;

  void Start() {
    playerRB = GetComponent<Rigidbody2D>();
  }

  void Update() {
    playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movementSpeed * Time.deltaTime;

  }
}
