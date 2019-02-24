using System;

namespace Constructing_a_car_1___Engine_and_Fuel_Tank
{
    public class Car : ICar
    {
        public IDrivingInformationDisplay drivingInformationDisplay; // car #2  
        private IDrivingProcessor drivingProcessor; // car #2
        public IFuelTankDisplay fuelTankDisplay;
        private IEngine engine;
        private IFuelTank fuelTank;

        private const int defaultAcceleration = 10; // car #2
        private const int freeWheelSlowingDown = 1; // car #2

        private const double defaultFuelLevel = 20.0d;
        private const double consumptionOnIdle = 0.0003d;

        public Car() : this (defaultFuelLevel, defaultAcceleration)
        {
        }

        public Car(double fuelLevel) : this (fuelLevel, defaultAcceleration)
        {
        }

        public Car(double fuelLevel, int maxAcceleration) // car #2
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor(engine, maxAcceleration);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public bool EngineIsRunning { get { return engine.IsRunning; } }

        public void EngineStart() => engine.Start();

        public void EngineStop() => engine.Stop();

        public void Refuel(double liters) => fuelTank.Refuel(liters);

        public void RunningIdle() => engine.Consume(consumptionOnIdle);

        public void BrakeBy(int speed) => drivingProcessor.ReduceSpeed(speed); // car #2

        public void Accelerate(int speed) // car #2
        {
            if (speed >= drivingProcessor.ActualSpeed)
                drivingProcessor.IncreaseSpeedTo(speed);
            else
                FreeWheel();
        }

        public void FreeWheel() // car #2
        {
            if (drivingProcessor.ActualSpeed == 0)
                RunningIdle();
            else
                drivingProcessor.ReduceSpeed(freeWheelSlowingDown);
        }
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

    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        private IDrivingProcessor drivingProcessor;

        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            this.drivingProcessor = drivingProcessor;
        }

        public int ActualSpeed
        {
            get
            {
                return drivingProcessor.ActualSpeed;
            }
        }
    }

    public class DrivingProcessor : IDrivingProcessor // car #2
    {
        private const int maxSpeedLimit = 250;
        private const int maxAcceptableAcceleration = 20;
        private const int minAcceptableAcceleration = 5;
        private const int defaultBreak = 10;

        private Tuple<int, int, double>[] consumptionOnAccelerateTable = new Tuple<int, int, double>[]
           {
                new Tuple<int, int, double>(1, 60, 0.0020d),
                new Tuple<int, int, double>(61, 100, 0.0014d),
                new Tuple<int, int, double>(101, 140, 0.0020d),
                new Tuple<int, int, double>(141, 200, 0.0025d),
                new Tuple<int, int, double>(201, maxSpeedLimit, 0.0030d)
           };

        private IEngine engine;
        private int maxAcceleration;

        public DrivingProcessor(IEngine engine, int maxAcceleration)
        {
            this.engine = engine;
            if (maxAcceleration > maxAcceptableAcceleration)
                this.maxAcceleration = maxAcceptableAcceleration;
            else if (maxAcceleration < minAcceptableAcceleration)
                this.maxAcceleration = minAcceptableAcceleration;
            else
                this.maxAcceleration = maxAcceleration;
        }
        
        public int ActualSpeed { get; private set; }

               
        public void IncreaseSpeedTo(int speed)
        {
            if (speed <= 0 || !engine.IsRunning)
                return;

            int acceleration;
            int requiredAcceleration = speed - ActualSpeed;
            if (requiredAcceleration > maxAcceleration)
                acceleration = maxAcceleration;
            else
                acceleration = requiredAcceleration;

            ActualSpeed = ActualSpeed + acceleration;
            if (ActualSpeed > maxSpeedLimit)
                ActualSpeed = maxSpeedLimit;

            ConsumeFuelOnAccelerate(ActualSpeed);
        }

        private void ConsumeFuelOnAccelerate(int actualSpeed)
        {
            double consumption = 0d;

            foreach (var t in consumptionOnAccelerateTable)
            {
                if (actualSpeed >= t.Item1 && actualSpeed <= t.Item2)
                {
                    consumption = t.Item3;
                }
            }

            engine.Consume(consumption);
        }

        
        public void ReduceSpeed(int speed)
        {
            if (ActualSpeed == 0)
                return;

            if (speed > defaultBreak)
                ActualSpeed -= defaultBreak;
            else
                ActualSpeed -= speed;
        }
    }
}
