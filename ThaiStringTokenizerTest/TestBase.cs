using System;
using System.Collections.Generic;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public abstract class TestBase
    {
        public virtual void Verify(string input, List<string> expected, bool shortWordFirst = false)
        {
            var tokenizer = new ThaiTokenizer(noSpace: false, shortWordFirst: shortWordFirst);

            Verify(tokenizer, input, expected);
        }

        public virtual void Verify(ThaiTokenizer tokenizer, string input, List<string> expected)
        {
            var results = tokenizer.Split(input);

            Console.WriteLine("==============");
            Console.WriteLine("input = {0}", input);

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine(results[i]);
                Assert.Equal(expected[i], results[i]);
            }

            Console.WriteLine("==============");
        }
    }
}