using UnityEngine;

namespace PlatformerTutorial {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx) {

            // 生成
            RoleEntity role = GameFactory.Role_Create(ctx);

            // 存储
            ctx.roleRepository.Add(role);

            return role;

        }

        public static void Unspawn(GameContext ctx, int id) {
            // 移除
            ctx.roleRepository.Remove(id);
        }

        public static void MoveByOwnerInput(GameContext ctx, RoleEntity role, float fixdt) {
            var input = ctx.inputManager;
            Move(ctx, role, input.moveAxis, fixdt);
        }

        public static void Move(GameContext ctx, RoleEntity role, Vector2 moveAxis, float fixdt) {
            role.Move(moveAxis, 5.5f, fixdt);
        }

        public static void JumpByOwnerInput(GameContext ctx, RoleEntity role, float fixdt) {
            var input = ctx.inputManager;
            Jump(ctx, role, input.jumpAxis, fixdt);
        }

        public static void Jump(GameContext ctx, RoleEntity role, float jumpAxis, float fixdt) {
            role.Jump(jumpAxis, 10f, fixdt);
        }

        public static void Falling(GameContext ctx, RoleEntity role, float fixdt) {
            role.Falling(0, 22.5f, 40f, fixdt);
        }

    }

}