using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace PlatformerTutorial {

    public class AssetsManager {

        Dictionary<string, GameObject> entities;
        AsyncOperationHandle entitiesHandle;

        Dictionary<int, MapGridElement> mapGrids;
        AsyncOperationHandle mapGridsHandle;

        public AssetsManager() {
            entities = new Dictionary<string, GameObject>();
            mapGrids = new Dictionary<int, MapGridElement>();
        }

        public void LoadAll() {
            {
                // "Entity" 是 Addressables 里的 Label
                var op = Addressables.LoadAssetsAsync<GameObject>("Entity", null);
                var list = op.WaitForCompletion();
                foreach (var go in list) {
                    entities.Add(go.name, go);
                }
                entitiesHandle = op;
            }
            {
                var op = Addressables.LoadAssetsAsync<GameObject>("MapGrid", null);
                var list = op.WaitForCompletion();
                foreach (var go in list) {
                    MapGridElement mapGrid = go.GetComponent<MapGridElement>();
                    mapGrids.Add(mapGrid.stageID, mapGrid);
                }
                mapGridsHandle = op;
            }
        }

        public void UnloadAll() {
            if (entitiesHandle.IsValid()) {
                Addressables.Release(entitiesHandle);
            }
            if (mapGridsHandle.IsValid()) {
                Addressables.Release(mapGridsHandle);
            }
        }

        public GameObject Entity_GetRolePrefab() {
            entities.TryGetValue("RoleEntity", out GameObject entity);
            return entity;
        }

        public GameObject Entity_GetMapPrefab() {
            entities.TryGetValue("MapEntity", out GameObject entity);
            return entity;
        }

        public GameObject MapGrid_Get(int stageID) {
            MapGridElement mapGrid;
            if (mapGrids.TryGetValue(stageID, out mapGrid)) {
                return mapGrid.gameObject;
            } else {
                return null;
            }
        }

    }

}