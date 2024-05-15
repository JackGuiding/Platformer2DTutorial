using System;
using UnityEngine;

namespace PlatformerTutorial {

    public class InputManager {

        public Vector2 moveAxis;

        public InputManager() { }

        public void Tick(float dt) {
            // WSAD
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
        }

    }

}