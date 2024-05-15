using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial {

    public class MapRepository {

        Dictionary<int, MapEntity> all;

        public MapRepository() {
            all = new Dictionary<int, MapEntity>();
        }

        public void Add(MapEntity map) {
            all.Add(map.stageID, map);
        }

        public MapEntity Get(int stageID) {
            MapEntity map;
            if (all.TryGetValue(stageID, out map)) {
                return map;
            } else {
                return null;
            }
        }

        public void Remove(int stageID) {
            all.Remove(stageID);
        }

        public void Foreach(Action<MapEntity> action) {
            foreach (var map in all.Values) {
                action.Invoke(map);
            }
        }

        public void Clear() {
            all.Clear();
        }

    }
}