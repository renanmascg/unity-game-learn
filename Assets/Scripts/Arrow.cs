using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

  private Rigidbody2D _rig;
  public float speed;
  public bool isRight;
  public int damage;

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

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Enemy") {
      Debug.Log("Acertou algo");
      other.GetComponent<EnemyGuy>().Damage(damage);
      Destroy(gameObject);
    }
  }
}
