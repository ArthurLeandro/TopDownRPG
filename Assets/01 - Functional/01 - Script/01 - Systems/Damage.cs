using UnityEngine;

public class Damage {

  #region Properties
  #region Attributes
  [SerializeField] Vector3 origin;
  [SerializeField] int damageAmount;
  [SerializeField] float pushForce;
  #endregion
  #region Getters & Setters
  public Vector3 Origin {
    get {
      return this.origin;
    }
    set {
      this.origin = value;
    }
  }

  public int DamageAmount {
    get {
      return this.damageAmount;
    }
    set {
      this.damageAmount = value;
    }
  }
  public float PushForce {
    get {
      return this.pushForce;
    }
    set {
      this.pushForce = value;
    }
  }
  #endregion
  #endregion



}