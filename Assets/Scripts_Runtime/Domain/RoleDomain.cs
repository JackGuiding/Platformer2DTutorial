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
            role.Move(input.moveAxis, 5.5f, fixdt);
        }

        public static void Falling(GameContext ctx, RoleEntity role, float fixdt) {
            role.Falling(22.5f, 40f, fixdt);
        }

    }

}