using PawnShop.Script.Manager.Gameplay;
using PawnShop.Script.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.Move
{
    /// <summary>
    /// Manager class to record a timeline of all turns taken during the match.
    /// </summary>
    public sealed class History
    {
        public IReadOnlyList<Turn> MatchHistory => history.ToList().AsReadOnly();
        private Stack<Turn> history = new Stack<Turn>();
        private Stack<Turn> aborted = new Stack<Turn>();
        private Action? historyBuffer;
        public bool IsNewTurn => !aborted.Any();
        public event EventHandler<BaseMove>? OnExecute;
        public event EventHandler<BaseMove>? OnAbort;
        public static event StaticEvent<bool>.Handler? OnEnableUndo;
        public static event StaticEvent<bool>.Handler? OnEnableRedo;

        public History()
        {
            Turn.OnPlay += OnPlay;
        }

        /// <summary>
        /// Callback delegate to respond to "redo" user command.
        /// </summary>
        public void Execute()
        {
            Turn turn = aborted.Peek();
            historyBuffer = () => aborted.Pop();
            OnExecute?.Invoke(this, turn.Move);
            history.Push(turn);
            GameManager.Instance.TriggerTurnChange();
        }

        /// <summary>
        /// Callback delegate to respond to "undo" user command.
        /// </summary>
        public void Abort()
        {
            Turn turn = history.Peek();
            historyBuffer = () => history.Pop();
            OnAbort?.Invoke(this, turn.Move);
            aborted.Push(turn);
            GameManager.Instance.TriggerTurnChange();
        }

        private void OnPlay(Turn turn)
        {
            OnExecute?.Invoke(this, turn.Move);
            history.Push(turn);
            aborted.Clear();
        }

        public void Progress()
        {
            historyBuffer?.Invoke();
            historyBuffer = null;
            OnEnableUndo?.Invoke(history.Any());
            OnEnableRedo?.Invoke(aborted.Any());
        }
    }
}
