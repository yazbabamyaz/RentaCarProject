using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        ////CarManager carManager = new CarManager(new InMemoryCarDal());
        //CarManager carManager=new CarManager (new EfCarDal());

        //carManager.Add(new Car { BrandId = 5, ColorId = 2, CarName="BMW", ModelYear = 2020, DailyPrice = 2300 });
        //foreach (var car in carManager.GetAll())
        //{
        //    Console.WriteLine(car.CarName);
        //}
        //Console.WriteLine("*************");


        //foreach (var car in carManager.GetAll())
        //{
        //    Console.WriteLine(car.ModelYear);
        //}

        //Console.WriteLine("Ekleme Yapıldıktan sonra---------");
        //Car car1 = new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 700, CarName = "Mercedes", ModelYear = 2016 };

        //carManager.Add(car1);

        //foreach (var item in carManager.GetAll())
        //{
        //    Console.WriteLine(item.ModelYear);
        //}

        CustomerTest();

        CarTest();
        return;
        Console.WriteLine("*************");
        ColorTest();
        Console.WriteLine("*************");
        BrandTest();
    }
    private static void CustomerTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
       IResult value= customerManager.Add(new Customer
        {
            UserId = 1,
            CompanyName = "deneme"
        });
        var value2=new Customer { Id=10, CompanyName="Nasa", UserId=5 };
        IResult result= customerManager.Delete(value2);

        Console.WriteLine(result.Message);
        Console.WriteLine("************");
        Console.WriteLine(value.Message);
    }
    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        var result = brandManager.GetAll();
        foreach (var brand in result.Data)
        {
            Console.WriteLine(brand.BrandName);
        }
    }

    private static void ColorTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        var result= colorManager.GetAll();
        foreach (var color in result.Data)
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetAll();
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarName + " ** " + car.ModelYear + " ** " + car.DailyPrice);
        }
    }
}