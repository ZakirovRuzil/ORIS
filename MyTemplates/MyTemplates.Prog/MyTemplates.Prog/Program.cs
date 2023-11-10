using System;
using MyTemplates;

class Program
{
    static void Main()
    {
        string name = "Закиров Рузиль";
        Console.WriteLine(MyTemplateMethods.GreetingMessage(name));

        var deliveryModel = new DeliveryModel { fullname = "Закиров Рузиль", adress = "ДУ 18" };
        Console.WriteLine(MyTemplateMethods.DeliveryMessage(deliveryModel));

        var videoAccessModel = new VideoAccessModel { fullname = "Закиров Рузиль", age = 17 };
        Console.WriteLine(MyTemplateMethods.VideoAccessMessage(videoAccessModel));

        var groupModel = new GroupModel
        {
            fullname = "Закиров Рузиль",
            Subject = "Прога",
            group = "11-209",
            students = new List<Student> { new Student { Name = "Илья", Surname = "Климкин" }, new Student { Name = "Тимур", Surname = "Минуллин" } }
        };
        Console.WriteLine(MyTemplateMethods.GroupInfoMessage(groupModel));
    }
}