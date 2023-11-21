using System;
using System.Collections.Generic;
using System.Text;

namespace MGRpgLibrary.ConversationComponents
{
    public enum ActionType
    {
        Talk,
        End,
        Change,
        Quest,
        Buy,
        Sell
    }
    public class SceneAction
    {
        public ActionType Action;
        public string Parameter;
    }
    public class SceneOption
    {
        private string optionText;
        private string optionScene;
        private SceneAction optionAction;
        private SceneOption()
        {

        }
        public SceneOption(string text,string scene,SceneAction action)
        {
            this.optionText = text;
            this.optionScene = scene;
            this.optionAction = action;
        }
        public string OptionText
        {
            get { return optionText; }
            set { optionText = value; }
        }
        public string OptionScene
        {
            get { return optionScene; }
            set { optionScene = value; }
        }
        public SceneAction OptionAction
        {
            get { return optionAction; }
            set { optionAction = value; }
        }
    }
}
