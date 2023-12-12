namespace Juno.AI.Common
{
    public class Routes
    {
        public const string Base = "ai";
        public const string BaseHealth = "health";

        public const string Prompt = Base + "/prompt";
        public const string PromptSend = "send";
        public const string PromptTranslate = "translate";

        

        public const string Visual = Base + "/visual";
        public const string VisualGenerateImage = "generate-image";

        public const string Token = Base + "/token";
        public const string TokenEstimate = "estimate";

        public const string PromptMode = Base + "/prompt-mode";
        public const string PromptModeGetList = "getlist";
    }
}
