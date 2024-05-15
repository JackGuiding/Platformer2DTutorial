using UnityEngine;

namespace PlatformerTutorial {

    public static class Business_Game {

        public static void NewGame(GameContext ctx) {

            // 改变程序状态机
            ctx.gameEntity.status = GameFSMStatus.Game;

            // 初始数据

            // 生成角色
            RoleEntity role = RoleDomain.Spawn(ctx);
            ctx.gameEntity.roleOwnerID = role.id; // 记录主角

            // 生成地形

        }

        public static void LoadGame(GameContext ctx) {

            // 现存数据: 从文件读取存档 或 从网络

            // 生成角色

            // 生成地形

        }

        public static void Tick(GameContext ctx, float dt) {

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