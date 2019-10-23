# StrategySupporter
Module for supporting the implementation of Strategy Pattern in .NET.
The StrategySupporter essentially uses System.Reflection and metadata annotating by Attributes to interpret and instantiate the implementations of your Strategy Pattern.

## The usage of StrategySupporter

### Step 1
Define your custom ``Attribute`` derived from ``StrategyIdentifier``.
For example:
````
    public class CarAttribute : StrategyIdentifier
    {
        private string _carType;

        public CarAttribute(string carType)
        {
            _carType = carType;
        }

        public string GetCarType()
        {
            return _carType;
        }
    }
````

### Step 2
Implement your own Strategy Pattern and tag the implementations' classes with your derived ``StrategyIdentifier`` ``Attribure``.
For example:
````
    public interface ICar
    {
        void Beep();
    }
    
    [CarAttribute("sportCar")]
    public class SportCar : ICar
    {
        public void Beep()
        {
            Console.WriteLine("A sport car beeped.");
        }
    }
    
    [CarAttribute("miniVan")]
    public class MiniVan : ICar
    {
        public void Beep()
        {
            Console.WriteLine("A mini van beeped.");
        }
    }
    
    [CarAttribute("bus")]
    public class MiniBus : ICar
    {
        public void Beep()
        {
            Console.WriteLine("A mini bus beeped.");
        }
    }
    
    public class CarContext
    {
        private IImplementationFactory _implementationFactory;

        private ICar _car;

        public CarContext(Assembly executingAssembly, StrategyIdentifierFunc<CarAttribute> strategyIdentifierFunc)
        {
            _implementationFactory = new ImplementationFactory(executingAssembly);
            _car = _implementationFactory.Create<ICar, CarAttribute>(strategyIdentifierFunc);
        }

        public void Beep()
        {
            _car.Beep();
        }
    }

````

## Step 4
Instantiate the CarContext, and pass the required parameters. For example:
````
    public static void Main(string[] args)
    {
        // The Assembly, where your Strategy is implemented.
        Assembly executingAssembly = Assembly.GetExecutingAssembly();

        // define the CarContext
        CarContext carContext = new CarContext(executingAssembly, MiniVanIdentifierFunc);
        
        // The output (in this case: "A mini van beeped.")
        carContext.Beep();
    }
    
    // Define the function as a StrategyIdentifierFunc, which implements your base logic
    // for determining the required  Strategy implementation.
    public static bool MiniVanIdentifierFunc(CarAttribute carAttribute)
    {
        // By the passed Attribute you can define the condition for searching the implementation. 
        return carAttribute.GetCarType() == "miniVan";
    }
    
    
````

## Step 5
Verify your output
### Output:
````
"A mini van beeped."
````
