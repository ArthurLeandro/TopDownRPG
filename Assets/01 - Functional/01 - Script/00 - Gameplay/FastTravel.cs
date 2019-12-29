using UnityEngine;
using UnityEngine.SceneManagement;
public class FastTravel : Collidable {
  [SerializeField]  string[] scenes;
  public override void Action(){
    SceneManager.LoadScene(GetScene());
  }
  public string GetScene(){
    return this.scenes[0];
    
  }
}