using System;

namespace PlatformerTutorial {

    public class BusinessEvents {

        public Action Login_OnClickStartGameHandle;
        public void Login_OnClickStartGame() {
            Login_OnClickStartGameHandle.Invoke();
        }

        public BusinessEvents() { }

    }

}