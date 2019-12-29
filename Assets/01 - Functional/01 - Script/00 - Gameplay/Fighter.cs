using UnityEngine;

[RequireComponent (typeof (BoxCollider2D)), RequireComponent (typeof (SpriteRenderer))]
public class Fighter : MonoBehaviour {
  #region Properties

  #region Attributes
  [SerializeField] int hitPoint = 10;
  [SerializeField] int maxHitPoint = 10;
  [SerializeField] float pushRecoverySpeed = 0.2f;
  [SerializeField] float immuneTime = 1.0f;
  [SerializeField] float lastImmune;
  [SerializeField] Vector3 pushDirection;
  [SerializeField] MovementSystem movement = new MovementSystem ();
  [SerializeField] RendererSystem render = new RendererSystem ();
  [SerializeField] ColliderSystem colliderSystem = new ColliderSystem ();

  #endregion
  #region Getters & Setters
  public float PushRecoverySpeed {
    get {
      return this.pushRecoverySpeed;
    }
    set {
      this.pushRecoverySpeed = value;
    }
  }
  public MovementSystem Movement{
    get {
      return this.movement;
    }
    set{
      this.movement = value;
    }
  }
  #endregion
  #endregion
  #region Behaviours
  #region Life Cycle Hooks
  private void Awake () {
    this.movement.BoxCollider = GetComponent<BoxCollider2D> ();
    this.colliderSystem.LayerMasks = InitCollider ();
  }
  public virtual void Update () {
    transform.localScale = this.render.InvertSprite (this.movement.MoveDelta.x);
    colliderSystem.CollidingInXAxis (transform.position, this.movement.BoxCollider.size, new Vector2 (this.movement.MoveDelta.x, 0), this.colliderSystem.LayerMasks);
    colliderSystem.CollidingInYAxis (transform.position, this.movement.BoxCollider.size, new Vector2 (0, this.movement.MoveDelta.y), this.colliderSystem.LayerMasks);
    if (this.colliderSystem.XHit2D.collider == null && this.colliderSystem.YHit2D.collider == null) {
      transform.Translate (this.movement.MoveDelta * Time.deltaTime);
    }
  }
  #endregion
  #region Procedures
  public virtual void ReceiveDamage (Damage _damage) {
    if (Time.time - lastImmune > immuneTime) {
      lastImmune = Time.time;
      hitPoint -= _damage.DamageAmount;
      pushDirection = (transform.position - _damage.Origin).normalized * _damage.PushForce;
      pushDirection.z = 0;
      HUDManager.instance.Show (_damage.DamageAmount.ToString (), 250, Color.red, transform.position, Vector3.zero, 0.5f);
      if (hitPoint <= 0) {
        hitPoint = 0;
        Death ();
      }
      this.movement.MoveDelta+=pushDirection;
      pushDirection = Vector3.Lerp(pushDirection,Vector3.zero,pushRecoverySpeed);
    }
  }
  public virtual void Death () {

  }
  #endregion
  #region Functions
  public string[] InitCollider () {
    string[] layers = new string[2];
    layers[0] = "Actor";
    layers[1] = "Blocking";
    return layers;
  }
  #endregion
  #endregion
}