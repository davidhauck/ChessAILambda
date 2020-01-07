using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLambda
{
	public class BestMoveFinder
	{
		const int MaxDepth = 4;

		public Move FindBestMove(string fen)
		{
			var board = new FenParser.FenParser(fen);
			var pieces = FenToListMapper.GetPieces(board.BoardStateData);
			var whitePieces = pieces.Item1;
			var blackPieces = pieces.Item2;

			Maxi(MaxDepth, whitePieces, blackPieces, Double.MinValue, Double.MaxValue);
			return _moveToMake;
		}

		Move _moveToMake;

		private double Maxi(int depth, List<Piece> player1, List<Piece> player2, double alpha, double beta)
		{
			if (depth == 0)
			{
				return Evaluator.Evaluate(player1, player2);
			}

			for (int i = 0; i < player2.Count; i++)
			{
				var piece = player2[i];
				foreach (var point in AvailableMovesFinder.GetPossibleMoves(player1, player2, piece))
				{
					//store the old location of the current piece
					var oldPieceX = piece.X;
					var oldPieceY = piece.Y;

					//move the current piece
					piece.X = point.X;
					piece.Y = point.Y;

					//remove any pieces from the opponent that the current piece landed on
					var takenPieceIndex = player1.FindIndex(0, player1.Count, p => p.X == point.X && p.Y == point.Y);
					Piece takenPiece = default(Piece);
					if (takenPieceIndex >= 0)
					{
						takenPiece = player1[takenPieceIndex];
						player1.RemoveAt(takenPieceIndex);
					}

					double value = Mini(depth - 1, player1, player2, alpha, beta);

					//reset pieces to original location
					piece.X = oldPieceX;
					piece.Y = oldPieceY;
					if (takenPieceIndex >= 0)
					{
						player1.Insert(takenPieceIndex, takenPiece);
					}

					//set alpha to be the max value for this node's children
					if (value > alpha)
					{
						alpha = value;
						if (MaxDepth == depth)
						{
							_moveToMake.FromX = piece.X;
							_moveToMake.FromY = piece.Y;
							_moveToMake.DestX = point.X;
							_moveToMake.DestY = point.Y;
						}
					}

					if (beta <= alpha)
					{
						break;
					}
				}
			}

			return alpha;
		}

		private double Mini(int depth, List<Piece> player1, List<Piece> player2, double alpha, double beta)
		{
			if (depth == 0)
			{
				return Evaluator.Evaluate(player1, player2);
			}

			for (int i = 0; i < player1.Count; i++)
			{
				var piece = player1[i];
				foreach (var point in AvailableMovesFinder.GetPossibleMoves(player2, player1, piece))
				{
					var oldPieceX = piece.X;
					var oldPieceY = piece.Y;
					piece.X = point.X;
					piece.Y = point.Y;

					var takenPieceIndex = player2.FindIndex(0, player2.Count, p => p.X == point.X && p.Y == point.Y);
					Piece takenPiece = default(Piece);
					if (takenPieceIndex >= 0)
					{
						takenPiece = player2[takenPieceIndex];
						player2.RemoveAt(takenPieceIndex);
					}

					double value = Maxi(depth - 1, player1, player2, alpha, beta);
					piece.X = oldPieceX;
					piece.Y = oldPieceY;

					if (takenPieceIndex >= 0)
					{
						player2.Insert(takenPieceIndex, takenPiece);
					}

					if (value < beta)
					{
						beta = value;
					}
					if (beta <= alpha)
					{
						break;
					}
				}
			}

			return beta;
		}
	}
}
