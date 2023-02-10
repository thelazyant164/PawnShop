using ChessUltimate.Script.Manager;
using ChessUltimate.Script.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUltimate.Script.System.Gameplay
{
    public class TurnSystem
    {
        private readonly List<Player> activePlayers;

        public TurnSystem(GameManager.GameConfig config)
        {
            activePlayers = new List<Player>
            {
                new Player(Player.PlayerSide.White, config.White),
                new Player(Player.PlayerSide.Black, config.Black)
            };
        }

        public void Update()
        {
            foreach (Player player in activePlayers)
            {
                player.Progress();
            }
        }

        public Player GetPlayer(Player.PlayerSide side)
        {
            return activePlayers.Find(player => player.Side == side);
        }

        public List<Position> GetReign(Player player)
        {
            return player.Reign;
        }
    }
}
