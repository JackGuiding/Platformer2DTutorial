using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace PlatformerTutorial {

    public class AssetsManager {

        Dictionary<string, GameObject> entities;
        AsyncOperationHandle entitiesHandle;

        public AssetsManager() {
            entities = new Dictionary<string, GameObject>();
        }

        public void LoadAll() {
            {
                // "Entity" 是 Addressables 里的 Label
                var op = Addressables.LoadAssetsAsync<GameObject>("Entity", null);
                var list = op.WaitForCompletion();
                foreach (var entity in list) {
                    entities.Add(entity.name, entity);
                }
                entitiesHandle = op;
            }
        }

        public void UnloadAll() {
            if (entitiesHandle.IsValid()) {
                Addressables.Release(entitiesHandle);
            }
        }

        bool Entity_TryGet(string name, out GameObject entity) {
            return entities.TryGetValue(name, out entity);
        }

        public GameObject Entity_GetRolePrefab() {
            GameObject entity;
            if (entities.TryGetValue("RoleEntity", out entity)) {
                return entity;
            } else {
                return null;
            }
        }

    }

}