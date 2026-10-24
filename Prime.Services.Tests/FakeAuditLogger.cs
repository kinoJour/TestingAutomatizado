using Prime.Services;
using System.Collections.Generic;

namespace Prime.Services.Tests
{
    //objeto que guarda los registros en memoria
    public class FakeAuditLogger : IAuditLogger
    {
        public List<string> Registros { get; private set; }

        public FakeAuditLogger()
        {
            Registros = new List<string>();
        }

        public void LogEvaluation(int candidate, bool result)
        {
            Registros.Add(candidate + ":" + result);
        }
    }
}
