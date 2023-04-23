using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnShop.Script.Model.Board;
using PawnShop.Script.Model.Piece;
using static PawnShop.Script.Model.Player.BasePlayer;

namespace PawnShop.Script.Model.Player
{
    public class PlayerInfo
    {
        public int Currency { get; private set; } = 0;

        public PlayerSide Side { get; private set; }

        public PlayerType Type { get; private set; }

        public List<BasePiece> Pieces { get; private set; } = new List<BasePiece>();

        public IReadOnlySet<Position> Reign
        {
            get
            {
                HashSet<Position> result = new HashSet<Position>();
                foreach (BasePiece piece in Pieces) 
                {
                    if (piece.Reign != null)
                    {
                        result = new HashSet<Position>(result.Concat(piece.Reign));
                    }
                }
                return result;
            }
        }

        public bool HasValidMoves => Pieces.Any(piece => piece.GetAllMoves().Any());

        public PlayerInfo(PlayerSide side, PlayerType type)
        {
            Side = side;
            Type = type;
        }

        public void Add(BasePiece piece)
        {
            Pieces.Add(piece);
        }

        public void Remove(BasePiece piece)
        {
            Pieces.Remove(piece);
        }

        public void Update()
        {
            foreach (BasePiece piece in Pieces) 
            {
                piece.Progress();
            }
        }

        public void Spend(int coin) => Currency -= coin;

        public void Gain(int coin) => Currency += coin;
    }
}
