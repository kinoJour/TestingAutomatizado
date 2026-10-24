using System;

namespace Prime.Services
{
    //public interface IAuditLogger
    //{
        //void LogEvaluation(int candidate, bool result);
    //}
    public class PrimeService
    {
        private readonly IAuditLogger _auditLogger;

        public PrimeService(IAuditLogger auditLogger = null)
        {
            _auditLogger = auditLogger;
        }

        public bool IsPrime(int candidate)
        {
            bool resultado;

            if (candidate < 2)
            {
                resultado = false;
            }
            else
            {
                resultado = true;

                for (int i = 2; i <= Math.Sqrt(candidate); i++)
                {
                    if (candidate % i == 0)
                    {
                        resultado = false;
                        break;
                    }
                }
            }

            _auditLogger?.LogEvaluation(candidate, resultado);

            return resultado;
        }
    }
}