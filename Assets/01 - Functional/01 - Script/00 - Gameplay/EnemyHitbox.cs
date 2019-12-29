using UnityEngine;

public class EnemyHitbox : Collidable{
  [SerializeField] int damage=1;
  [SerializeField] float pushForce=8f;

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update()
  {
    this.Colliding();
  }
  public override void OnCollide(Collider2D col){
    if(col.tag.Equals("Fighter")&&col.name.Equals("Player")){
      Damage damage = new Damage {
          DamageAmount = this.damage,
          Origin = this.transform.position,
          PushForce = this.pushForce
        };
        col.SendMessage ("ReceiveDamage", damage);
    }
  }

}