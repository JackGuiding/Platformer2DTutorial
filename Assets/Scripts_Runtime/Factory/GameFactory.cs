using System;
using UnityEngine;

namespace PlatformerTutorial {

    // 用于生成游戏的所有实体(Entity)
    public static class GameFactory {

        public static GameEntity Game_Create() {
            return new GameEntity();
        }

        public static RoleEntity Role_Create(GameContext ctx) {
            // new
            // GameObject.Instantiate

            // 1. 获取 prefab
            GameObject prefab = ctx.assetsManager.Entity_GetRolePrefab();
            GameObject go = GameObject.Instantiate(prefab);
            RoleEntity role = go.GetComponent<RoleEntity>();
            role.Ctor();

            return role;
        }

    }

}