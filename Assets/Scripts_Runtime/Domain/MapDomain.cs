using System;
using UnityEngine;

namespace PlatformerTutorial {

    public static class MapDomain  {

        public static MapEntity Spawn(GameContext ctx, int stageID) {
            MapEntity map = GameFactory.Map_Create(ctx, stageID);
            ctx.mapRepository.Add(map);
            return map;
        }

    }

}