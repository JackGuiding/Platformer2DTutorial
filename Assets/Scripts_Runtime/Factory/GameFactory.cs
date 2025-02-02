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

            role.allowJumpTimes = 2;

            return role;
        }

        public static MapEntity Map_Create(GameContext ctx, int stageID) {

            // 1. 获取 Entity prefab
            GameObject prefab = ctx.assetsManager.Entity_GetMapPrefab();
            GameObject go = GameObject.Instantiate(prefab);
            MapEntity map = go.GetComponent<MapEntity>();
            map.Ctor();
            map.stageID = stageID;

            // 2. 获取 MapGridElement prefab
            GameObject gridPrefab = ctx.assetsManager.MapGrid_Get(stageID);
            MapGridElement grid = GameObject.Instantiate(gridPrefab).GetComponent<MapGridElement>();

            map.Inject(grid);

            return map;

        }

    }

}