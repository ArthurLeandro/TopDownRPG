using UnityEngine;

[RequireComponent (typeof (SpriteRenderer)), RequireComponent(typeof(Animator))]
public class Weapon : Collidable {

  #region Properties
  #region Attributes
  [SerializeField] int damagePoint = 1;
  [SerializeField] float pushForce = 2f;
  [SerializeField] int weaponLevel = 0;
  [SerializeField] SpriteRenderer spriteRenderer;
  [SerializeField] float cooldown=0.5f;
  [SerializeField] float lastSwing;
  Animator anim;
  #endregion
  #region Getters & Setters
  public int DamagePoint {
    get {
      return this.damagePoint;
    }
    set {
      this.damagePoint = value;
    }
  }
  public float PushForce {
    get { return this.pushForce; }
    set {
      this.pushForce = value;
    }
  }
  public int WeaponLevel {
    get { return this.weaponLevel; }
    set {
      this.weaponLevel = value;
    }
  }
  public SpriteRenderer SpriteRendererInWeapon {
    get {
      return this.spriteRenderer;
    }
    set {
      this.spriteRenderer = value;
    }
  }
  public float Cooldown {
    get {
      return this.cooldown;
    }
    set {
      this.cooldown = value;
    }
  }
  public float LastSwing {
    get {
      return this.lastSwing;
    }
    set {
      this.lastSwing = value;
    }
  }
  #endregion
  #endregion

  #region Behaviour
    #region LifeCycle
    private void Awake () {
      this.spriteRenderer = GetComponent<SpriteRenderer> ();
      this.BoxCollider = GetComponent<BoxCollider2D>();
      anim = GetComponent<Animator>();
    }
    
    private void Update () {
      this.Colliding();
      if (Input.GetKeyDown (KeyCode.Space)) {
        if (Time.time - lastSwing > cooldown) {
          lastSwing = Time.time;
          Swing ();
        }
      }
    }
    #endregion
    #region Methods
    public void Swing () {
      anim.SetTrigger("Swing");
    }
    public override void OnCollide (Collider2D col) {
      if(col.name.Equals("Player")){
        return;
      }
      if(col.tag.Equals("Fighter") && col.name.Equals("Enemy")){
        Damage damage = new Damage {
          DamageAmount = damagePoint,
          Origin = transform.position,
          PushForce = pushForce
        };
        col.SendMessage ("ReceiveDamage", damage);
      }
    }
    #endregion
    #region Function

  #endregion
  #endregion

  

}