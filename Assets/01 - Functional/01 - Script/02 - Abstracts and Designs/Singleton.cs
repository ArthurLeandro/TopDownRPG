using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour {

  public static Singleton<T> instance;
  public void Init () {
    if (Singleton<T>.instance != null) {
      Destroy (this);
      return;
    }
    instance = this;
    DontDestroyOnLoad (this);
  }

}