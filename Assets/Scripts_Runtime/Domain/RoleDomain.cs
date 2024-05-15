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

        public static void GroundCheck(GameContext ctx, RoleEntity role) {

            // 只有下落时/或者在地面上时才检测
            if (role.Velocity().y > 0) {
                return;
            }

            Vector2 size = new Vector2(0.98f, 0.1f);
            float angle = 0;
            Vector2 dir = new Vector2(0, -1);
            RaycastHit2D[] hits = Physics2D.BoxCastAll(role.Pos(), size, angle, dir, 0.5f); // 向下发射一个盒状碰撞体
            if (hits.Length == 0) {
                return;
            }

            bool isCollideGround = false;
            for (int i = 0; i < hits.Length; i += 1) {
                RaycastHit2D hit = hits[i];
                if (hit.collider.gameObject.CompareTag("Ground")) {
                    isCollideGround = true;
                    break;
                }
            }

            if (isCollideGround) {
                role.EnterGround();
            }

            // Physics2D.OverlapBoxAll(); // 无方向的, 只在一个位置检测碰撞

        }

    }

}