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

    }

}