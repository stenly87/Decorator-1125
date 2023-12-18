// See https://aka.ms/new-console-template for more information
// паттерн Декоратор
// структурный паттерн
// он позволяет динамически добавлять функциональность
// объектам (также убирать ее)
// можно использовать вместо наследования, когда
// существует много наследуемых особенностей класса
// декоратор позволяет создать обертку для объекта,
// которая включает в себя дополнительный функционал
// Декоратор наследует тот же интерфейс, что и целевой
// объект, соответственно наследники декоратора могут
// включать в себя других наследников декоратора, что
// в итоге создает объект с множеством функционала

Vehicle vehicle = new Vehicle();
Console.WriteLine("Проверка двигателя");
vehicle.Operation();
Car car = new Car(vehicle);
car.Operation();
Trailer trailer = new Trailer(car);
trailer.Operation();


public interface IMechanism
{
    void Operation();
}

class Vehicle : IMechanism
{
    public void Operation()
    {
        Console.WriteLine("Двигатель включен");
    }
}

public abstract class MechanismDecorator : IMechanism
{
    protected IMechanism mechanism;

    public MechanismDecorator(IMechanism mechanism)
    {
        this.mechanism = mechanism;
    }

    public abstract void Operation();
}

public class Car : MechanismDecorator
{
    Random random = new Random();
    public Car(IMechanism mechanism) : base(mechanism)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("Пытаемся завести машину");
        if (random.Next(0, 20) == 1)
        { 
            Console.WriteLine("Не заводится");
            return;
        }
        mechanism.Operation();
        Console.WriteLine("Машина завелась и готова ехать");
    }
}

public class Trailer : MechanismDecorator
{
    public Trailer(IMechanism mechanism) : base(mechanism)
    {
    }

    public override void Operation()
    {
        mechanism.Operation();
        Console.WriteLine("Трейлер движется вслед");
    }
}

// если пользоваться декоратором, то у нас есть варианты:
// просто двигатель
// машина с двигателем
// трейлер с двигателем
// трейлер с машиной с двигателем
// машина с трейлером и тд
// если не пользоваться декоратором, то пришлось бы
// создавать иерархии классов для каждого из этих сочетаний
// причем одни и те же машины в примере с декоратором
// будут разными классами машин, соответственно будет
// большое кол-во похожих классов с разной наследовательностью