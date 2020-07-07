using System.Collections.Generic;

namespace TopDown.Core
{
    public class Game
    {
        private readonly List<IEntity> _entites = new List<IEntity>();
        private readonly IInput _input;

        private bool _hasFired = false;
        private MouseDot _mouseEntity;
        private KeyboardDot _keyboardEntity;
        public Game(IInput input)
        {
            _input = input;
            _entites.Add(_mouseEntity = new MouseDot(_input));
            _entites.Add(_keyboardEntity = new KeyboardDot(_input));
        }

        public void Update(int timestep)
        {
            for (int i = 0; i < _entites.Count; i++)
                _entites[i].Update(timestep);


            var keyboardState = _input.GetKeyboardState();
            if (!_hasFired && keyboardState.HasFlag(KeyboardKey.Space))
            {
                _hasFired = true;
                _entites.Add(new MovingEntity(_keyboardEntity.Pos, _mouseEntity.Pos));
            }
            else if (_hasFired && !keyboardState.HasFlag(KeyboardKey.Space))
            {
                _hasFired = false;
            }
        }

        public void Render(ICanvas canvas)
        {
            for (int i = 0; i < _entites.Count; i++)
                _entites[i].Draw(canvas);
        }
    }
}
