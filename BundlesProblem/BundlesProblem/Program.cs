// See https://aka.ms/new-console-template for more information
using BundlesProblem.Algorithm;
using BundlesProblem.ProductBuilder;

Console.WriteLine("Hello, World!");

#region Generic Algorithm
var product = new Inventory("p0", 1, true);

//Parts
var p1 = new Inventory("p1", 1, false);
var p2 = new Inventory("p2", 1, false);
var p3 = new Inventory("p3", 1, false);
var p4 = new Inventory("p4", 1, false);
var p5 = new Inventory("p5", 1, false);
var p6 = new Inventory("p6", 1, false);
var p7 = new Inventory("p7", 1, false);
var p8 = new Inventory("p8", 2, false);
var p9 = new Inventory("p9", 1, false);
var p10 = new Inventory("p10", 1, false);

product
    .AddPart(p1)
    .AddPart(p2)
    .AddPart(p3);
p1
  .AddPart(p4)
  .AddPart(p5);

p2.AddPart(p6);
p3.AddPart(p7);

p4.AddPart(p8);
p5.AddPart(p9);
p9.AddPart(p10);

//Get The number of products that can be assembled with the given stock.
List<Inventory> stock = new List<Inventory>();
stock.Add(new Inventory("p1", 5, false));
stock.Add(new Inventory("p2", 8, false));
stock.Add(new Inventory("p3", 10, false));
stock.Add(new Inventory("p4", 7, false));
stock.Add(new Inventory("p5", 5, false));
stock.Add(new Inventory("p6", 7, false));
stock.Add(new Inventory("p7", 5, false));
stock.Add(new Inventory("p8", 6, false));
stock.Add(new Inventory("p9", 5, false));
stock.Add(new Inventory("p10", 10, false));

var count = product.GetCountOfProducts(stock);
Console.WriteLine($"{count} products can be assembled with the available stock");

#endregion

#region Bundle Bike Using Generic Algorithm

var bike = new Inventory("bike", 1, true);

bike
    .AddPart(new Inventory("wheel", 2, false))
    .AddPart(new Inventory("pedal", 2, false))
    .AddPart(new Inventory("seat", 1, false))
    .AddPart(new Inventory("frame", 1, false))
    .AddPart(new Inventory("break", 2, false));

Console.WriteLine(bike.ToString());

#endregion

#region Bundle Computer Using Generic Algorithm
/* Assumption:
 * A Computer has --> IU (InputUnit) , OU (OutputUnit) , CU (ControlUnit)
 * IU has --> Keyboard , Mouse
 * OU has --> Monitor
 * CU --> CPU , MotherBoard, OSLicense
 * MotherBoard --> HardDrive, CoolingFan, Sockets, GraphicCard
 *  
 */

var computer = new Inventory("Computer", 1, true);
computer
    .AddPart(new Inventory("IU", 1, false)
                   .AddPart(new Inventory("Keyboard", 1, false))
                   .AddPart(new Inventory("Mouse", 1, false))
                   )
    .AddPart(new Inventory("OU", 1, false)
                   .AddPart(new Inventory("Monitor", 1, false)))
    .AddPart(new Inventory("CU", 1, false)
                   .AddPart(new Inventory("OSLicense", 1, false))
                   .AddPart(new Inventory("CPU", 1, false)
                        .AddPart(new Inventory("MotherBoard", 1, false)
                            .AddPart(new Inventory("HardDrive", 1, false))
                            .AddPart(new Inventory("CoolingFan", 1, false))
                            .AddPart(new Inventory("Sockets", 1, false))
                            .AddPart(new Inventory("GraphicCard", 1, false))
                        )

                   ));

//Get The number of computers that can be assembled with the given stock.
List<Inventory> stockForComputer = new List<Inventory>();
stockForComputer.Add(new Inventory("Keyboard", 16, false));
stockForComputer.Add(new Inventory("Mouse", 8, false));
stockForComputer.Add(new Inventory("Monitor", 12, false));
stockForComputer.Add(new Inventory("HardDrive", 18, false));
stockForComputer.Add(new Inventory("CoolingFan", 20, false));
stockForComputer.Add(new Inventory("Sockets", 20, false));
stockForComputer.Add(new Inventory("GraphicCard", 8, false));
stockForComputer.Add(new Inventory("OSLicense", 20, false));

var countOfComputers = computer.GetCountOfProducts(stockForComputer);
Console.WriteLine($"{countOfComputers} Computers can be assembled with the available stock");

#endregion

#region Bundle a bike using Builder pattern -- Fist Problem In the Assignment
var bikeBundle = new BikeBuilder();
bikeBundle
    .AddPart(new BundlePart("wheel"))
    .AddPart(new BundlePart("pedals"))
    .AddPart(new BundlePart("seat"))
    .AddPart(new BundlePart("frame"))
    .AddPart(new BundlePart("breaks"));

Console.WriteLine(bikeBundle.AssembleParts());
#endregion



Console.ReadLine();