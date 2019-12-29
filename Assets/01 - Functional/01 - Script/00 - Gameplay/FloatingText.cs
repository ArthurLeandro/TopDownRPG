using UnityEngine;
using UnityEngine.UI;
public class FloatingText {
  [SerializeField] bool active;
  public bool Active {
    get {
      return this.active;
    }
  }

  [SerializeField] GameObject go;
  public GameObject GO {
    get {
      return this.go;
    }
    set {
      this.go = value;
    }
  }

  [SerializeField] Text text;
  public Text Txt {
    get{
      return this.text;
    }
    set {
      this.text = value;
    }
  }

  [SerializeField] Vector3 motion;
  public Vector3 Motion {
    get{
      return this.motion;
    }
    set {
      this.motion = value;
    }
  }
  [SerializeField] float duration;
  public float Duration {
    get{
      return this.duration;
    }
    set {
      this.duration = value;
    }
  }
  [SerializeField] float lastShown;

  public void Show () {
    active = true;
    lastShown = Time.time;
    go.SetActive (active);
  }
  public void Hide () {
    active = false;
    go.SetActive (active);
  }
  public void UpdateFloatingText () {
    if (!active) {
      return;
    }
    if (Time.time - lastShown > duration) {
      Hide ();
    }
    go.transform.position += motion * Time.deltaTime;
  }
}