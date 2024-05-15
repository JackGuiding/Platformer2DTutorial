using UnityEngine;

namespace PlatformerTutorial {

    public static class Business_Game {

        public static void Enter(GameContext ctx) {
            ctx.gameEntity.status = GameFSMStatus.Game;
        }

        public static void Tick(GameContext ctx, float dt) {

            Debug.Log("Game Tick");

            // ==== Pre ====
            // 用于处理输入: 按键/UI输入
            PreUpdate(ctx, dt);

            // ==== Fix ====
            // 核心逻辑
            ref float restFixTime = ref ctx.gameEntity.restFixTime;
            restFixTime += dt;
            const float FIX_INTERVAL = 0.02f;
            if (restFixTime <= FIX_INTERVAL) {
                LogicFixUpdate(ctx, restFixTime);
                restFixTime = 0;
            } else {
                while (restFixTime >= FIX_INTERVAL) {
                    LogicFixUpdate(ctx, FIX_INTERVAL);
                    restFixTime -= FIX_INTERVAL;
                }
            }

            // ==== Late ====
            // 用于处理渲染/UI显示
            LateUpdate(ctx, dt);

        }

        static void PreUpdate(GameContext ctx, float dt) {

        }

        static void LogicFixUpdate(GameContext ctx, float fixdt) {

        }

        static void LateUpdate(GameContext ctx, float dt) {

        }

    }
}