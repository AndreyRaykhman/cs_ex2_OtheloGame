﻿using System;
using System.Text;
namespace Ex02_Othelo
{
     public class IOhandler
     {
          private InputValidator m_Valdator;
          private UI m_UIhandler;
          private int m_SizeBoard;



          public IOhandler()
          {
               m_Valdator = new InputValidator();
               m_UIhandler = new UI();
          }

          public enum eGameResult
          {
               Player1,
               Player2,
               Tie
          }

          public void ClearScreen()
          {
               m_UIhandler.ClearScreen();
          }

          public Move GetNextMove(Player i_Player)
          {
               Move nextMove = null;
               string nextMoveString;
               bool moveIsValid = false;

               m_UIhandler.ShowWhichPlayerTurn(i_Player.PlayerName);
               while (!moveIsValid)
               {
                    nextMoveString = m_UIhandler.GetNextMoveString();
                    moveIsValid = m_Valdator.MoveIsValid(nextMoveString, out nextMove);
                    if (!moveIsValid)
                    {
                         m_UIhandler.ShowInvalidMoveMessage();
                    }
               }

               return nextMove;
          }

          public string GetPlayerName()
          {
               string playerName = "";
               bool inputIsNotValid = true;

               while (inputIsNotValid)
               {
                    playerName = m_UIhandler.GetNameFromUser();
                    inputIsNotValid = playerName.Length == 0;
               }

               return playerName;
          }

          public UI.eModeGame GetGameMode()
          {
               bool inputIsNotValid = true;
               UI.eModeGame chosenGameMode = UI.eModeGame.Invalid;

               while (inputIsNotValid)
               {
                    string enteredGameMode = m_UIhandler.GetModeGameFromUser();
                    inputIsNotValid = !m_Valdator.GameModeIsValid(enteredGameMode, out chosenGameMode);
               }

               return chosenGameMode;
          }

          public bool GetStartNewGameSelection()
          {
               bool inputIsNotValid = true;
               bool startNewGameSelected = true;
               string enteredOption = m_UIhandler.GetResponseForPlayAgainMessage();

               while (inputIsNotValid)
               {
                    inputIsNotValid = m_Valdator.PlayAgainIsValid(enteredOption, out startNewGameSelected);
               }
               return startNewGameSelected;
          }

          public void ShowBoard(Board io_Board)
          {
               StringBuilder boardStr = io_Board.ToStringBuilder();
               m_UIhandler.PrintBoard(boardStr);
          }

          public void ShowNoAvailbleMovesForPlayer(string i_PlayerName)
          {
               m_UIhandler.ShowNoAvailableMovesMessage(i_PlayerName);
          }

          public void ShowGameResultMessage(Player i_Player1, Player i_Player2, eGameResult i_gameResult)
          {
               m_UIhandler.ShowGameSummeryTitle();
               m_UIhandler.ShowPlayerScode(i_Player1.PlayerName, i_Player1.Score);
               m_UIhandler.ShowPlayerScode(i_Player2.PlayerName, i_Player2.Score);

               if (i_gameResult == eGameResult.Player1)
               {
                    m_UIhandler.ShowPlayerWonMessage(i_Player1.PlayerName);
               }
               else if (i_gameResult == eGameResult.Player2)
               {
                    m_UIhandler.ShowPlayerWonMessage(i_Player2.PlayerName);
               }
               else
               {
                    m_UIhandler.ShowGameResultTie();
               }

          }

          public void ShowIllegalMoveMessage()
          {
               m_UIhandler.ShowInvalidMoveMessage();
          }

          public void ShowGoodByeMessage()
          {
               m_UIhandler.ShowGameEnded();
          }
          public void GetSizeBoard()
          {
               int size;
               string sizeString = m_UIhandler.GetBoardSize();

               while (!m_Valdator.BoardSizeIsValid(sizeString, out size))
               {
                    sizeString = m_UIhandler.GetBoardSize();
               }

               m_SizeBoard = size;
          }

          public int SizeBoard
          {
               get{return m_SizeBoard;} 
          }
        public void ShowGameQuittedMessage()
        {
            m_UIhandler.ShowGameQuitted(); 
        }
    }
}
