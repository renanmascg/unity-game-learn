using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuy : MonoBehaviour
{ 
  public float speed;
  public float walkTime;
  public int health;
  
  private float timer;
  private bool walkRight = true;

  private Rigidbody2D rig;
  private Animator anim;

  void Start() {
    rig = GetComponent<Rigidbody2D>();  
    anim = GetComponent<Animator>();  
  }

  void FixedUpdate() {
    timer += Time.deltaTime;
    
    if(timer >= walkTime) {
      walkRight = !walkRight;
      timer = 0f;
    }

    if(walkRight) {
      transform.eulerAngles = new Vector2(0,180);
      rig.velocity = Vector2.right * speed;
    } else {
      transform.eulerAngles = new Vector2(0,0);
      rig.velocity = Vector2.left * speed;
    }
  }

  public void Damage(int dmg) {
    health -= dmg;
    anim.SetTrigger("hit");

    if(health <= 0) {
      Destroy(gameObject);
    }
  }
}
