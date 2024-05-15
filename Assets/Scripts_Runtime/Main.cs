using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial {

    public class Main : MonoBehaviour {

        GameContext ctx;

        bool isTearDown;

        void Awake() {

            isTearDown = false;

            // ==== Instantiate ====
            ctx = new GameContext();

            // ==== Binding ====
            BindingEvents();

            Debug.Log("He");
        }

        void BindingEvents() {
            BusinessEvents businessEvents = ctx.events;
            businessEvents.Login_OnClickStartGameHandle = () => {
                Debug.Log("Start Game");
            };
        }

        void OnGUI() {

            Business_Login.ProcessGUI(ctx);

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
