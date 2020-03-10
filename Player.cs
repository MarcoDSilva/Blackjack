using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Player
    {
        private string name;
        private double bank;

        public Player()
        {
            SetName("");
            SetBank(0.0);
        }

        public Player(string name, double bank)
        {
            SetName(name);
            SetBank(bank);
        }

        // ====== GETTERS / SETTERS ======
        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
       
        public double GetBank()
        {
            return bank;
        }

        public void SetBank(double bank)
        {
            this.bank = bank;
        }
    }
}
