namespace PlatformerTutorial {

    // 存储游戏的所有内存数据
    public class GameContext {

        // ==== 实体 ====
        public GameEntity gameEntity;
        public RoleRepository roleRepository;

        // ==== 模块 ====
        public AssetsManager assetsManager;

        // ==== 事件 ====
        public BusinessEvents events;

        public GameContext() {

            roleRepository = new RoleRepository();

            assetsManager = new AssetsManager();

            events = new BusinessEvents();

        }

    }

}