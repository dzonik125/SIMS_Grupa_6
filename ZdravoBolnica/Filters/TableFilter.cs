using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Filers
{
    abstract class TableFilter<T>
    {
        public abstract bool KeywordFilter(T entity, string keyword);

        private string[] Keywords;

        public void SetKeywordsFromInput(string input)
        {
            Keywords = input.Split(" ");
        }

        public ObservableCollection<T> ApplyFilters(ObservableCollection<T> unfiltered)
        {
            ObservableCollection<T> filtered = new ObservableCollection<T>();

            foreach (T entity in unfiltered)
            {
                if (ShouldAddEntity(entity))
                {
                    filtered.Add(entity);
                }
            }
            return filtered;
        }

        protected virtual bool ShouldAddEntity(T entity)
        {
            return EntitySatisfiesKeywordFilter(entity);
        }

        private bool EntitySatisfiesKeywordFilter(T entity)
        {
            foreach (string keyword in Keywords)
            {
                if (!KeywordFilter(entity, keyword))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
