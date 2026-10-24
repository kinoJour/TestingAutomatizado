namespace Prime.Services
{
    public interface IAuditLogger
    {
        void LogEvaluation(int candidate, bool result);
    }
}