namespace PlatformerTutorial {

    // 用于整个游戏的数据类型
    // 跨 Business
    public class GameEntity {

        public GameFSMStatus status;
        public float restFixTime; // 用于模拟 FixedUpdate

        public GameEntity() {
            restFixTime = 0;
        }

    }

}