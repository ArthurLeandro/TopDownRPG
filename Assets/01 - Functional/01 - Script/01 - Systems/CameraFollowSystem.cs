using UnityEngine;
using System;

[Serializable]
public class CameraFollowSystem {
  [SerializeField] Transform lookAt;
  public Transform LookAt {
    get {
      return this.lookAt;
    }
    set {
      this.lookAt = value;
    }
  }
  float boundX = 0.15f;
  float boundY = 0.05f;

  public Vector3 FollowPlayer (Vector2 _position) {
    Vector3 delta = new Vector3(_position.x,_position.y,-10);
    float deltaX = lookAt.position.x - _position.x;
    if (deltaX > boundX || deltaX < -boundX) {
      if (_position.x < lookAt.position.x) {
        delta.x = deltaX - boundX;
      } else {
        delta.x = deltaX + boundX;
      }
    }
    float deltaY = lookAt.position.y - _position.y;
    if (deltaY > boundY || deltaY < -boundY) {
      if (_position.y < lookAt.position.y) {
        delta.y = deltaY - boundY;
      } else {
        delta.y = deltaY + boundY;
      }
    }
    return delta;
  }
}