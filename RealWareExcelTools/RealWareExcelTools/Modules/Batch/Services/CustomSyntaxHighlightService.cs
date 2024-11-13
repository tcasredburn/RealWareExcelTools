using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace RealWareExcelTools.Modules.Batch.Services
{
    public class CustomSyntaxHighlightService : ISyntaxHighlightService
    {
        private readonly Document document;

        // Regular expressions for JSON syntax elements
        private readonly Regex _propertyNameRegex = new Regex("\"(\\\\.|[^\"])*\"(?=\\s*[:])");
        private readonly Regex _stringValueRegex = new Regex("\"(\\\\.|[^\"])*\"(?!\\s*[:])");
        private readonly Regex _numberRegex = new Regex(@"\b\d+(\.\d+)?([eE][+-]?\d+)?\b", RegexOptions.Compiled);
        private readonly Regex _booleanNullRegex = new Regex(@"\b(true|false|null)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly Regex _punctuationRegex = new Regex(@"[{}\[\],:]", RegexOptions.Compiled);


        public CustomSyntaxHighlightService(Document document)
        {
            this.document = document;
        }

        public void ForceExecute()
        {
            Execute();
        }

        public void Execute()
        {
            List<SyntaxHighlightToken> tokens = ParseTokens();
            document.ApplySyntaxHighlight(tokens);
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();

            // Find property names
            var ranges = document.FindAll(_propertyNameRegex).GetAsFrozen() as DocumentRange[];
            foreach (var range in ranges)
            {
                tokens.Add(CreateToken(range.Start.ToInt(), range.End.ToInt(), Color.Maroon));
            }

            // Find string values
            ranges = document.FindAll(_stringValueRegex).GetAsFrozen() as DocumentRange[];
            foreach (var range in ranges)
            {
                if (!IsRangeInTokens(range, tokens))
                    tokens.Add(CreateToken(range.Start.ToInt(), range.End.ToInt(), Color.Brown));
            }

            // Find numbers
            ranges = document.FindAll(_numberRegex).GetAsFrozen() as DocumentRange[];
            foreach (var range in ranges)
            {
                if (!IsRangeInTokens(range, tokens))
                    tokens.Add(CreateToken(range.Start.ToInt(), range.End.ToInt(), Color.DarkCyan));
            }

            // Find booleans and nulls
            ranges = document.FindAll(_booleanNullRegex).GetAsFrozen() as DocumentRange[];
            foreach (var range in ranges)
            {
                if (!IsRangeInTokens(range, tokens))
                    tokens.Add(CreateToken(range.Start.ToInt(), range.End.ToInt(), Color.Blue));
            }

            // Find punctuation
            ranges = document.FindAll(_punctuationRegex).GetAsFrozen() as DocumentRange[];
            foreach (var range in ranges)
            {
                if (!IsRangeInTokens(range, tokens))
                    tokens.Add(CreateToken(range.Start.ToInt(), range.End.ToInt(), Color.Black));
            }

            // Order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());

            // Fill in gaps with default color
            tokens = CombineWithPlainTextTokens(tokens);

            return tokens;
        }

        // Combine tokens with default text to cover the entire document
        private List<SyntaxHighlightToken> CombineWithPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            List<SyntaxHighlightToken> result = new List<SyntaxHighlightToken>(tokens.Count * 2 + 1);
            int documentStart = this.document.Range.Start.ToInt();
            int documentEnd = this.document.Range.End.ToInt();

            if (tokens.Count == 0)
            {
                result.Add(CreateToken(documentStart, documentEnd, Color.Black));
            }
            else
            {
                SyntaxHighlightToken firstToken = tokens[0];
                if (documentStart < firstToken.Start)
                    result.Add(CreateToken(documentStart, firstToken.Start, Color.Black));

                result.Add(firstToken);

                for (int i = 1; i < tokens.Count; i++)
                {
                    SyntaxHighlightToken token = tokens[i];
                    SyntaxHighlightToken prevToken = tokens[i - 1];
                    if (prevToken.End != token.Start)
                        result.Add(CreateToken(prevToken.End, token.Start, Color.Black));
                    result.Add(token);
                }

                SyntaxHighlightToken lastToken = tokens[tokens.Count - 1];
                if (documentEnd > lastToken.End)
                    result.Add(CreateToken(lastToken.End, documentEnd, Color.Black));
            }

            return result;
        }

        // Create a syntax highlight token with specified color
        private SyntaxHighlightToken CreateToken(int start, int end, Color foreColor)
        {
            SyntaxHighlightProperties properties = new SyntaxHighlightProperties
            {
                ForeColor = foreColor
            };
            return new SyntaxHighlightToken(start, end - start, properties);
        }

        // Check if the range overlaps with existing tokens
        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            return tokens.Any(t => IsIntersect(range, t));
        }

        // Determine if two ranges intersect
        private bool IsIntersect(DocumentRange range, SyntaxHighlightToken token)
        {
            int start = range.Start.ToInt();
            int end = range.End.ToInt() - 1;

            return (start >= token.Start && start < token.End) ||
                   (end >= token.Start && end < token.End) ||
                   (start < token.Start && end >= token.End);
        }
    }

    // Comparer to sort tokens by their start position
    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }
}
