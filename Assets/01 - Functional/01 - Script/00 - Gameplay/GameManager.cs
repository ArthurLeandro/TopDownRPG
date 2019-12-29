using System;
using UnityEngine;
public class GameManager : MonoBehaviour {

  public static GameManager instance;
  
  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake () {
    if (GameManager.instance != null) {
      Destroy (this);
      return;
    }
    instance = this;
    DontDestroyOnLoad (this);
  }
  private void LateUpdate () {
    foreach (FloatingText txt in HUDManager.instance.FloatingTexts) {
      txt.UpdateFloatingText ();
    }
  }
  void Show (string _message, int _fontSize, Color _color, Vector3 _position, Vector3 _motion, float _duration) {
    HUDManager.instance.Show (_message, _fontSize, _color, _position, _motion, _duration);
  }

}