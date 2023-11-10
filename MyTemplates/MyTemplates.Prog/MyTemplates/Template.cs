using System;
using System.Collections.Generic;

namespace MyTemplates
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class DeliveryModel
    {
        public string fullname { get; set; }
        public string adress { get; set; }
    }

    public class VideoAccessModel
    {
        public string fullname { get; set; }
        public int age { get; set; }
    }

    public class GroupModel
    {
        public string fullname { get; set; }
        public string Subject { get; set; }
        public string group { get; set; }
        public List<Student> students { get; set; }
    }

    public class MyTemplateMethods
    {
        public static string GreetingMessage(string name)
        {
            return $"Здравствуйте, {name}! Вы уволены";
        }

        public static string DeliveryMessage(DeliveryModel model)
        {
            return $"Здравствуйте, {model.fullname}, проживающий по адресу {model.adress}, Ваша посылка дошла в пункт выдачи";
        }

        public static string VideoAccessMessage(VideoAccessModel model)
        {
            return $"Здравствуйте, {model.fullname}! {(model.age >= 18 ? "Вам стали доступны home video" : "Вот Ваша ссылка на Смешариков: https://www.youtube.com/playlist?list=PLeVA7eICJ6d1vzYh_SsxifcybiksP45D1")}";
        }

        public static string GroupInfoMessage(GroupModel model)
        {
            string message = $"Здравствуйте, {model.fullname}. Ваше название предмета: {model.Subject}; Номер группы: {model.group}; \nСписок группы: ";

            foreach (var student in model.students)
            {
                message += $"\n-{student.Surname} {student.Name} ";
            }

            return message;
        }
    }
}
