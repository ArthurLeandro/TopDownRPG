using UnityEngine;

public class CameraComponent : MonoBehaviour {
  // [SerializeField] CameraFollowSystem cameraFollow = new CameraFollowSystem ();

  [SerializeField] Transform lookAt;
  public Transform LookAt {
    get {
      return this.lookAt;
    }
    set {
      this.lookAt = value;
    }
  }

  [SerializeField] float boundX = 0.15f;
  [SerializeField] float boundY = 0.05f;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake()
  {
    GameObject go = GameObject.Find("Player");
      this.LookAt = go.transform;
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void LateUpdate () {
    Vector3 delta = Vector3.zero;
    float deltaX = lookAt.position.x - transform.position.x;
    if (deltaX > boundX || deltaX < -boundX) {
      if (transform.position.x < lookAt.position.x) {
        delta.x = deltaX - boundX;
      } else {
        delta.x = deltaX + boundX;
      }
    }
    float deltaY = lookAt.position.y - transform.position.y;
    if (deltaY > boundY || deltaY < -boundY) {
      if (transform.position.y < lookAt.position.y) {
        delta.y = deltaY - boundY;
      } else {
        delta.y = deltaY + boundY;
      }
    }
    transform.position+=new Vector3(delta.x,delta.y,0);
  }
}