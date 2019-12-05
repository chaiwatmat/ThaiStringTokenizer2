using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string test = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var result = tokenizer.Split(test);
            var expected = GlobalExpectedResult.GetExpectedResult1();

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                // Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void Test2()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string test = "อดีตอาจทำให้เราเจ็บปวด แต่เราเลือกได้ว่าจะวิ่งหนีมันไป หรือใช้มันเป็นบทเรียน";
            var result = tokenizer.Split(test);

            var expected = new List<string>
            {
                "อดีต",
                "อาจ",
                "ทำให้",
                "เรา",
                "เจ็บปวด",
                "แต่",
                "เรา",
                "เลือก",
                "ได้",
                "ว่า",
                "จะ",
                "วิ่งหนี",
                "มัน",
                "ไป",
                "หรือ",
                "ใช้",
                "มัน",
                "เป็น",
                "บทเรียน"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                // Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void Test3()
        {
            List<string> appendDictionary = new List<string> { "หวัดดี", "หวักลี", "เชอแตม" };
            ThaiTokenizer tokenizer = new ThaiTokenizer(appendDictionary);
            string test = "หวักลีหวัดดีปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอดเชอแตม";
            var result = tokenizer.Split(test);

            var expected0 = new List<string> { "หวักลี", "หวัดดี" };
            var expected1 = GlobalExpectedResult.GetExpectedResult1();
            var expected2 = new List<string> { "เชอแตม" };

            var expected = expected0;
            expected.AddRange(expected1);
            expected.AddRange(expected2);

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                // Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void Test4()
        {
            List<string> appendDictionary = new List<string> { "หวัดดี", "หวักลี", "เชอแตม" };
            ThaiTokenizer tokenizer = new ThaiTokenizer(appendDictionary);
            string test = "ฤารักฉันจะเป็นเพียงความฝัน";
            var result = tokenizer.Split(test);

            var expected = new List<string>
            {
                "ฤา",
                "รัก",
                "ฉัน",
                "จะ",
                "เป็น",
                "เพียง",
                "ความฝัน",
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSubThaiString1()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var result = tokenizer.SubThaiString(text, 10);

            var expected = new List<string>
            {
                "ปลาที่ใหญ่ที่สุด",
                "ในโลกคือ",
                "ปารีสชุบแป้ง",
                "ทอด"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSubThaiString2()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var result = tokenizer.SubThaiString(text, 20);

            var expected = new List<string>
            {
                "ปลาที่ใหญ่ที่สุดในโลกคือ",
                "ปารีสชุบแป้งทอด"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}