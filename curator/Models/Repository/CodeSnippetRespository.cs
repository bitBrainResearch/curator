using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curator.Models.Repository
{
    public class CodeSnippetRepository : Repository<CodeSnippet>
    {
        public List<CodeSnippet> GetByName(String name)
        {
            return DbSet.Where(a => a.Title.Contains(name)).ToList();
        }
    }
}
