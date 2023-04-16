using PawnShop.Script.Model.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Manager.Gameplay
{
    /// <summary>
    /// Manager class to record a timeline of all turns taken during the match.
    /// </summary>
    public sealed class History
    {
        private Stack<Turn> history = new Stack<Turn>();
        private Stack<Turn> aborted = new Stack<Turn>();

        public event EventHandler<BaseMove>? OnExecute;
        public event EventHandler<BaseMove>? OnAbort;

        public History() 
        {
            Turn.OnPlay += OnPlay;
        }

        /// <summary>
        /// Callback delegate to respond to "redo" user command.
        /// </summary>
        public void InvokeExecute(object? sender, EventArgs e)
        {
            OnExecute?.Invoke(sender, aborted.Peek().Move);
            history.Push(aborted.Pop());
        }

        /// <summary>
        /// Callback delegate to respond to "undo" user command.
        /// </summary>
        public void InvokeAbort(object? sender, EventArgs e)
        {
            OnAbort?.Invoke(sender, history.Peek().Move);
            aborted.Push(history.Pop());
        }

        private void OnPlay(Turn turn)
        {
            OnExecute?.Invoke(this, turn.Move);
            history.Push(turn);
            aborted.Clear();
        }
    }
}
