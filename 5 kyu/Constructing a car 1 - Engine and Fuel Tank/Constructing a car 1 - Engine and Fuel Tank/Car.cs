using System;

namespace Constructing_a_car_1___Engine_and_Fuel_Tank
{
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;
        private IEngine engine;
        private IFuelTank fuelTank;

        private const double defaultFuelLevel = 20.0d;
        private const double consumptionOnIdle = 0.0003d;

        public Car() : this (defaultFuelLevel)
        {
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }

        public bool EngineIsRunning { get { return engine.IsRunning; } }

        public void EngineStart() => engine.Start();

        public void EngineStop() => engine.Stop();

        public void Refuel(double liters) => fuelTank.Refuel(liters);

        public void RunningIdle() => engine.Consume(consumptionOnIdle); 
    }

    public class Engine : IEngine
    {
        IFuelTank fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }


        public bool IsRunning { get; private set; }

        public void Consume(double liters)
        {
            if (!IsRunning)
                return;

            if (fuelTank.FillLevel > liters)
                fuelTank.Consume(liters);
            else
                IsRunning = false;
        }

        public void Start()
        {
            if (fuelTank.FillLevel > 0.0d)
                IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        private double maxSize = 60.0d;
        private double reserveLevel = 5.0d;

        public FuelTank(double fuelLevel)
        {
            Refuel(fuelLevel);
        }

        public double FillLevel { get; private set; }

        public bool IsOnReserve
        {
            get
            {
                return FillLevel < reserveLevel;
            }
        }

        public bool IsComplete
        {
            get
            {
                return FillLevel == maxSize;
            }
        }

        public void Consume(double liters)
        {
            FillLevel -= liters;
        }

        public void Refuel(double liters)
        {
            double fuelLevel = FillLevel + liters;

            if (fuelLevel > maxSize)
                fuelLevel = maxSize;

            if (fuelLevel < 0.0d)
                fuelLevel = 0.0d;

            FillLevel = fuelLevel;
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }

        public double FillLevel
        {
            get
            {
                return Math.Round(fuelTank.FillLevel, 2);
            }
        }

        public bool IsOnReserve
        {
            get
            {
                return fuelTank.IsOnReserve;
            }
        }

        public bool IsComplete
        {
            get
            {
                return fuelTank.IsComplete;
            }
        }
    }
}
