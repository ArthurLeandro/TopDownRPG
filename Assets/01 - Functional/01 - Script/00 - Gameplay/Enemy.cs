using UnityEngine;

public class Enemy : Fighter {
  #region Properties

  #region Attributes
  [SerializeField] int experienceValue = 1;
  [SerializeField] float triggerLenght = 1;
  [SerializeField] float chaseLenght = 5;
  [SerializeField] bool chasing;
  [SerializeField] bool isCollidingWithPlayer;
  [SerializeField] Transform playerTransform;
  [SerializeField] Vector3 startingPosition;
  [SerializeField] BoxCollider2D hitbox;
  [SerializeField] Collider2D[] hits = new Collider2D[10];
  [SerializeField] ContactFilter2D filter;
  [SerializeField] BoxCollider2D boxCollider;

  #endregion
  #region Getters & Setters

  #endregion
  #endregion
  #region Behaviours
  #region Life Cycle Hooks
  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake () {
    this.boxCollider = this.Movement.BoxCollider = GetComponent<BoxCollider2D> ();
    this.playerTransform = GameObject.Find ("Player").transform;
    startingPosition = this.transform.position;
    hitbox = transform.GetChild (0).GetComponent<BoxCollider2D> ();
  }
  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  public override void Update () {
    if (Vector3.Distance (playerTransform.position, startingPosition) < chaseLenght) {
      if (Vector3.Distance (playerTransform.position, startingPosition) < triggerLenght) {
        chasing = true;
      }
      if (chasing) {
        if (!isCollidingWithPlayer) {
          this.Movement.UpdateMotor ((playerTransform.position - transform.position).normalized);
        }
      } else {
        this.Movement.UpdateMotor (startingPosition - transform.position);
      }
    } else {
      this.Movement.UpdateMotor (startingPosition - transform.position);
      chasing = false;
    }
    isCollidingWithPlayer = false;
    boxCollider.OverlapCollider (this.filter, this.hits);
    for (int i = 0; i < hits.Length; i++) {
      if (this.hits[i] == null) {
        continue;
      }
      if (hits[i].tag.Equals ("Fighter") && hits[i].name.Equals ("Player")) {
        isCollidingWithPlayer = true;
      }
      hits[i] = null;
    }
    base.Update();
  }
  #endregion
  #region Procedures
  public override void Death () {
    Destroy (gameObject);
    HUDManager.instance.Show ("+ " + experienceValue + "xp", 250, Color.magenta, transform.position, Vector3.up * 40, 2f);
  }
  #endregion
  #region Functions

  #endregion
  #endregion
}