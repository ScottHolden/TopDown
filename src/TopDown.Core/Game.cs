using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TopDown.Core
{
    public class Game
    {
        private readonly List<IEntity> _entites = new List<IEntity>();
        private readonly IInput _input;

        private bool _hasFired = false;
        private readonly MouseDot _mouseEntity;
        private readonly KeyboardDot _keyboardEntity;
        public Game(IInput input)
        {
            _input = input;
            _entites.Add(_mouseEntity = new MouseDot(_input));
            _entites.Add(_keyboardEntity = new KeyboardDot(_input));
            _entites.Add(new BlockEntity(new Vector2(400, 80), new Vector2(60, 60)));
            _entites.Add(new BlockEntity(new Vector2(80, 400), new Vector2(60, 60)));
            _entites.Add(new RougeDot(new Vector2(600, 600)));
            _entites.Add(new RougeDot(new Vector2(800, 800)));
        }

        public void Update(float timestep)
        {
            var staticPhysicsEntities = _entites.OfType<IStaticPhysics>().ToList();
            for (int i = _entites.Count - 1; i >= 0; i--)
            {
                _entites[i].Update(timestep);
                if (_entites[i] is IDynamicPhysics ep)
                    ep.CheckCollisions(staticPhysicsEntities);
                if (!_entites[i].IsAlive)
                {
                    _entites.RemoveAt(i);
                }
            }

            var keyboardState = _input.GetInputState();
            if (!_hasFired && keyboardState.HasFlag(InputButton.LeftMouse))
            {
                _hasFired = true;
                _entites.Add(new MovingEntity(_keyboardEntity.Position, _mouseEntity.Position));
            }
            else if (_hasFired && !keyboardState.HasFlag(InputButton.LeftMouse))
            {
                _hasFired = false;
            }
        }

        public void Render(ICanvas canvas)
        {
            for (int i = 0; i < _entites.Count; i++)
                _entites[i].Draw(canvas);

            if(!_entites.OfType<RougeDot>().Any())
            {
                canvas.DrawText(new Vector2(600, 500), "You Win!", 60, GameColor.Green);
            }
        }
    }
}
