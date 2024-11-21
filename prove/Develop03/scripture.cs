using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorization
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords(int numberToHide)
        {
            var random = new Random();
            var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

            for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public string GetDisplayText()
        {
            var scriptureText = string.Join(' ', _words.Select(word => word.GetDisplayText()));
            return $"{_reference.GetDisplayText()} - {scriptureText}";
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }
    }
}

