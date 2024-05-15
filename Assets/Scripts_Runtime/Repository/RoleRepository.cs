using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTutorial {

    // 存储 Entity, RoleRepository 就存 RoleEntity
    // 至少有: Add, TryGet, Remove, Foreach
    public class RoleRepository {

        Dictionary<int, RoleEntity> all;

        public RoleRepository() {
            all = new Dictionary<int, RoleEntity>();
        }

        public void Add(RoleEntity role) {
            all.Add(role.id, role); // null.xxx 报空引用异常
        }

        public bool TryGet(int id, out RoleEntity role) {
            return all.TryGetValue(id, out role);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

        public void Foreach(Action<RoleEntity> action) {
            foreach (var role in all.Values) {
                action(role);
            }
        }

    }
}