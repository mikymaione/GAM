/*
GAM# - Gestione Accoglienza Minori
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.ServiceProcess;

namespace GAMSharpServices
{
    sealed class GAMSharpServices : ServiceBase
    {

        private System.Timers.Timer timer = new System.Timers.Timer();
        private bool AggiornamentoControllato = false;
        private bool BKFatto = false;


        public GAMSharpServices()
        {
            InitializeComponent();
        }

        private int HourToMillisecond(int hours)
        {
            return MinuteToMillisecond(60) * hours;
        }

        private int MinuteToMillisecond(int minute)
        {
            return SecondToMillisecond(60) * minute;
        }

        private int SecondToMillisecond(int second)
        {
            return second * 1000;
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = HourToMillisecond(1);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            base.OnStart(args);
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!AggiornamentoControllato)
            {
                System.DateTime ora = System.DateTime.Now;

                if (ora.Hour == 1)
                {

                }
            }
        }

        private void InitializeComponent()
        {
            // 
            // GAMSharpServices
            // 
            this.CanPauseAndContinue = true;
            this.ServiceName = "GAMSharp Services";
        }


    }
}