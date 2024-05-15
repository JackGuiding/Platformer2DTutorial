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
            // 只改变x, 保证 y 不被改变
            Vector2 oldVelocity = rb.velocity;
            oldVelocity.x = moveAxis.x * speed;
            rb.velocity = oldVelocity;
        }

        public void Falling(float fallingSpeed, float fallingSpeedMax, float fixdt) {
            // 只改变y, 保证 x 不被改变
            Vector2 oldVelocity = rb.velocity;
            oldVelocity.y -= fallingSpeed * fixdt;
            if (oldVelocity.y < -fallingSpeedMax) {
                oldVelocity.y = -fallingSpeedMax;
            }
            rb.velocity = oldVelocity;
        }

    }
}