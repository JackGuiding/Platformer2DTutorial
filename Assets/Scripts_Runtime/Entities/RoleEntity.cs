using System;
using UnityEngine;

namespace PlatformerTutorial {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] Transform body;

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

            // 面向
            Face(moveAxis.x);

            // 播放动画
            Anim_Move(moveAxis.x);

        }

        void Face(float xDir) {
            if (xDir > 0) {
                body.localScale = new Vector3(1, 1, 1);
            } else if (xDir < 0) {
                body.localScale = new Vector3(-1, 1, 1);
            }
        }

        void Anim_Move(float xDir) {
            if (xDir != 0) {
                // 播移动动画
                animator.Play("Run"); // 传入的是 State 名字而非 Clip 名字
            } else {
                // 播放静止动画
                animator.Play("Idle");
            }
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