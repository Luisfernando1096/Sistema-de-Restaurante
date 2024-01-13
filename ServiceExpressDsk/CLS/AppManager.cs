﻿using System;
using System.Windows.Forms;

namespace ServiceExpressDsk.CLS
{
    internal class AppManager : ApplicationContext
    {
        private Boolean Splash()
        {
            Boolean Resultado = true;
            GUI.Splash f = new GUI.Splash();
            f.ShowDialog();

            return Resultado;
        }

        private Boolean Login()
        {
            Boolean Resultado = true;
            GUI.Login f = new GUI.Login();
            f.ShowDialog();
            Resultado = f.Autorizado;

            return Resultado;
        }
        public AppManager()
        {
            if (Splash())
            {
                if (Login())
                {
                    GUI.Main f = new GUI.Main();
                    f.ShowDialog();
                    Continua();
                }
            }
        }
        private void Continua()
        {
            if (Login())
            {
                GUI.Main f = new GUI.Main();
                f.ShowDialog();
                Continua();
            }

        }

    }
}