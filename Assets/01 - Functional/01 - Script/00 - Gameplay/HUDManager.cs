using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager:MonoBehaviour{
  public static HUDManager instance;
  [SerializeField] GameObject textContainer;
  [SerializeField] GameObject textPrefab;
  [SerializeField] List<FloatingText> floatingTexts = new List<FloatingText> ();
  public List<FloatingText> FloatingTexts{
    get{
      return this.floatingTexts;
    }
    set{
      this.floatingTexts = value;
    }
  }
  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake()
  {
      if (HUDManager.instance != null) {
      Destroy (this);
      return;
    }
    instance = this;
    DontDestroyOnLoad (this);
  }

  
  public void Show (string _message, int _fontSize, Color _color, Vector3 _position, Vector3 _motion, float _duration) {
    FloatingText floatingText = GetFloatingText ();
    floatingText.Txt.text = _message;
    floatingText.Txt.fontSize = _fontSize;
    floatingText.Txt.color = _color;
    floatingText.GO.transform.position = Camera.main.WorldToScreenPoint (_position);
    floatingText.Motion = _motion;
    floatingText.Duration = _duration;
    floatingText.Show();
  }

  public FloatingText GetFloatingText () {
    FloatingText txt = floatingTexts.Find (t => !t.Active);
    if (txt == null) {
      txt = new FloatingText ();
      txt.GO = Instantiate (textPrefab);
      txt.GO.transform.SetParent (textContainer.transform);
      txt.Txt = txt.GO.GetComponent<Text> ();
      floatingTexts.Add (txt);
    }
    return txt;
  }

}