using System;
using UnityEngine;

namespace PlatformerTutorial {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;

        [SerializeField] Animator animator;

        // 所有继承自 MonoBehaviour 的类都禁止使用构造函数
        // public RoleEntity() { } 

        public void Ctor() {

        }

        public void Move(Vector2 moveAxis, float speed, float fixdt) {
            Vector2 oldVelocity = rb.velocity;
            oldVelocity.x = moveAxis.x * speed;
            // 保证 y 不被改变
            rb.velocity = oldVelocity;
        }

    }
}