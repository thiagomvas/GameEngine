using GameEngineProject.Source.Core.Utils;
using System.Numerics;

namespace GameEngineProject.Source.Components
{
    public class Projectile : Component
    {
        public Vector3 Velocity;

        public override void Update()
        {
            base.Update();
            parent.Transform.Move(Velocity * Time.DeltaTime * 25);
        }
    }
}
