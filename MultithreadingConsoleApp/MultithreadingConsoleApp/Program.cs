using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Программа начала выполнение.");
            // Запуск нескольких потоков через Task
            Task[] tasks = new Task[]
            {
                PrintMessageWithDelayAsync("Сообщение из первого потока", 1000),
                PrintMessageWithDelayAsync("Сообщение из второго потока", 1500),
                PrintMessageWithDelayAsync("Сообщение из третьего потока", 2000)
            };

            // Ждем завершения всех задач
            await Task.WhenAll(tasks);

            Console.WriteLine("Программа завершила выполнение.");
        }

        // Асинхронный метод, выполняющий вывод сообщения
        static async Task PrintMessageWithDelayAsync(string message, int delay)
        {
            // Симуляция задержки
            await Task.Delay(delay);

            // Вывод сообщения и информации о потоке
            Console.WriteLine($"{message} - ID потока: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
