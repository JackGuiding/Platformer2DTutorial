namespace PlatformerTutorial {

    // 每个状态对应一个 Business
    public enum GameFSMStatus {
        None,
        Login,
        Game,
        Pause,
        GameOver,
        GameWin,
        PlayingCG,
    }

}