using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

  private Rigidbody2D _rig;
  public float speed;
  public bool isRight;

  void Start()
  {
    _rig = GetComponent<Rigidbody2D>();
    Destroy(gameObject, 2f);
  }
  
  private void FixedUpdate() {
    if (isRight) {
      _rig.velocity = Vector2.right * speed;
    } else {
      _rig.velocity = Vector2.left * speed;
    }
  }
}
