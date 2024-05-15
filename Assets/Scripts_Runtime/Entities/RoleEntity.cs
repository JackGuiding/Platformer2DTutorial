using System;
using UnityEngine;

namespace PlatformerTutorial {

    public class RoleEntity : MonoBehaviour {

        public int id;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;

        [SerializeField] Animator animator;

        // 所有继承自 MonoBehaviour 的类都禁止使用构造函数
        // public RoleEntity() { } 

        public void Ctor() {

        }

    }
}