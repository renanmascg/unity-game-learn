using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  public float speed;
  public float jumpForce;
  public GameObject arrow;
  public Transform firePoint;

  private Rigidbody2D rig;
  private Animator anim;

  private bool isJumping;
  private bool doubleJump;
  private bool isFire;

  private float movement;

  void Start() {
    rig = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  void Update() {
    Jump();
    BowFire();
  }

  private void FixedUpdate() {
    Move();
  }

  void Move() {
    movement = Input.GetAxis("Horizontal");
    
    // adiciona velocidade ao corpo do personagem no eixo X e Y
    rig.velocity = new Vector2(movement * speed, rig.velocity.y);

    // animação na direção correta
    if (movement > 0) {
      if (!isJumping) {
        anim.SetInteger("transition", 1);
      }
      transform.eulerAngles = new Vector3(0,0,0);
    } 

    if (movement < 0) {
      if (!isJumping) {
        anim.SetInteger("transition", 1);
      }
      transform.eulerAngles = new Vector3(0,180,0);
    }

    if (movement == 0 && !isJumping && !isFire) {
      anim.SetInteger("transition", 0);
    }
  }

  void Jump() {
    if (Input.GetButtonDown("Jump")) {
      if (!isJumping) {
        anim.SetInteger("transition", 2);
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        doubleJump = true;
      } else {
        if (doubleJump) {
          anim.SetInteger("transition", 2);
          rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
          doubleJump = false;
        }
      }
    }
  }

  void BowFire() {
    StartCoroutine("Fire");
  }

  IEnumerator Fire() {
    if(Input.GetKeyDown(KeyCode.E)) {
      isFire = true;
      anim.SetInteger("transition", 3);
      GameObject Arrow = Instantiate(arrow, firePoint.position, firePoint.rotation);

      if (transform.rotation.y == 0) {
        Arrow.GetComponent<Arrow>().isRight = true;
      }

      if (transform.rotation.y == 180) {
        Arrow.GetComponent<Arrow>().isRight = false;
      }

      yield return new WaitForSeconds(0.2f);
      isFire = false;
      anim.SetInteger("transition", 0);
    }
  }
  

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.layer == 6) {
      isJumping = false;
    }
  }
}
