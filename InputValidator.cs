﻿using System;
namespace Ex02_Othelo
{
    public class InputValidator
    {
        //TODO: move numbers to const
        public InputValidator()
        {
        }

        public bool MoveStringIsValidMove(string i_MoveString, out Move o_NextMove)
        {
            return Move.TryParse(i_MoveString, out o_NextMove);
        }

        public bool BoardSizeIsValid(string i_BoardSizeString, out int o_BoardSize)
        {
            bool v_InputIsNumber;
            bool v_InputIsLegalBoardSize;

            v_InputIsNumber = Int32.TryParse(i_BoardSizeString, out o_BoardSize);
            if (v_InputIsNumber)
            {
                v_InputIsLegalBoardSize = o_BoardSize == 6 || o_BoardSize == 8;
            }
            else
            {
                v_InputIsLegalBoardSize = false; 
            }

            return v_InputIsLegalBoardSize;
        }


        public bool GameModeIsValid(string i_GameModeOption, out UI.eModeGame o_GameMode)
        {
            bool v_GameModeIsLegal;
            bool v_InputIsNumber;
            int v_Option;

            o_GameMode = UI.eModeGame.Invalid;

            v_InputIsNumber = Int32.TryParse(i_GameModeOption, out v_Option);
            if (v_InputIsNumber)
            {
                v_GameModeIsLegal = v_Option == 1 || v_Option == 2;
                if (v_GameModeIsLegal)
                {
                    o_GameMode = getModeGameFromNumber(v_Option); 
                }
            }
            else
            {
                v_GameModeIsLegal = false;
            }

            return v_GameModeIsLegal;
        }
        private UI.eModeGame getModeGameFromNumber(int i_SelectedNumber)
        {
            if (i_SelectedNumber == 0)
            {

                return UI.eModeGame.PlayerVsPlayer;
            }
            else
            {

                return UI.eModeGame.PlayerVsComputer;
            }
        }

        public bool MoveIsValid(string i_MoveString, out Move o_NextMove)
        {
            o_NextMove = null;
            return Move.TryParse(i_MoveString, out o_NextMove); 
        }

        public bool PlayAgainIsValid(string i_PlayAgainString, out int o_Play)
        {
            bool v_PlayAgainSelectionIsValid;
            bool v_InputIsNumber = Int32.TryParse(i_PlayAgainString, out o_Play);
            if (v_InputIsNumber)
            {
                v_PlayAgainSelectionIsValid = o_Play == 1 || o_Play == 0;
            }
            else
            {
                v_PlayAgainSelectionIsValid = false;
            }

            return v_PlayAgainSelectionIsValid;
        }
    }
}
