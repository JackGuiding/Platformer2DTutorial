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
            ctx.gameEntity = GameFactory.Game_Create();

            // ==== Binding ====
            BindingEvents();

            // ==== Enter ====
            Business_Login.Enter(ctx);

        }

        void BindingEvents() {
            BusinessEvents businessEvents = ctx.events;
            businessEvents.Login_OnClickStartGameHandle = () => {
                // 点击开始游戏
                Business_Game.Enter(ctx);
            };
        }

        void OnGUI() {

            var game = ctx.gameEntity;
            GameFSMStatus status = game.status;
            if (status == GameFSMStatus.Login) {
                Business_Login.ProcessGUI(ctx);
            } else if (status == GameFSMStatus.Game) {
                // Business_Game.ProcessGUI(ctx);
            }

        }

        void Update() {

            float dt = Time.deltaTime;
            var game = ctx.gameEntity;
            GameFSMStatus status = game.status;
            if (status == GameFSMStatus.Login) {
                Business_Login.Tick(ctx, dt);
            } else if (status == GameFSMStatus.Game) {
                Business_Game.Tick(ctx, dt);
            }

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
