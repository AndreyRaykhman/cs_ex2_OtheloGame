﻿using System;
namespace Ex02_Othelo
{
    public class IOhandler
    {
        public IOhandler()
        {
        }
        public Move GetNextMove()
        {
            return new Move(true); 
        }

        public string GetPlayerName()
        {
            return "Moshe"; 
        }

        public UI.eModeGame GetGameMode()
        {
            return UI.eModeGame.PlayerVsComputer; 
        }

        public bool GetStartNewGameSelection()
        {
            return true; 
        }

        public void ShowBoard(Board io_Board)
        { 
        }

        public void ShowGameResultMessage()
        { 
        }

        public void ShowGoodByeMessage()
        { 
        }
    }
}