using System;

namespace MVCExample
{
    public enum GameStates
    {
        gameInMenu,
        gameStart,
        gameOver,
        count
    }

    public sealed class GameStateController
    {
        public Action openMenu = delegate () { };
        public Action gameStart = delegate () { };
        public Action gameOver = delegate () { };

        private GameStates _gameState;

        void setState(GameStates _state)
        {
            switch (_state)
            {
                case GameStates.gameInMenu:
                    _gameState = _state;
                    openMenu();
                    break;
                case GameStates.gameStart:
                    _gameState = _state;
                    gameStart();
                    break;
                case GameStates.gameOver:
                    _gameState = _state;
                    gameOver();
                    break;
                default:
                    break;
            }
        }
    }
}