using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MovementSystem {
  #region Properties
   
    #region Attributes
    [SerializeField]  float ySpeed = 0.75f;
    [SerializeField] float xSpeed = 1f;
    [SerializeField] Vector3 pushDirection;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Vector3 moveDelta;
    #endregion
    #region Getters & Setters
    public float XSpeed{
    get{
      return this.xSpeed;
    }
    set{
      this.xSpeed = value;
    }
  }
  public float YSpeed{
    get{
      return this.ySpeed;
    }
    set{
      this.ySpeed = value;
    }
  }
    public BoxCollider2D BoxCollider{
    get{
      return this.boxCollider;
    }
    set{
      this.boxCollider = value;
    }
  }
  public Vector3 MoveDelta{
    get{
      return this.moveDelta;
    }
    set{
      this.moveDelta = value;
    }
  }
    #endregion
  #endregion
  #region Behaviours
    
    #region Procedures
    public void MovementInDelta(){
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");
    this.moveDelta = new Vector3(x*xSpeed,y*ySpeed,0);    
  }
  public virtual void UpdateMotor(Vector3 _input){
    this.moveDelta = new Vector3(_input.x*xSpeed,_input.y*ySpeed,0);
  }
  public void OcurredPush(Vector3 _push, float _recovery){
    this.moveDelta+=_push;
    this.moveDelta+=Vector3.Lerp(_push, Vector3.zero, _recovery);
  }
    #endregion
    #region Functions
   
    #endregion
  #endregion

  
  
  
  
  
}