using System;
using UnityEngine;

namespace PlatformerTutorial {

    public class InputManager {

        public Vector2 moveAxis;
        public float jumpAxis; // 为什么不用Button, 假如用手柄的摇杆的↑作为跳(0~1)

        public InputManager() { }

        public void Tick(float dt) {

            // WSAD: Move
            Vector2 axis = Vector2.zero;
            if (Input.GetKey(KeyCode.W)) {
                axis.y = 1;
            } else if (Input.GetKey(KeyCode.S)) {
                axis.y = -1;
            }

            if (Input.GetKey(KeyCode.A)) {
                axis.x = -1;
            } else if (Input.GetKey(KeyCode.D)) {
                axis.x = 1;
            }
            this.moveAxis = axis;

            // Space: Jump
            if (Input.GetKeyDown(KeyCode.Space)) {
                this.jumpAxis = 1;
            } else {
                this.jumpAxis = 0;
            }

        }

    }

}