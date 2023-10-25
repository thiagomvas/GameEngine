using Raylib_cs;
using static Raylib_cs.Raylib;
namespace GameEngineProject.Source.Core.Utils
{
    public static class Configuration
    {
        public static event Action OnBeforeInit;
        public static event Action OnPostInit;
        public static event Action OnDeinitialize;
        public static void PreInitConfiguration()
        {
            //SetConfigFlags(ConfigFlags.FLAG_FULLSCREEN_MODE);
            SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);

            OnBeforeInit?.Invoke();
        }

        public unsafe static void PostInitConfiguration() 
        {
            SetTargetFPS(120);
            InitAudioDevice();
            HideCursor();
            DisableCursor();


            Assets.LightingShader = LoadShader("C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\Resources\\Shaders\\lighting.vs", "C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\Resources\\Shaders\\lighting.fs");
            // Get some required shader loactions
            Assets.LightingShader.locs[(int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(Assets.LightingShader, "viewPos");

            // ambient light level
            int ambientLoc = GetShaderLocation(Assets.LightingShader, "ambient");
            float[] ambient = new[] { 0.1f, 0.1f, 0.1f, 1.0f };
            SetShaderValue(Assets.LightingShader, ambientLoc, ambient, ShaderUniformDataType.SHADER_UNIFORM_VEC4);

            OnPostInit?.Invoke();
        }

        public static void Deinitialize()
        {
            OnDeinitialize?.Invoke();
            UnloadShader(Assets.LightingShader);
            CloseAudioDevice();
            CloseWindow();
        }
    }
}
