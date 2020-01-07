using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLambda
{
	class AvailableMovesFinder
	{
		public static IEnumerable<Point> GetPossibleMoves(List<Piece> player2, List<Piece> player1, Piece piece)
		{
			if (piece.Label == 'P')
			{
				return GetPawnMoves(player2, player1, piece.X, piece.Y, piece.IsPlayer1, piece.HasMoved);
			}
			if (piece.Label == 'R')
			{
				return GetRookMoves(player2, player1, piece.X, piece.Y);
			}
			if (piece.Label == 'N')
			{
				return GetKnightMoves(player1, piece.X, piece.Y);
			}
			if (piece.Label == 'B')
			{
				return GetBishopMoves(player2, player1, piece.X, piece.Y);
			}
			if (piece.Label == 'Q')
			{
				return GetQueenMoves(player2, player1, piece.X, piece.Y);
			}
			if (piece.Label == 'K')
			{
				return GetKingMoves(player1, piece.X, piece.Y);
			}
			return null;
		}

		private static IEnumerable<Point> GetKingMoves(List<Piece> allies, int x, int y)
		{
			List<Piece> possiblePieces =
					allies.Where(piece => piece.X <= x + 1 && piece.X >= x - 1 && piece.Y >= y - 1 && piece.Y <= y + 1)
								.ToList();
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (x + i >= 0 && x + i <= 7 && y + j >= 0 && y + j <= 7 &&
							!possiblePieces.Any(piece => piece.X == x + i && piece.Y == y + j))
					{
						yield return new Point(x + i, y + j);
					}
				}
			}
		}

		private static IEnumerable<Point> GetQueenMoves(List<Piece> opponent, List<Piece> allies, int x, int y)
		{
			for (int i = 1; i < 8; i++)
			{
				if (y + i > 7 || allies.Any(piece => (piece.X == x) && (piece.Y == y + i)))
				{
					break;
				}

				yield return new Point(x, y + i);

				if (opponent.Any(piece => (piece.X == x) && (piece.Y == y + i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (y - i < 0 || allies.Any(piece => (piece.X == x) && (piece.Y == y - i)))
				{
					break;
				}

				yield return new Point(x, y - i);

				if (opponent.Any(piece => (piece.X == x) && (piece.Y == y - i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x + i > 7 || allies.Any(piece => (piece.X == x + i) && (piece.Y == y)))
				{
					break;
				}

				yield return new Point(x + i, y);

				if (opponent.Any(piece => (piece.X == x + i) && (piece.Y == y)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x - i < 0 || allies.Any(piece => (piece.X == x - i) && (piece.Y == y)))
				{
					break;
				}

				yield return new Point(x - i, y);

				if (opponent.Any(piece => (piece.X == x - i) && (piece.Y == y)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x + i > 7 || y + i > 7 || allies.Any(piece => (piece.X == x + i) && (piece.Y == y + i)))
				{
					break;
				}

				yield return new Point(x + i, y + i);

				if (opponent.Any(piece => (piece.X == x + i) && (piece.Y == y + i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x - i < 0 || y + i > 7 || allies.Any(piece => (piece.X == x - i) && (piece.Y == y + i)))
				{
					break;
				}

				yield return new Point(x - i, y + i);

				if (opponent.Any(piece => (piece.X == x - i) && (piece.Y == y + i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x - i < 0 || y - i < 0 || allies.Any(piece => (piece.X == x - i) && (piece.Y == y - i)))
				{
					break;
				}

				yield return new Point(x - i, y - i);

				if (opponent.Any(piece => (piece.X == x - i) && (piece.Y == y - i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x + i > 7 || y - i < 0 || allies.Any(piece => (piece.X == x + i) && (piece.Y == y - i)))
				{
					break;
				}

				yield return new Point(x + i, y - i);

				if (opponent.Any(piece => (piece.X == x + i) && (piece.Y == y - i)))
				{
					break;
				}
			}
		}

		private static IEnumerable<Point> GetBishopMoves(List<Piece> opponent, List<Piece> allies, int x, int y)
		{
			for (int i = 1; i < 8; i++)
			{
				if (x + i > 7 || y + i > 7 || allies.Any(piece => (piece.X == x + i) && (piece.Y == y + i)))
				{
					break;
				}

				yield return new Point(x + i, y + i);

				if (opponent.Any(piece => (piece.X == x + i) && (piece.Y == y + i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x - i < 0 || y + i > 7 || allies.Any(piece => (piece.X == x - i) && (piece.Y == y + i)))
				{
					break;
				}

				yield return new Point(x - i, y + i);

				if (opponent.Any(piece => (piece.X == x - i) && (piece.Y == y + i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x - i < 0 || y - i < 0 || allies.Any(piece => (piece.X == x - i) && (piece.Y == y - i)))
				{
					break;
				}

				yield return new Point(x - i, y - i);

				if (opponent.Any(piece => (piece.X == x - i) && (piece.Y == y - i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x + i > 7 || y - i < 0 || allies.Any(piece => (piece.X == x + i) && (piece.Y == y - i)))
				{
					break;
				}

				yield return new Point(x + i, y - i);

				if (opponent.Any(piece => (piece.X == x + i) && (piece.Y == y - i)))
				{
					break;
				}
			}
		}

		private static IEnumerable<Point> GetKnightMoves(List<Piece> allies, int x, int y)
		{
			var possiblePieces = allies.Where(piece =>
																								((piece.Y == y + 2 || piece.Y == y - 2) &&
																								 (piece.X == x - 1 || piece.X == x + 1)) ||
																								((piece.X == x + 2) || piece.X == x - 2) &&
																								(piece.Y == y - 1 || piece.Y == y + 1)).ToList();


			if (x + 1 <= 7 && y + 2 <= 7 && !possiblePieces.Any(piece => piece.X == x + 1 && piece.Y == y + 2))
			{
				yield return new Point(x + 1, y + 2);
			}
			if (x + 2 <= 7 && y + 1 <= 7 && !possiblePieces.Any(piece => piece.X == x + 2 && piece.Y == y + 1))
			{
				yield return new Point(x + 2, y + 1);
			}
			if (x - 1 >= 0 && y + 2 <= 7 && !possiblePieces.Any(piece => piece.X == x - 1 && piece.Y == y + 2))
			{
				yield return new Point(x - 1, y + 2);
			}
			if (x - 2 >= 0 && y + 1 <= 7 && !possiblePieces.Any(piece => piece.X == x - 2 && piece.Y == y + 1))
			{
				yield return new Point(x - 2, y + 1);
			}
			if (x + 1 <= 7 && y - 2 >= 0 && !possiblePieces.Any(piece => piece.X == x + 1 && piece.Y == y - 2))
			{
				yield return new Point(x + 1, y - 2);
			}
			if (x + 2 <= 7 && y - 1 >= 0 && !possiblePieces.Any(piece => piece.X == x + 2 && piece.Y == y - 1))
			{
				yield return new Point(x + 2, y - 1);
			}
			if (x - 1 >= 0 && y - 2 >= 0 && !possiblePieces.Any(piece => piece.X == x - 1 && piece.Y == y - 2))
			{
				yield return new Point(x - 1, y - 2);
			}
			if (x - 2 >= 0 && y - 1 >= 0 && !possiblePieces.Any(piece => piece.X == x - 2 && piece.Y == y - 1))
			{
				yield return new Point(x - 2, y - 1);
			}
		}

		private static IEnumerable<Point> GetRookMoves(List<Piece> opponent, List<Piece> allies, int x, int y)
		{
			List<Piece> possibleAllies = allies.Where(piece => piece.X == x || piece.Y == y).ToList();
			List<Piece> possibleEnemies = opponent.Where(piece => piece.X == x || piece.Y == y).ToList();

			for (int i = 1; i < 8; i++)
			{
				if (y + i > 7 || possibleAllies.Any(piece => (piece.X == x) && (piece.Y == y + i)))
				{
					break;
				}

				yield return new Point(x, y + i);

				if (possibleEnemies.Any(piece => (piece.X == x) && (piece.Y == y + i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (y - i < 0 || possibleAllies.Any(piece => (piece.X == x) && (piece.Y == y - i)))
				{
					break;
				}

				yield return new Point(x, y - i);

				if (possibleEnemies.Any(piece => (piece.X == x) && (piece.Y == y - i)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x + i > 7 || possibleAllies.Any(piece => (piece.X == x + i) && (piece.Y == y)))
				{
					break;
				}

				yield return new Point(x + i, y);

				if (possibleEnemies.Any(piece => (piece.X == x + i) && (piece.Y == y)))
				{
					break;
				}
			}
			for (int i = 1; i < 8; i++)
			{
				if (x - i < 0 || possibleAllies.Any(piece => (piece.X == x - i) && (piece.Y == y)))
				{
					break;
				}

				yield return new Point(x - i, y);

				if (possibleEnemies.Any(piece => (piece.X == x - i) && (piece.Y == y)))
				{
					break;
				}
			}
		}

		private static IEnumerable<Point> GetPawnMoves(List<Piece> opponent, List<Piece> allies, int x, int y, Boolean isMovingUp, Boolean hasMoved)
		{
			if (isMovingUp)
			{
				if (!opponent.Any(piece => (piece.X == x) && (piece.Y == y + 1)) && !allies.Any(piece => (piece.X == x) && (piece.Y == y + 1)))
				{
					yield return new Point(x, y + 1);
				}
				if (hasMoved == false && !opponent.Any(piece => (piece.X == x) && (piece.Y == y + 2)) && !allies.Any(piece => (piece.X == x) && (piece.Y == y + 2)) && !opponent.Any(piece => (piece.X == x) && (piece.Y == y + 1)) && !allies.Any(piece => (piece.X == x) && (piece.Y == y + 1)))
				{
					yield return new Point(x, y + 2);
				}
				if (x - 1 >= 0 && y + 1 >= 0 && opponent.Any(piece => (piece.X == x - 1) && (piece.Y == y + 1)))
				{
					yield return new Point(x - 1, y + 1);
				}
				if (x + 1 < 8 && y + 1 >= 0 && opponent.Any(piece => (piece.X == x + 1) && (piece.Y == y + 1)))
				{
					yield return new Point(x + 1, y + 1);
				}
			}
			if (!isMovingUp)
			{
				if (!opponent.Any(piece => (piece.X == x) && (piece.Y == y - 1)) && !allies.Any(piece => (piece.X == x) && (piece.Y == y - 1)))
				{
					yield return new Point(x, y - 1);
				}
				if (hasMoved == false && !opponent.Any(piece => (piece.X == x) && (piece.Y == y - 2)) && !allies.Any(piece => (piece.X == x) && (piece.Y == y - 2)) && !opponent.Any(piece => (piece.X == x) && (piece.Y == y - 1)) && !allies.Any(piece => (piece.X == x) && (piece.Y == y - 1)))
				{
					yield return new Point(x, y - 2);
				}
				if (x - 1 >= 0 && y - 1 < 8 && opponent.Any(piece => (piece.X == x - 1) && (piece.Y == y - 1)))
				{
					yield return new Point(x - 1, y - 1);
				}
				if (x + 1 < 8 && y - 1 < 8 && opponent.Any(piece => (piece.X == x + 1) && (piece.Y == y - 1)))
				{
					yield return new Point(x + 1, y - 1);
				}
			}
		}
	}
}
