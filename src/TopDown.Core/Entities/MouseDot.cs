using System.Numerics;
using TopDown.Core.Engine;

namespace TopDown.Core
{
    public class MouseDot : PositionEntity
    {
        private readonly IInput _input;
        public MouseDot(IInput input)
        {
            _input = input;
            this.Position = new Vector2(100, 100);
        }

        public override void Draw(ICanvas canvas)
        {
            GameColor color = _input.GetInputState().HasFlag(InputButton.LeftMouse) ?
                                    GameColor.Red :
                                    GameColor.Blue;
            canvas.DrawCircle(this.Position, 10f, color);
        }

        public override void Update(float timestep) => 
            this.Position = _input.GetMousePosition();
    }
}
