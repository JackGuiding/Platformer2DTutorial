using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial {

    public class Main : MonoBehaviour {

        bool isTearDown;

        void Awake() {
            isTearDown = false;

            Debug.Log("He");
        }

        void Update() {

        }

        void OnDestroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;
        }
    }
}
