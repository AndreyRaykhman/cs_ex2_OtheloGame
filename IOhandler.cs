﻿using System;
using System.Text;
namespace Ex02_Othelo
{
    public class IOhandler
    {
        InputValidator m_Valdator;
        UI m_UIhandler;
        StringBuilder m_BoardStr;

        public IOhandler()
        {
            m_Valdator = new InputValidator();
            m_UIhandler = new UI();
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

        public int GetSizeOfBoard()
        {
             bool sizeIsValid = false;
             int sizeBoard=0;
             string sizeBoardString;

             while (!sizeIsValid)
             {
                 sizeBoardString = m_UIhandler.GetBoardSize();
                    sizeIsValid = m_Valdator.BoardSizeIsValid(sizeBoardString, out sizeBoard);
             }

             return sizeBoard;
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
            bool inputIsValid = false;
            bool startNewGameSelected = true;
            string enteredOption = m_UIhandler.GetResponseForPlayAgainMessage();

            while (!inputIsValid)
            {
                inputIsValid = m_Valdator.PlayAgainIsValid(enteredOption, out startNewGameSelected);
            }

            return startNewGameSelected;
        }

        public void ShowBoard(Board io_Board)
        {
            m_BoardStr = io_Board.BoardToString();
            m_UIhandler.PrintBoard(m_BoardStr);
        }

        private void ClearPrintBoard()
        {
            ClearScreen();
            m_UIhandler.PrintBoard(m_BoardStr);
        }

        public void ShowNoAvailbleMovesForPlayer(string i_PlayerName)
        {
            ClearPrintBoard();
            m_UIhandler.ShowNoAvailableMovesMessage(i_PlayerName); 
        }

        public void ShowGameResultMessage(Player i_Player1, Player i_Player2, Game.eGameResult i_gameResult)
        {
            m_UIhandler.ShowGameSummeryTitle();
            m_UIhandler.ShowPlayerScore(i_Player1.PlayerName, i_Player1.Score);
            m_UIhandler.ShowPlayerScore(i_Player2.PlayerName, i_Player2.Score);

            if (i_gameResult == Game.eGameResult.Player1)
            {
                m_UIhandler.ShowPlayerWonMessage(i_Player1.PlayerName);
            }
            else if (i_gameResult == Game.eGameResult.Player2)
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
            ClearPrintBoard();
            m_UIhandler.ShowInvalidMoveMessage();
        }

        public void ShowGoodByeMessage()
        {
               m_UIhandler.ShowGameEnded();
               Environment.Exit(1);
        }

        public void ShowGameQuittedMessage()
        {
            m_UIhandler.ShowGameQuitted(); 
        }
    }
}
