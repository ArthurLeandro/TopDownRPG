using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D)),RequireComponent(typeof(SpriteRenderer))]
public class Chest : Collidable {

    #region Properties
    [SerializeField] Sprite emptyChest;

    bool collected;
    #endregion

    #region Life Cycles
    
    
    void Update () {
        this.Colliding();
    }
    #endregion

    #region Methods & Functions
    public override void OnCollide(Collider2D col){
      if(col.name.Equals("Player")){
        this.Action();
      }
    }
    public override void Action(){
        if(!collected){
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            HUDManager.instance.Show("+5 pesos", + 300,Color.yellow,transform.position,Vector3.up*50,1.0f);
        }
    }
    #endregion
}