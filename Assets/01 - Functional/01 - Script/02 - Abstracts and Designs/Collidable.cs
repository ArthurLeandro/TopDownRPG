using System;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D)), RequireComponent (typeof (SpriteRenderer))]
public class Collidable : MonoBehaviour {

  #region Properties
  [SerializeField] ContactFilter2D filter;
  public ContactFilter2D Filter2D {
    get { return this.filter; } set { this.filter = value; }
  }

  [SerializeField] BoxCollider2D boxCollider;
  public BoxCollider2D BoxCollider {
    get { return this.boxCollider; } set { this.boxCollider = value; }
  }

  [SerializeField] Collider2D[] hits;
  public Collider2D[] Hits {
    get { return this.hits; } set { this.hits = value; }
  }
  #endregion
  #region Life Cycle
  private void Awake () {
    this.boxCollider = GetComponent<BoxCollider2D> ();
  }
  #endregion

  #region Methods
  public void Colliding () {
    boxCollider.OverlapCollider (this.filter, this.hits);
    for (int i = 0; i < hits.Length; i++) {
      if (this.hits[i] == null) {
        continue;
      }
      OnCollide (hits[i]);
      hits[i] = null;
    }
  }
  public virtual void OnCollide (Collider2D col) {
    if (col.tag.Equals ("Fighter")) {
      Action ();
    }
  }

  public virtual void Action () {
    Debug.Log("The method Action wasn't implemented in "+ this.name);
  }
  #endregion

}