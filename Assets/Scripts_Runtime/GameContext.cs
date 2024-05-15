namespace PlatformerTutorial {

    // 存储游戏的所有内存数据
    public class GameContext {

        public GameEntity gameEntity;
        public RoleRepository roleRepository;

        public BusinessEvents events;

        public GameContext() {

            roleRepository = new RoleRepository();

            events = new BusinessEvents();

        }

    }

}