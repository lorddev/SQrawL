using System.Collections.Generic;

namespace Devlord.Sqrawl
{
    public interface ISelectable
    {
        void AddReferencedTablesTo(List<Table> tables);
    }
}