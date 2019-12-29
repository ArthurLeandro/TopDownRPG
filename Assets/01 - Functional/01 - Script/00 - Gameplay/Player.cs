using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter {

  public override void Update () {
    this.Movement.MovementInDelta ();
    base.Update ();
  }
  public override void Death () {
    HUDManager.instance.Show ("GAME OVER", 400, Color.white, transform.position, Vector3.up * 20, 4f);
  }
}