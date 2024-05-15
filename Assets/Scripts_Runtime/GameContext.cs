namespace PlatformerTutorial {

    // 存储游戏的所有内存数据
    public class GameContext {

        // ==== 实体 ====
        public GameEntity gameEntity;
        public RoleRepository roleRepository;
        public MapRepository mapRepository;

        // ==== 模块 ====
        public AssetsManager assetsManager;
        public InputManager inputManager;

        // ==== 事件 ====
        public BusinessEvents events;

        public GameContext() {

            roleRepository = new RoleRepository();
            mapRepository = new MapRepository();

            assetsManager = new AssetsManager();
            inputManager = new InputManager();

            events = new BusinessEvents();

        }

    }

}