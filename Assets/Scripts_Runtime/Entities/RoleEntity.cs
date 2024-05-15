using System;
using UnityEngine;

namespace PlatformerTutorial {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] Transform body;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;

        [SerializeField] Animator animator;

        public int allowJumpTimes;

        // 所有继承自 MonoBehaviour 的类都禁止使用构造函数
        // public RoleEntity() { } 

        public void Ctor() {

        }

        public Vector2 Pos() {
            return body.position;
        }

        public void PosSet(Vector2 pos) {
            body.position = pos;
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

        public Vector2 Velocity() {
            return rb.velocity;
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

        public void Falling(float jumpAxis, float fallingSpeed, float fallingSpeedMax, float fixdt) {

            // TODO: 如果按住跳, 则下落速度减缓

            // 只改变y, 保证 x 不被改变
            Vector2 oldVelocity = rb.velocity;
            oldVelocity.y -= fallingSpeed * fixdt;
            if (oldVelocity.y < -fallingSpeedMax) {
                oldVelocity.y = -fallingSpeedMax;
            }
            rb.velocity = oldVelocity;

        }

        public void Jump(float jumpAxis, float jumpForce, float fixdt) {
            if (!AllowJump()) {
                return;
            }
            if (jumpAxis != 0) {
                Vector2 oldVelocity = rb.velocity;
                oldVelocity.y = jumpForce;
                rb.velocity = oldVelocity;
                allowJumpTimes -= 1;
            }
        }

        public void EnterGround() {
            allowJumpTimes = 2;
        }

        bool AllowJump() {
            return allowJumpTimes > 0;
        }

    }
}