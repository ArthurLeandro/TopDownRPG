using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RendererSystem {

  public Vector3 InvertSprite(float _value){
    if(_value>=0){
      return Vector3.one;
    }
    else{
      return new Vector3(-1,1,1);
    }
  }
}