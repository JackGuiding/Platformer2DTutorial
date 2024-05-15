namespace PlatformerTutorial {

    // 用于生成游戏的所有实体(Entity)
    public static class GameFactory {

        public static GameEntity Game_Create() {
            return new GameEntity();
        }

        public static RoleEntity Role_Create() {
            // new
            // GameObject.Instantiate
            return null;
        }

    }

}