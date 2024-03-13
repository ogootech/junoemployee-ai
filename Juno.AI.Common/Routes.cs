namespace Juno.AI.Common
{
    public class Routes
    {
        public const string Base = "ai";
        public const string BaseTest = "ai-test";
        public const string BaseProd = "ai-prod";
        public const string BaseHealth = Base + "health";

        public const string Prompt = Base + "/prompt";
        public const string PromptTest = BaseTest + "/prompt";
        public const string PromptProd = BaseProd + "/prompt";
        public const string PromptCreate = "create";
        public const string PromptCreateFrom = "create-from";
        public const string PromptTranslate = "translate";
        public const string PromptMakeLonger = "make-longer";
        public const string PromptMakeShorter = "make-shorter";
        public const string PromptGetOptionList = "get-option-list";


        public const string PromptHistory = Base + "/prompt-history";
        public const string PromptHistoryTest = BaseTest + "/prompt-history";
        public const string PromptHistoryProd = BaseProd + "/prompt-history";
        public const string PromptHistoryGetList = "getlist";



        public const string Visual = Base + "/visual";
        public const string VisualTest = BaseTest + "/visual";
        public const string VisualProd = BaseProd + "/visual";
        public const string VisualGenerateImage = "generate-image";

        public const string Token = Base + "/token";
        public const string TokenTest = BaseTest + "/token";
        public const string TokenProd = BaseProd + "/token";
        public const string TokenEstimate = "estimate";

        public const string PromptMode = Base + "/prompt-mode";
        public const string PromptModeTest = BaseTest + "/prompt-mode";
        public const string PromptModeProd = BaseProd + "/prompt-mode";
        public const string PromptModeGetList = "getlist";
    }
}
