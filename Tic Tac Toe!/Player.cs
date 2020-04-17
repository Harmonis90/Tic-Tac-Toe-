using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_ {
    class Player {
        private string playerName;
        private string playerToken;
        

        public string Name {
            get {
                return playerName;
            }
            set {
                playerName = value;
            } 
        }
        public string Token {
            get {
                return playerToken;
            }
            set {
                playerToken = value;    
            }
        }

    }
}
