using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ColliderSystem {

  [SerializeField] RaycastHit2D Yhit2D;
  [SerializeField] RaycastHit2D Xhit2D;
  [SerializeField] string[] layerMasks;
  public RaycastHit2D XHit2D {
    get {
      return this.Xhit2D;
    }
    set {
      this.Xhit2D = value;
    }
  }
  public RaycastHit2D YHit2D {
    get {
      return this.Yhit2D;
    }
    set {
      this.Yhit2D = value;
    }
  }
  public string[] LayerMasks{
    get{
      return this.layerMasks;
    }
    set{
      this.layerMasks=value;
    }
  }
  public void CollidingInYAxis (Vector2 _position, Vector2 _boxcolliderSize, Vector2 _direction, string[] _masks) {
    this.Yhit2D = Physics2D.BoxCast (_position, _boxcolliderSize, 0, _direction, Mathf.Abs (_direction.y * Time.deltaTime),
      LayerMask.GetMask (_masks));
  }
  
  public void CollidingInXAxis (Vector2 _position, Vector2 _boxcolliderSize, Vector2 _direction, string[] _masks) {
    this.Xhit2D = Physics2D.BoxCast (_position, _boxcolliderSize, 0, _direction, Mathf.Abs (_direction.x * Time.deltaTime),
      LayerMask.GetMask (_masks));
  }
}