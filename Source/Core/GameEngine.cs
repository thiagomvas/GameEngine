using Basalt.Libraries;
using Basalt.Source.Components;
using Basalt.Source.Core.Graphics;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.UI;
using Basalt.Source.Entities;
using Raylib_cs;
using System.Numerics;

namespace Basalt.Source.Core
{
    public static partial class Engine
    {
        //public static Camera Camera = new(Camera.RenderType.Camera3D);
        public static Window window;
        //public static List<Light> lights = new();
        public static Scene CurrentScene;

        public static event Action OnUpdate;

        public static void CallUpdate() => OnUpdate?.Invoke();
        public static void Setup()
        {
            window = new GameWindow3D();
            CurrentScene = Default3DScene();
            window.Start();
            //window.Init(1000, 1000, CurrentScene.Cameras[0]);
        }

        public static Scene Default3DScene()
        {
            List<GameObject> objects = new();
            List<Light> lights = new();
            GameObject obj = new();
            obj.AddComponent<Rigidbody>();
            Player player = new(obj);
            objects.Add(obj);

            GameObject lightsource = new();
            lightsource.Transform.Position = new(0, 0, 50);
            SphereRenderer rend = lightsource.AddComponent<SphereRenderer>();
            rend.Color = Color.GREEN;
            rend.Radius = 2;

            var light = lightsource.AddComponent<LightEmitter>();
            light.Color = Color.GREEN;
            light.index = 0;
            objects.Add(lightsource);
            lights.Add(light.Source);

            GameObject lightsource2 = new();
            lightsource2.Transform.Position = new(50, 0, 0);
            SphereRenderer rend2 = lightsource2.AddComponent<SphereRenderer>();
            rend2.Color = Color.RED;
            rend2.Radius = 2;
            var light2 = lightsource2.AddComponent<LightEmitter>();
            light2.Color = Color.RED;
            light2.index = 1;
            lights.Add(light2.Source);
            objects.Add(lightsource2);

            Panel panel = new(new Vector2(-200, 00));
            panel.SetPivot(UIElement.PivotPoint.Right);
            panel.Width = 20;
            panel.Height = 20;
            panel.Color = Color.RED;

            Label label = new(new Vector2(-200, 200));
            label.SetPivot(UIElement.PivotPoint.Right);


            Scene scene = new(objects, new() { panel, label }, lights);
            scene.Cameras.Add(new(Camera.RenderType.Camera3D));

            return scene;
        }

        //private static void Example3DSetup()
        //{
        //    int cubeSize = 5;
        //    window = new GraphicsWindow3D();
        //    Camera.Camera3D.Target = new(50, 0, 0);
        //    GameObject obj = new();
        //    obj.AddComponent<Rigidbody>();
        //    Player player = new(obj);
        //    Player = player;
        //    Instantiate(obj);

        //    GameObject lightsource = new();
        //    lightsource.Transform.Position = new(0, 0, 50);
        //    var light = lightsource.AddComponent<LightEmitter>();
        //    light.Color = Color.BLUE;
        //    Instantiate(lightsource);

        //    GameObject lightsource2 = new();
        //    lightsource2.Transform.Position = new(50, 0, 0);
        //    var light2 = lightsource2.AddComponent<LightEmitter>();
        //    light2.Color = Color.RED;
        //    Instantiate(lightsource);


        //    window.Init(1000, 1000, Camera);


        //}

        //private static void Example2DSetup()
        //{
        //    window = new GraphicsWindow2D();
        //    GameObject obj = new GameObject(new Vector3(400, 400, 0));
        //    Camera.Transform.Position = obj.Transform.Position;
        //    var rend = obj.AddComponent<CircleRenderer>();
        //    obj.AddComponent<CircleCollider>();
        //    obj.AddComponent<Rigidbody>();
        //    obj.AddChildren(Camera);
        //    //Instantiate(obj);
        //    Player player = new Player(obj);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        GameObject obstacle = new GameObject(new Vector3(100 + i * 50, 0, 0));
        //        obstacle.AddComponent<SpriteRenderer>().texturePath = Assets.GetAssetPath("circleheadtest.png");
        //        var col = obstacle.AddComponent<CircleCollider>();
        //        col.Radius = 25;
        //        Instantiate(obstacle);
        //    }

        //    Button button = new Button(UI.ScreenBottom + new Vector2(0, -150), 200, 50);
        //    button.SetPivot(UIElement.PivotPoint.Bottom);

        //    Label label = new(UI.ScreenBottom + new Vector2(0, -50));
        //    label.SetPivot(UIElement.PivotPoint.Bottom);
        //    label.Text = "PROTOTYPE ENGINE TEST";
        //    label.FontSize = 24;
        //    label.TextColor = Color.GREEN;
        //    UI.Instantiate(button);
        //    UI.Instantiate(label);




        //    window.Init(800, 800, Camera);
        //}
    }
}
