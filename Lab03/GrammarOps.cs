using Grammar;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
	public class GrammarOps
	{

		private Terminal epsilon = new Terminal("{e}");
		public GrammarOps(IGrammar g)
		{
			this.g = g;
			compute_empty();
			compute_first();
		}

		private void compute_first()
		{
			First.Add(g.Rules[0], new HashSet<Terminal>() { epsilon });
		}

		public ISet<Nonterminal> EmptyNonterminals { get; } = new HashSet<Nonterminal>();
		public Dictionary<Rule, HashSet<Terminal>> First{ get; } = new Dictionary<Rule, HashSet<Terminal>>();
		private void compute_empty()
		{
			foreach (var rule in g.Rules)
			{
				if (rule.RHS.Count == 0)
				{
					EmptyNonterminals.Add(rule.LHS);
				}
			}

			int count;
			do
			{
				count = EmptyNonterminals.Count;
				foreach (var rule in g.Rules)
				{
					if (rule.RHS.All(x => x is Nonterminal && EmptyNonterminals.Contains(x)))
					{
						EmptyNonterminals.Add(rule.LHS);
					}
				}
			} while (count != EmptyNonterminals.Count);
		}

		private IGrammar g;
	}
}
