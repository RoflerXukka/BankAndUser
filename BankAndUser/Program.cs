using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Example
{
    static void Main()
    {
        List<int> bill = new List<int>();
        List<bool> status = new List<bool>();
        bill.Add(105);
        bill.Add(352);
        bill.Add(-21);
        status.Add(true);
        status.Add(true);
        status.Add(true);
        while (true)
        {
            for (int i = 0; i < bill.Count; i++)
            {
                if (bill[i] < 50)
                {
                    status[i] = false;
                }
                else
                    status[i] = true;
            }
            Console.WriteLine("Чего желаете?");
            Console.WriteLine("Нажмите 1 для создания нового счёта");
            Console.WriteLine("Нажмите 2 чтобы списать деньги со счёта");
            Console.WriteLine("Нажмите 3 чтобы узнать ваш текущий баланс");
            Console.WriteLine("Нажмите 4 чтобы увидеть все ваши счета");
            Console.WriteLine("Нажмите 5 чтобы пополнить счёт");
            Console.WriteLine("Нажмите 6 чтобы очистить экран");
            Console.WriteLine("Нажмите 7 чтобы уничтожить счёт(доступно только при балансе свыше 50 рупий)");
            Console.WriteLine("Нажмите 8 дабы отсортировать счета(по убыванию");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Введите зачисляемую сумму на новый счёт(не меньше 50 рупий)");
                    int summ = 0;
                    try
                    {
                        summ = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        goto case '1';
                    }

                    if (summ < 50)
                    {
                        Console.WriteLine("Пошел нфиг(пожалуйста, повторите попытку с деньгами в этот раз)");
                        goto case '1';
                    }
                    bill.Add(summ);
                    status.Add(true);
                    break;
                case '2':
                    Console.WriteLine();
                    Console.WriteLine("С какого счёта вы желаете вытянуть свои монеты?");
                    for (int i = 0; i < bill.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, status[i] ? bill[i].ToString() : "ЗАБЛОКИРОВАНО ");
                    }
                    int n = 0;
                    try
                    {
                        n = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException) { goto case '2'; }

                    if (!status[n - 1])
                    {
                        Console.WriteLine("Сий счёт недоступен");
                        goto case '2';
                    }
                    Console.WriteLine("Сколько желаете снять?");
                    int money = 0;
                    try
                    {
                        money = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException) { goto case '2'; }
                    if (money > bill[n] + 50)
                    {
                        Console.WriteLine("А не жирно ли будет петух?");
                        goto case '2';
                    }
                    bill[n - 1] -= money;
                    break;
                case '3':
                    Console.WriteLine();
                    int balance = 0;
                    Console.WriteLine("На удивление, вот ваш баланс:");
                    for (int i = 0; i < bill.Count; i++)
                        balance += bill[i];
                    Console.WriteLine(balance);
                    break;
                case '4':
                    Console.WriteLine();
                    Console.WriteLine("Все ваши счета:");
                    for (int i = 0; i < bill.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, status[i] ? bill[i].ToString() : "ЗАБЛОКИРОВАНО ");
                    }
                    break;
                case '5':
                    Console.WriteLine();
                    Console.WriteLine("Все ваши счета:");
                    for (int i = 0; i < bill.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, status[i] ? bill[i].ToString() : "ЗАБЛОКИРОВАНО ");
                    }
                    Console.WriteLine("Выберите счёт для пополнения");
                    int key = 0;
                    try
                    {
                        key = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException) { goto case '5'; }
                    Console.WriteLine("Введите зачисляемую сумму на новый счёт(не меньше 50 рупий)");
                    int bonus = 0;
                    try
                    {
                        bonus = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        goto case '5';
                    }

                    if (bonus < 50)
                    {
                        Console.WriteLine("Пошел  нфиг(пожалуйста, повторите попытку с деньгами в этот раз)");
                        goto case '5';
                    }
                    bill[key - 1] += (bonus);
                    break;
                case '6':
                    Console.Clear();
                    break;
                case '7':
                    Console.WriteLine();
                    for (int i = 0; i < bill.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, status[i] ? bill[i].ToString() : "ЗАБЛОКИРОВАНО ");
                    }
                    int num = 0;
                    Console.WriteLine("Выберите счёт для уничтожения(весь ваш баланс выше 50 рупий вернется к вам");
                    try
                    {
                        num = int.Parse(Console.ReadLine());

                    }
                    catch (FormatException)
                    {
                        goto case '7';
                    }
                    if (bill[num] < 50)
                    {
                        Console.WriteLine("Недостаточно золота на счету для его уничтожения, вы всё ещё должны банку {0}", bill[num]);
                        continue;
                    }
                    bill.RemoveAt(num);
                    break;
                case '8':
                    Console.WriteLine();

                    for (int j = 0; j < bill.Count; j++)
                    {
                        for (int i = 0; i < bill.Count; i++)
                        {
                            if (bill[j] > bill[i])
                            {
                                int help = bill[i];
                                bill[i] = bill[i];
                                bill[i] = help;
                                bool help2 = status[i];
                                status[i] = status[i];
                                status[i] = help2;

                            }
                        }
                    }
                    for (int i = 0; i < bill.Count; i++)
                    {
                        Console.WriteLine("{0} - {1}", i + 1, status[i] ? bill[i].ToString() : "ЗАБЛОКИРОВАНО ");
                    }
                    break;
                default:
                    Console.WriteLine("\nВыберите сщуествующую комнаду");
                    break;
            }

        }
    }
}