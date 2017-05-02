using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SDK;
using SortObjects;
using Sorting;


namespace UnitTest
{
    public class NUnitTestSortingScales
    {
        [Test]

        [TestCase("СКЗ",  3, TestName = "Тестирование. Входная строка = СКЗ. Количестов симолов  = 3")]
        [TestCase("ССЗКЗКССЗК", 10, TestName = "Тестирование. Входная строка = СКЗ. Количестов симолов  = 10")]
        [TestCase("ССКЗЗКЗССКСЗКСКЗКСЗК", 20, TestName = "Тестирование. Входная строка = СКЗ. Количестов симолов  = 20")]
        [TestCase(" ", 0, TestName = "Тестирование. Входная строка = . Количестов симолов  = 0")]

        public void NUnitTestNumberLetters(string stringInput, int result)
        {
            SortingScales sortClass = new SortingScales();

            Assert.AreEqual(result, sortClass.NumberLetters(stringInput));
        }

     
        [TestCase("С < К > З", ExpectedException = (typeof(Exception)), TestName = "Тестирование. Входная строка = С < К > З. ")]
        [TestCase("С > К < З", ExpectedException = (typeof(Exception)), TestName = "Тестирование. Входная строка = С > К < З. ")]

        public void NUnitTestParsingString(string stringInput)
        {
            SortingScales sortClass = new SortingScales();

            Dictionary<char, int> weightLetter = new Dictionary<char, int>();

            sortClass.ParsingString(stringInput, weightLetter);
        }


        [TestCase("СКЗ", 1, 'З', "СЗЗ", TestName = "Тестирование. Входная строка = СКЗ. Индекс символа для замены = 1, Cимолов для замены = 3. Результат = СЗЗ")]
        [TestCase("СКЗЗСК", 3, 'К', "СКЗКСК", TestName = "Тестирование. Входная строка = СКЗЗСК. Индекс символа для замены = 3, Cимолов для замены = К. Результат = СКЗКСК")]
        [TestCase("СКЗЗСК", 2, 'С', "СКСЗСК", TestName = "Тестирование. Входная строка = СКЗЗСК. Индекс символа для замены = 2, Cимолов для замены = С. Результат = СКСЗСК")]
        [TestCase("СКЗКСЗЗСК", 5, 'К', "СКЗКСКЗСК", TestName = "Тестирование. Входная строка = СКЗКСЗЗСК. Индекс символа для замены = 5, Cимолов для замены = К. Результат = СКЗКСКЗСК")]
        [TestCase("СКЗЗСК", -1, 'К', "СКЗЗСК", ExpectedException = (typeof(IndexOutOfRangeException)), TestName = "Тестирование. Входная строка = СКЗКСЗЗСК. Индекс символа для замены = -1, Cимолов для замены = К. Результат = Индес за пределом диапазона")]

        public void NUnitTestReplaceCharInString(String source, int index, Char newSymb, string result)
        {
            SortingScales sortClass = new SortingScales();

            Assert.AreEqual(result, sortClass.ReplaceCharInString(source, index, newSymb));

            
        }

        [TestCase("КЗС", 'С', 1, 'К', 2, 'З', 3, "СКЗ", TestName = "Тестирование. Входная строка = КЗС. Условие = С > К > З. Результат = СКЗ")]
        [TestCase("КЗСЗКС", 'С', 1, 'К', 2, 'З', 3, "ССККЗЗ", TestName = "Тестирование. Входная строка = КЗСЗКС. Условие = С > К > З. Результат = ССККЗЗ")]
        [TestCase("КЗСЗКС", 'С', 2, 'К', 3, 'З', 1, "ЗЗССКК", TestName = "Тестирование. Входная строка = КЗСЗКС. Условие = С > К > З. Результат = ЗЗССКК")]
        [TestCase("КЗСЗКС", 'С', 3, 'К', 1, 'З', 2, "ККЗЗСС", TestName = "Тестирование. Входная строка = КЗСЗКС. Условие = С > К > З. Результат = ККЗЗСС")]
        [TestCase(" ", 'С', 3, 'К', 1, 'З', 2, " ", TestName = "Тестирование. Входная строка =  . Условие = С > К > З. Результат = ")]
        [TestCase("  ", 'С', 3, 'К', 1, 'З', 2, " ", ExpectedException = (typeof(KeyNotFoundException)), TestName = "Тестирование. Входная строка =  . Условие = С > К > З. Результат = Ключ уже используется")]
        [TestCase("  ", 'С', 3, 'К', 1, 'К', 2, " ", ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Входная строка =  . Условие = С > К > З. Результат = Неверный аргумент")]
        public void NUnitTestSortData(string stringInput, char charC, int intC, char charК, int intK, char charZ, int intZ, string result)
        {
            SortingScales sortClass = new SortingScales();

            Dictionary<char, int> weightLetter = new Dictionary<char, int>();

            weightLetter.Add(charC, intC);
            weightLetter.Add(charК, intK);
            weightLetter.Add(charZ, intZ);

            Assert.AreEqual(result, sortClass.SortData(stringInput, weightLetter));


        }
    }
}
